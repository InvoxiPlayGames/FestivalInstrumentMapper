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
            _readThread = new Thread(ReadThread);
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
                    _controller.SendData(gipReport);

                    // We use an unused bit in the GIP report to indicate the guide button,
                    // which tells us to stop reading - we also check if Select+Start are held
                    if ((gipReport[0] & 0x02) != 0 || (gipReport[0] & 0x0C) == 0x0C)
                        _shouldStop = true;

                    Thread.Yield();
                }
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
