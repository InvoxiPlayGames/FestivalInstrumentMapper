using System.Runtime.InteropServices;

namespace FestivalInstrumentMapper
{
    [Flags]
    public enum XInputButton : ushort
    {
        DpadUp = 0x0001,
        DpadDown = 0x0002,
        DpadLeft = 0x0004,
        DpadRight = 0x0008,
        Start = 0x0010,
        Back = 0x0020,
        LeftThumb = 0x0040,
        RightThumb = 0x0080,
        LeftShoulder = 0x0100,
        RightShoulder = 0x0200,
        Guide = 0x0400,
        A = 0x1000,
        B = 0x2000,
        X = 0x4000,
        Y = 0x8000
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XInputGamepad
    {
        public XInputButton Buttons; // WORD

        public byte LeftTrigger; // BYTE
        public byte RightTrigger; // BYTE

        public short LeftThumbX; // SHORT
        public short LeftThumbY; // SHORT

        public short RightThumbX; // SHORT
        public short RightThumbY; // SHORT
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XInputState
    {
        public uint PacketNumber; // DWORD
        public XInputGamepad Gamepad; // XINPUT_GAMEPAD
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XInputVibration(ushort left, ushort right)
    {
        public ushort LeftMotorSpeed = left; // WORD
        public ushort RightMotorSpeed = right; // WORD
    }

    public enum XInputControllerType : byte
    {
        Gamepad = 1
    }

    public enum XInputControllerSubType : byte
    {
        Unknown = 0,
        Gamepad = 1,
        Wheel = 2,
        ArcadeStick = 3,
        FlightStick = 4,
        DancePad = 5,
        Guitar = 6,
        GuitarAlternate = 7,
        DrumKit = 8,
        GuitarBass = 11,
        Keyboard = 15,
        ArcadePad = 19,
        Turntable = 23,
    }

    [Flags]
    public enum XInputCapabilityFlags : ushort
    {
        None = 0x00,
        ForceFeedback = 0x01,
        Wireless = 0x02,
        Voice = 0x04,
        PluginModules = 0x08,
        NoNavigation = 0x10
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XInputCapabilities
    {
        public XInputControllerType Type; // BYTE
        public XInputControllerSubType SubType; // BYTE
        public XInputCapabilityFlags Flags; // WORD

        public XInputGamepad Gamepad; // XINPUT_GAMEPAD
        public XInputVibration Vibration; // XINPUT_VIBRATION
    }

    public static partial class XInput
    {
        private enum GetCapabilitiesFlags : uint
        {
            Gamepad = 1
        }

        private const string FileName = "xinput1_4.dll";

        [LibraryImport(FileName, EntryPoint = "#2")]
        public static partial int GetState(
            int UserIndex, // DWORD
            out XInputState State // XINPUT_STATE*
        );

        [LibraryImport(FileName, EntryPoint = "#3")]
        public static partial int SetState(
            int UserIndex, // DWORD
            in XInputVibration Vibration // XINPUT_VIBRATION*
        );

        [LibraryImport(FileName, EntryPoint = "#4")]
        private static partial int GetCapabilities(
            int UserIndex, // DWORD
            GetCapabilitiesFlags Flags, // DWORD
            out XInputCapabilities Capabilities // XINPUT_CAPABILITIES*
        );

        public static int GetCapabilities(int UserIndex, out XInputCapabilities Capabilities)
            => GetCapabilities(UserIndex, GetCapabilitiesFlags.Gamepad, out Capabilities);

        [LibraryImport(FileName, EntryPoint = "#100")]
        public static partial int GetStateEx(
            int UserIndex, // DWORD
            out XInputState State // XINPUT_STATE*
        );
    }
}
