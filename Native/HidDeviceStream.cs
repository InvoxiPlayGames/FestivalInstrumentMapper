using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Nefarius.Utilities.DeviceManagement.PnP;
using Windows.Win32;
using Windows.Win32.Devices.HumanInterfaceDevice;
using Windows.Win32.Foundation;
using Windows.Win32.Storage.FileSystem;

namespace FestivalInstrumentMapper
{
    using static PInvoke;
    using static WIN32_ERROR;
    using static FILE_SHARE_MODE;
    using static FILE_CREATION_DISPOSITION;
    using static FILE_FLAGS_AND_ATTRIBUTES;

    public sealed class HidDeviceStream : IDisposable
    {
        private readonly string _path;
        private SafeFileHandle? _handle;

        private readonly EventWaitHandle _readWaitHandle = new(false, EventResetMode.AutoReset);
        private readonly EventWaitHandle _writeWaitHandle = new(false, EventResetMode.AutoReset);

        public ushort VendorId { get; }
        public ushort ProductId { get; }
        public ushort Revision { get; }

        public string Serial { get; }

        public int InputLength { get; private set; }
        public int OutputLength { get; private set; }

        private HidDeviceStream(string path, HIDD_ATTRIBUTES attributes, HIDP_CAPS capabilities, string serial)
        {
            _path = path;

            VendorId = attributes.VendorID;
            ProductId = attributes.ProductID;
            Revision = attributes.VersionNumber;

            Serial = serial;

            InputLength = capabilities.InputReportByteLength;
            OutputLength = capabilities.OutputReportByteLength;
        }

        public void Dispose()
        {
            _handle?.Close();
            _handle = null;
        }

        public static IEnumerable<HidDeviceStream> Enumerate(List<(ushort vendorId, ushort productId)>? filterList)
        {
            for (int i = 0;
                Devcon.FindByInterfaceGuid(DeviceInterfaceIds.HidDevice, out string path, out _, i);
                i++)
            {
                // The HID devices created for XInput controllers have this in their device path
                if (path.Contains("IG_"))
                    continue;

                if (!Open(path, exclusive: false, out var handle) || !GetHardwareIds(handle, out var attributes) ||
                    !GetCapabilities(handle, out var capabilities) || !GetSerial(handle, out string? serial))
                    continue;

                // Ignore devices not present in the filter
                if (filterList != null && !filterList.Any((id) =>
                    id.vendorId == attributes.VendorID && id.productId == attributes.ProductID))
                    continue;

                yield return new HidDeviceStream(path, attributes, capabilities, serial);
            }
        }

        private static bool Open(string path, bool exclusive, out SafeFileHandle handle)
        {
            handle = CreateFile(
                path,
                (uint)(FILE_SHARE_READ | FILE_SHARE_WRITE),
                exclusive ? FILE_SHARE_NONE : (FILE_SHARE_READ | FILE_SHARE_WRITE),
                null,
                OPEN_EXISTING,
                FILE_FLAG_OVERLAPPED,
                null
            );

            if (handle == null || handle.IsInvalid)
            {
                LogWin32Error("Failed to open HID device");
                return false;
            }

            return true;
        }

        private static bool GetHardwareIds(SafeFileHandle handle, out HIDD_ATTRIBUTES attributes)
        {
            if (!HidD_GetAttributes(handle, out attributes))
            {
                LogWin32Error("Could not get HID attributes");
                attributes = default;
                return false;
            }

            return true;
        }

        private static bool GetCapabilities(SafeFileHandle handle, out HIDP_CAPS capabilities)
        {
            capabilities = default;

            if (!HidD_GetPreparsedData(handle, out var hidData) || hidData.Value == 0)
            {
                LogWin32Error("Could not get HID preparsed data");
                return false;
            }

            var status = HidP_GetCaps(hidData, out capabilities);
            if (status < 0) // HRESULT, not Win32 error
            {
                LogWin32Error("Could not get HID capabilities", status);
                return false;
            }

            return true;
        }

        private static unsafe bool GetSerial(SafeFileHandle handle, [NotNullWhen(true)] out string? serial)
        {
            Span<char> buffer = stackalloc char[2048];
            fixed (char* ptr = buffer)
            {
                bool result = HidD_GetSerialNumberString(handle, ptr, (uint)(buffer.Length * sizeof(char)));
                if (!result)
                {
                    LogWin32Error("Could not get HID serial number");
                    serial = null;
                    return false;
                }

                serial = new string(ptr);
                return true;
            }
        }

        public bool Open(bool exclusive)
        {
            if (_handle != null && !_handle.IsInvalid)
                return true;

            return Open(_path, exclusive, out _handle);
        }

        private void CheckDisposed()
        {
            ObjectDisposedException.ThrowIf(_handle == null || _handle.IsInvalid, _handle);
        }

        public unsafe bool Read(Span<byte> buffer)
        {
            CheckDisposed();

            if (buffer.Length < InputLength)
                return false;

            var overlapped = new NativeOverlapped()
            {
                EventHandle = _readWaitHandle.SafeWaitHandle.DangerousGetHandle()
            };

            uint bytesRead;
            bool success = ReadFile(_handle, buffer, &bytesRead, &overlapped);

            WIN32_ERROR result = (WIN32_ERROR)Marshal.GetLastPInvokeError();
            if (!success && result == ERROR_IO_PENDING)
            {
                _readWaitHandle.WaitOne();
                success = GetOverlappedResult(_handle, in overlapped, out bytesRead, true);
                result = (WIN32_ERROR)Marshal.GetLastPInvokeError();
            }

            if (!success && result != ERROR_SUCCESS)
            {
                LogWin32Error("Device read failed", result);
                return false;
            }

            SanityCheckResult(success, result);

            return bytesRead == InputLength;
        }

        public unsafe bool Write(Span<byte> buffer)
        {
            CheckDisposed();

            if (buffer.Length > OutputLength)
                return false;

            Span<byte> writeBuffer = stackalloc byte[OutputLength];
            buffer.CopyTo(writeBuffer);

            var overlapped = new NativeOverlapped
            {
                EventHandle = _writeWaitHandle.SafeWaitHandle.DangerousGetHandle()
            };

            bool success = WriteFile(_handle, writeBuffer, null, &overlapped);

            WIN32_ERROR result = (WIN32_ERROR)Marshal.GetLastPInvokeError();
            if (!success && result == ERROR_IO_PENDING)
            {
                _readWaitHandle.WaitOne();
                success = GetOverlappedResult(_handle, in overlapped, out _, true);
                result = (WIN32_ERROR)Marshal.GetLastPInvokeError();
            }

            if (!success && result != ERROR_SUCCESS)
            {
                LogWin32Error("Device write failed", result);
                return false;
            }

            SanityCheckResult(success, result);

            return true;
        }

        [Conditional("DEBUG")]
        private static void LogWin32Error(string message)
            => LogWin32Error(message, Marshal.GetLastPInvokeError());

        [Conditional("DEBUG")]
        private static void LogWin32Error(string message, WIN32_ERROR result)
            => LogWin32Error(message, (int)result);

        [Conditional("DEBUG")]
        private static void LogWin32Error(string message, int result)
        {
            Debug.Write(message);
            Debug.WriteLine($": {Marshal.GetPInvokeErrorMessage(result)} ({result})");
        }

        [Conditional("DEBUG")]
        private static void SanityCheckResult(bool success, WIN32_ERROR result)
        {
            if (!success && result != ERROR_SUCCESS)
                return;

            if (!success)
                Debug.WriteLine("Result was failure but GetLastPInvokeError returned success");
            else if (result != ERROR_SUCCESS)
                LogWin32Error("Result was success but GetLastPInvokeError returned an error", result);
        }
    }
}