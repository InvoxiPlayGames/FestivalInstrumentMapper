using Accessibility;
using System.Security.Cryptography.X509Certificates;

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

        public volatile ControllerMapping ControllerMapping = new();

        private volatile bool threadStopped = false;

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

            while (!threadStopped)
            {
                // wait
            }
            // Automatically done by the thread
            // _readThread = null;
            // _device.Close();
        }

        public class GuitarEventArgs(GuitarState state) : EventArgs
        {
            public GuitarState State = state;
        }
        public event EventHandler<GuitarEventArgs>? BeforeControllerTranslate = null;
        public event EventHandler<GuitarEventArgs>? AfterControllerTranslate = null;

        private void ReadThread()
        {
            try
            {
                Span<byte> inputReport = new byte[_device.GetReadLength()];
                Span<byte> gipReport = stackalloc byte[0xE];
                Span<byte> translatedReport = stackalloc byte[0xE];

                ToGipAction toGip = _device.GetGipConverter();

                GuitarState guitarState = new();

                ControllerMapping controllerMapping = ControllerMapping;

                while (!_shouldStop)
                {
                    for (var i = 0; i < translatedReport.Length; i++)
                        translatedReport[i] = 0;

                    if (ControllerMapping != controllerMapping)
                        controllerMapping = ControllerMapping;

                    _device.Read(inputReport);
                    toGip(inputReport, gipReport);

                    // TODO REMOVE THIS
                    // We use an unused bit in the GIP report to indicate the guide button,
                    // which tells us to stop reading - we also check if Select+Start are held
                    if ((gipReport[0] & 0x02) != 0 || (gipReport[0] & 0x0C) == 0x0C)
                    {
                        _shouldStop = true;
                        gipReport[0] = 0x00; // last input shouldn't be sending buttons
                    }

                    // END OF TODO
                    // guitarState.Reset();

                    guitarState.Deserialize(gipReport);

                    BeforeControllerTranslate?.Invoke(null, new(guitarState));

                    guitarState.Translate(controllerMapping);

                    AfterControllerTranslate?.Invoke(null, new(guitarState));

                    guitarState.Serialize(ref translatedReport);
                    _controller.SendData(translatedReport);

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
                threadStopped = true;
                _controller.Disconnect();
                _device.Close();
                _readThread = null;
            }
        }
    }
}
