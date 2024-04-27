using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidApi;

namespace FestivalInstrumentMapper
{
    internal enum HidApiDeviceType
    {
        Unknown,
        Santroller_RB,
        Santroller_GH,
        Wii_RB,
        PS3_RB,
        PS3_GH,
        PS4_RB_PDP,
        PS4_RB_MadCatz,
    }

    internal class HidApiDevice : InstrumentMapperDevice
    {
        private Device? _device;
        private DeviceInfo _info;
        private bool _shouldStop = false;
        private bool _isRunning = false;
        private SyntheticController? _controller = null;

        public HidApiDevice(Device device)
        {
            _device = device;
            _info = _device.GetDeviceInfo();
        }

        public HidApiDevice(DeviceInfo info)
        {
            _info = info;
        }

        public HidApiDeviceType GetDeviceType()
        {
            if (_info.VendorId == 0x1209 && _info.ProductId == 0x2882)
            {
                if (_info.ReleaseNumber == 0x0400)
                    return HidApiDeviceType.Santroller_RB;
                if (_info.ReleaseNumber == 0x0300)
                    return HidApiDeviceType.Santroller_GH;
            }

            if (_info.VendorId == 0x12BA)
            {
                if (_info.ProductId == 0x0200)
                    return HidApiDeviceType.PS3_RB;
                if (_info.ProductId == 0x0100)
                    return HidApiDeviceType.PS3_GH;
            }

            if (_info.VendorId == 0x1BAD && (_info.ProductId == 0x0004 || _info.ProductId == 0x3010))
                return HidApiDeviceType.Wii_RB;

            if (_info.VendorId == 0x0E6F && (_info.ProductId == 0x0173 || _info.ProductId == 0x024A))
                return HidApiDeviceType.PS4_RB_PDP;

            if (_info.VendorId == 0x0738 && _info.ProductId == 0x8261)
                return HidApiDeviceType.PS4_RB_MadCatz;

            return HidApiDeviceType.Unknown;
        }

        public override string ToString()
        {
            string device_name = $"Unknown-{_info.VendorId:X4}/{_info.ProductId:X4}/{_info.ReleaseNumber:X4}";
            switch (GetDeviceType())
            {
                case HidApiDeviceType.Wii_RB:
                    device_name = "Wii Rock Band Guitar";
                    break;
                case HidApiDeviceType.PS3_RB:
                    device_name = "PS3 Rock Band Guitar";
                    break;
                case HidApiDeviceType.PS3_GH:
                    device_name = "PS3 Guitar Hero Guitar";
                    break;
                case HidApiDeviceType.PS4_RB_MadCatz:
                    device_name = "PS4 Stratocaster";
                    break;
                case HidApiDeviceType.PS4_RB_PDP:
                    device_name = "PS4 Jaguar/Riffmaster";
                    break;
                case HidApiDeviceType.Santroller_RB:
                case HidApiDeviceType.Santroller_GH:
                    device_name = "Santroller Guitar";
                    break;
            }
            return $"{device_name} ({_info.SerialNumber})";
        }

        public void OpenDevice()
        {
            _device = new Device(_info.VendorId, _info.ProductId, _info.SerialNumber);
        }

        public void AssignController(SyntheticController? controller)
        {
            _controller = controller;
        }

        public void Stop()
        {
            _shouldStop = true;
        }

        public bool IsStopping()
        {
            return _shouldStop;
        }

        public bool IsRunning()
        {
            return _isRunning;
        }

        public void RunThread()
        {
            switch (GetDeviceType())
            {
                case HidApiDeviceType.Wii_RB:
                case HidApiDeviceType.PS3_RB:
                    RunThreadWiiPS3RB();
                    break;
                case HidApiDeviceType.PS3_GH:
                    RunThreadPS3GH();
                    break;
                case HidApiDeviceType.PS4_RB_PDP:
                case HidApiDeviceType.PS4_RB_MadCatz:
                    RunThreadPS4RB();
                    break;
                case HidApiDeviceType.Santroller_RB:
                    RunThreadSantroller();
                    break;
                case HidApiDeviceType.Santroller_GH:
                    RunThreadSantrollerGH();
                    break;
            }
        }

        public void RunThreadWiiPS3RB()
        {
            byte[] gipreport = new byte[0xE];
            _isRunning = true;
            while (true)
            {
                ReadOnlySpan<byte> hidreport = _device.Read(27);
                ToGip.PS3Wii_RB(hidreport.ToArray(), gipreport);
                _controller.SendData(gipreport);
                // unused bit in the gip report
                if ((gipreport[0] & 0x02) > 0)
                    _shouldStop = true;
                if (_shouldStop)
                    break;
            }
            _isRunning = false;
        }

        public void RunThreadPS3GH()
        {
            byte[] gipreport = new byte[0xE];
            _isRunning = true;
            while (true)
            {
                ReadOnlySpan<byte> hidreport = _device.Read(27);
                ToGip.PS3_GH(hidreport.ToArray(), gipreport);
                _controller.SendData(gipreport);
                // unused bit in the gip report
                if ((gipreport[0] & 0x02) > 0)
                    _shouldStop = true;
                if (_shouldStop)
                    break;
            }
            _isRunning = false;
        }

        public void RunThreadPS4RB()
        {
            byte[] gipreport = new byte[0xE];
            _isRunning = true;
            while (true)
            {
                ReadOnlySpan<byte> hidreport = _device.Read(78);
                ToGip.PS4_RB(hidreport.ToArray(), gipreport);
                _controller.SendData(gipreport);
                // unused bit in the gip report
                if ((gipreport[0] & 0x02) > 0)
                    _shouldStop = true;
                if (_shouldStop)
                    break;
            }
            _isRunning = false;
        }

        public void RunThreadSantroller()
        {
            byte[] gipreport = new byte[0xE];
            _isRunning = true;
            while (true)
            {
                ReadOnlySpan<byte> hidreport = _device.Read(27);
                ToGip.Santroller_RB(hidreport.ToArray(), gipreport);
                _controller.SendData(gipreport);
                // unused bit in the gip report
                if ((gipreport[0] & 0x02) > 0)
                    _shouldStop = true;
                if (_shouldStop)
                    break;
            }
            _isRunning = false;
        }

        public void RunThreadSantrollerGH()
        {
            byte[] gipreport = new byte[0xE];
            _isRunning = true;
            while (true)
            {
                ReadOnlySpan<byte> hidreport = _device.Read(27);
                ToGip.Santroller_GH(hidreport.ToArray(), gipreport);
                _controller.SendData(gipreport);
                // unused bit in the gip report
                if ((gipreport[0] & 0x02) > 0)
                    _shouldStop = true;
                if (_shouldStop)
                    break;
            }
            _isRunning = false;
        }
    }
}
