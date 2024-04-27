using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper
{
    internal class GipSyntheticEx
    {
        [DllImport("GipSyntheticEx.dll", EntryPoint = "GipSynthEx_Startup")]
        public static extern int Startup();


        [DllImport("GipSyntheticEx.dll", EntryPoint = "GipSynthEx_CreateController")]
        public static extern int CreateController(int type, ref ulong controller_handle);

        [DllImport("GipSyntheticEx.dll", EntryPoint = "GipSynthEx_Connect")]
        public static extern int Connect(ulong controller_handle);

        [DllImport("GipSyntheticEx.dll", EntryPoint = "GipSynthEx_ConnectEx")]
        public static extern int ConnectExNative(ulong controller_handle, byte[] arrival, int arrival_size, byte[] metadata, int metadata_size);

        public static int ConnectEx(ulong controller_handle, byte[] arrival, byte[] metadata)
        {
            return ConnectExNative(controller_handle, arrival, arrival.Length, metadata, metadata.Length);
        }

        [DllImport("GipSyntheticEx.dll", EntryPoint = "GipSynthEx_SendReport")]
        public static extern int SendReportNative(ulong controller_handle, int report_type, byte[] report_buf, int report_size);

        public static int SendReport(ulong controller_handle, byte[] report_buf)
        {
            return SendReportNative(controller_handle, 0, report_buf, report_buf.Length);
        }

        [DllImport("GipSyntheticEx.dll", EntryPoint = "GipSynthEx_Disconnect")]
        public static extern int Disconnect(ulong controller_handle);

        [DllImport("GipSyntheticEx.dll", EntryPoint = "GipSynthEx_RemoveController")]
        public static extern int RemoveController(ulong controller_handle);
    }
}
