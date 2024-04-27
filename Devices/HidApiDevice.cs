using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private HidDeviceStream _stream;
        private bool _shouldStop = false;
        private bool _isRunning = false;
        private SyntheticController? _controller = null;


        public HidApiDevice(HidDeviceStream device)
        {
            _stream = device;
        }

        public HidApiDeviceType GetDeviceType()
        {
            if (_stream.VendorId == 0x1209 && _stream.ProductId == 0x2882)
            {
                if (_stream.Revision == 0x0400)
                    return HidApiDeviceType.Santroller_RB;
                if (_stream.Revision == 0x0300)
                    return HidApiDeviceType.Santroller_GH;
            }

            if (_stream.VendorId == 0x12BA)
            {
                if (_stream.ProductId == 0x0200)
                    return HidApiDeviceType.PS3_RB;
                if (_stream.ProductId == 0x0100)
                    return HidApiDeviceType.PS3_GH;
            }

            if (_stream.VendorId == 0x1BAD && (_stream.ProductId == 0x0004 || _stream.ProductId == 0x3010))
                return HidApiDeviceType.Wii_RB;

            if (_stream.VendorId == 0x0E6F && (_stream.ProductId == 0x0173 || _stream.ProductId == 0x024A))
                return HidApiDeviceType.PS4_RB_PDP;

            if (_stream.VendorId == 0x0738 && _stream.ProductId == 0x8261)
                return HidApiDeviceType.PS4_RB_MadCatz;

            return HidApiDeviceType.Unknown;
        }

        public override string ToString()
        {
            string device_name = GetDeviceType() switch
            {
                HidApiDeviceType.Wii_RB => "Wii Rock Band Guitar",
                HidApiDeviceType.PS3_RB => "PS3 Rock Band Guitar",
                HidApiDeviceType.PS3_GH => "PS3 Guitar Hero Guitar",
                HidApiDeviceType.PS4_RB_MadCatz => "PS4 Stratocaster",
                HidApiDeviceType.PS4_RB_PDP => "PS4 Jaguar/Riffmaster",
                HidApiDeviceType.Santroller_RB or
                HidApiDeviceType.Santroller_GH => "Santroller Guitar",
                _ => $"Unknown - {_stream.VendorId:X4}:{_stream.ProductId:X4}:{_stream.Revision:X4}",
            };
            return $"{device_name} ({_stream.Serial})";
        }

        public void OpenDevice()
        {
            _stream.Open(exclusive: false);
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
            byte[] hidreport = new byte[27];
            _isRunning = true;
            while (true)
            {
                if (!_stream.Read(hidreport))
                    break;

                ToGip.PS3Wii_RB(hidreport, gipreport);
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
            byte[] hidreport = new byte[27];
            _isRunning = true;
            while (true)
            {
                if (!_stream.Read(hidreport))
                    break;

                ToGip.PS3_GH(hidreport, gipreport);
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
            byte[] hidreport = new byte[78];
            _isRunning = true;
            while (true)
            {
                if (!_stream.Read(hidreport))
                    break;

                ToGip.PS4_RB(hidreport, gipreport);
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
            byte[] hidreport = new byte[27];
            _isRunning = true;
            while (true)
            {
                if (!_stream.Read(hidreport))
                    break;

                ToGip.Santroller_RB(hidreport, gipreport);
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
            byte[] hidreport = new byte[27];
            _isRunning = true;
            while (true)
            {
                if (!_stream.Read(hidreport))
                    break;

                ToGip.Santroller_GH(hidreport, gipreport);
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
