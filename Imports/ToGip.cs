using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper
{
    internal class ToGip
    {
        [DllImport("PlasticBandToGip.dll", EntryPoint = "PS3Wii_RockBand_ToGip")]
        public static extern void PS3Wii_RB(byte[] ps3rb_buf, byte[] gip_buf);

        [DllImport("PlasticBandToGip.dll", EntryPoint = "PS3_GuitarHero_ToGip")]
        public static extern void PS3_GH(byte[] ps3gh_buf, byte[] gip_buf);

        [DllImport("PlasticBandToGip.dll", EntryPoint = "PS4_RockBand_ToGip")]
        public static extern void PS4_RB(byte[] ps4rb_buf, byte[] gip_buf);

        [DllImport("PlasticBandToGip.dll", EntryPoint = "Santroller_RockBand_ToGip")]
        public static extern void Santroller_RB(byte[] san_buf, byte[] gip_buf);

        [DllImport("PlasticBandToGip.dll", EntryPoint = "Santroller_GuitarHero_ToGip")]
        public static extern void Santroller_GH(byte[] san_buf, byte[] gip_buf);
    }
}
