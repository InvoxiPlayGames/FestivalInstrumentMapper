namespace FestivalInstrumentMapper
{
    internal delegate void ToGipAction(ReadOnlySpan<byte> inputBuffer, Span<byte> gipBuffer);

    internal sealed class MapperThread
    {
        private readonly InstrumentMapperDevice _device;
        private readonly SyntheticController _controller;

        private volatile bool _shouldStop = false;
        private volatile Thread? _readThread = null;

        public bool IsRunning => _readThread != null;

        public bool RemapSelectToTilt = false;

        public MapperThread(InstrumentMapperDevice device, SyntheticController controller)
        {
            _device = device;
            _controller = controller;
        }

        public void Dispose()
        {
            Stop();
            // Let's not take ownership of the device, it can last for more than one run
            // _device.Dispose();
            _controller.Dispose();
        }

        public void Start()
        {
            if (_readThread != null)
                return;

            _device.Open();
            _controller.Connect();

            _shouldStop = false;
            _readThread = new Thread(ReadThread) { IsBackground = true };
            _readThread.Start();
        }

        public void Stop()
        {
            if (_readThread == null)
                return;

            _shouldStop = true;
            _readThread.Join();

            // Automatically done by the thread
            // _readThread = null;
            // _device.Close();
        }

        private void ReadThread()
        {
            try
            {
                Span<byte> inputReport = new byte[_device.GetReadLength()];
                Span<byte> gipReport = new byte[0xE];
                ToGipAction toGip = _device.GetGipConverter();

                while (!_shouldStop)
                {
                    _device.Read(inputReport);
                    toGip(inputReport, gipReport);

                    // We use an unused bit in the GIP report to indicate the guide button,
                    // which tells us to stop reading - we also check if Select+Start are held
                    if ((gipReport[0] & 0x02) != 0 || (gipReport[0] & 0x0C) == 0x0C)
                    {
                        _shouldStop = true;
                        gipReport[0] = 0x00; // last input shouldn't be sending buttons
                    }

                    // A set of hacks that remap Select to Tilt and disables tilt
                    if (RemapSelectToTilt)
                    {
                        gipReport[3] = (byte)(((gipReport[0] & 0x08) == 0x08) ? 0xFF : 0x00); // tilt if select is held
                        gipReport[0] &= 0xF7; // deselect select
                    }
                    _controller.SendData(gipReport);

                    Thread.Yield();
                }
            }
            catch (Exception ex)
            {
                string errorFile = Program.WriteErrorFile(ex);
                MessageBox.Show(
                    $"Caught an unhandled mapping exception:\n\n{ex.GetFirstLine()}\n\nPlease send the error log '{errorFile}' to the devs.",
                    "Mapping Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            finally
            {
                _controller.Disconnect();
                _device.Close();
                _readThread = null;
            }
        }
    }
}
