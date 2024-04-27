using System.Runtime.InteropServices;

namespace FestivalInstrumentMapper
{
    internal static partial class ToGip
    {
        private const string DllName = "PlasticBandToGip.dll";

        [LibraryImport(DllName, EntryPoint = "PS3Wii_RockBand_ToGip")]
        public static partial void PS3Wii_RB(ReadOnlySpan<byte> ps3rb_buf, Span<byte> gip_buf);

        [LibraryImport(DllName, EntryPoint = "PS3_GuitarHero_ToGip")]
        public static partial void PS3_GH(ReadOnlySpan<byte> ps3gh_buf, Span<byte> gip_buf);

        [LibraryImport(DllName, EntryPoint = "PS4_RockBand_ToGip")]
        public static partial void PS4_RB(ReadOnlySpan<byte> ps4rb_buf, Span<byte> gip_buf);

        [LibraryImport(DllName, EntryPoint = "Santroller_RockBand_ToGip")]
        public static partial void Santroller_RB(ReadOnlySpan<byte> san_buf, Span<byte> gip_buf);

        [LibraryImport(DllName, EntryPoint = "Santroller_GuitarHero_ToGip")]
        public static partial void Santroller_GH(ReadOnlySpan<byte> san_buf, Span<byte> gip_buf);
    }
}
