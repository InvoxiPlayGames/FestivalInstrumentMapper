using System.Runtime.InteropServices;

namespace FestivalInstrumentMapper
{
    internal static partial class GipSyntheticEx
    {
        private const string DllName = "GipSyntheticEx.dll";

        [LibraryImport(DllName, EntryPoint = "GipSynthEx_Startup")]
        public static partial int Startup();


        [LibraryImport(DllName, EntryPoint = "GipSynthEx_CreateController")]
        public static partial int CreateController(int type, ref ulong controller_handle);

        [LibraryImport(DllName, EntryPoint = "GipSynthEx_Connect")]
        public static partial int Connect(ulong controller_handle);

        [LibraryImport(DllName, EntryPoint = "GipSynthEx_ConnectEx")]
        public static partial int ConnectExNative(ulong controller_handle, ReadOnlySpan<byte> arrival, int arrival_size, ReadOnlySpan<byte> metadata, int metadata_size);

        public static int ConnectEx(ulong controller_handle, ReadOnlySpan<byte> arrival, ReadOnlySpan<byte> metadata)
        {
            return ConnectExNative(controller_handle, arrival, arrival.Length, metadata, metadata.Length);
        }

        [LibraryImport(DllName, EntryPoint = "GipSynthEx_SendReport")]
        public static partial int SendReportNative(ulong controller_handle, int report_type, ReadOnlySpan<byte> report_buf, int report_size);

        public static int SendReport(ulong controller_handle, ReadOnlySpan<byte> report_buf)
        {
            return SendReportNative(controller_handle, 0, report_buf, report_buf.Length);
        }

        [LibraryImport(DllName, EntryPoint = "GipSynthEx_Disconnect")]
        public static partial int Disconnect(ulong controller_handle);

        [LibraryImport(DllName, EntryPoint = "GipSynthEx_RemoveController")]
        public static partial int RemoveController(ulong controller_handle);
    }
}
