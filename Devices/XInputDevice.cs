using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper.Devices
{

    internal class XInputDevice : InstrumentMapperDevice
    {
        private readonly int _playerIndex;
        private readonly XInputCapabilities _capabilities;
        private readonly bool _exists;

        public override bool Exists() {
            if (_exists)
            {
                // only report our existence if we're a guitar
                // regular gamepads only show up here for the sake of ViGEmBus and x360ce
                return _capabilities.SubType == XInputControllerSubType.Guitar ||
                    _capabilities.SubType == XInputControllerSubType.GuitarAlternate ||
                    _capabilities.SubType == XInputControllerSubType.GuitarBass ||
                    _capabilities.SubType == XInputControllerSubType.Gamepad;
            }
            return false;
        }

        public XInputDevice(int playerIndex)
        {
            _playerIndex = playerIndex;
            _exists = XInput.GetCapabilities(playerIndex, out _capabilities) == 0;
        }

        public override string ToString()
        {
            string device_name = _capabilities.SubType switch
            {
                XInputControllerSubType.Guitar => "Xbox 360 Rock Band Guitar",
                XInputControllerSubType.GuitarAlternate => "Xbox 360 Guitar Hero Guitar",
                XInputControllerSubType.Gamepad => "Xbox 360 Gamepad",
                _ => $"Xbox 360 Unsupported",
            };
            return $"{device_name} ({_playerIndex + 1})";
        }

        public override void Open()
        {
            // double check that we can actually read the controller
            if (XInput.GetCapabilities(_playerIndex, out _) != 0)
                throw new Exception($"Xbox 360 instrument with {_playerIndex} has been disconnected!");
        }

        public override void Close()
        {
            // we have nothing to dispose of
        }

        public override ToGipAction GetGipConverter()
        {
            return _capabilities.SubType switch
            {
                XInputControllerSubType.GuitarAlternate or
                XInputControllerSubType.Gamepad => ToGip.XInput_GH,
                XInputControllerSubType.Guitar => ToGip.XInput_RB,
                _ => throw new Exception($"Unhandled XInput subtype {_capabilities.SubType}")
            };
        }

        public override int GetReadLength() => Marshal.SizeOf(typeof(XInputGamepad));

        public override void Read(Span<byte> buffer)
        {
            // Sleep before reading to prevent a delay between read and conversion/send
            Thread.Sleep(1);

            if (XInput.GetStateEx(_playerIndex, out var state) != 0)
                throw new Exception($"Xbox 360 instrument with {_playerIndex} has been disconnected!");

            MemoryMarshal.Write(buffer, state.Gamepad);
        }
    }
}
