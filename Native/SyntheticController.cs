using System.Net.Http.Headers;

namespace FestivalInstrumentMapper
{
    internal class SyntheticController : IDisposable
    {
        private ulong _controllerHandle;
        private byte[]? _arrival = null;
        private byte[]? _metadata = null;

        public SyntheticController()
        {
            int rval = GipSyntheticEx.CreateController(0, ref _controllerHandle);
            if (rval != 0)
                throw new Exception($"Failed to create synthetic controller. (HRESULT: {rval:X8})");
        }

        ~SyntheticController()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            int rval = GipSyntheticEx.RemoveController(_controllerHandle);
            if (rval != 0)
                throw new Exception($"Failed to remove synthetic controller. (HRESULT: {rval:X8})");
        }

        public void SetData(byte[]? arrival, byte[]? metadata)
        {
            _arrival = arrival;
            _metadata = metadata;
        }

        public void Connect()
        {
            int rval = 0;
            if (_arrival != null && _metadata != null)
            {
                rval = GipSyntheticEx.ConnectEx(_controllerHandle, _arrival, _metadata);
            }
            else
            {
                rval = GipSyntheticEx.Connect(_controllerHandle);
            }

            if (rval != 0)
                throw new Exception($"Failed to connect synthetic controller. (HRESULT: {rval:X8})");
        }

        public void Disconnect()
        {
            int rval = GipSyntheticEx.Disconnect(_controllerHandle);
            if (rval != 0)
                throw new Exception($"Failed to disconnect synthetic controller. (HRESULT: {rval:X8})");
        }

        public void SendData(ReadOnlySpan<byte> report)
        {

            int rval = GipSyntheticEx.SendReport(_controllerHandle, report);

            if (rval != 0)
                throw new Exception($"Failed to send report. (HRESULT: {rval:X8})");
        }
    }
}
