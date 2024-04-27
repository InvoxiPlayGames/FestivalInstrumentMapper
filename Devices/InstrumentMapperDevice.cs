namespace FestivalInstrumentMapper
{
    internal abstract class InstrumentMapperDevice : IDisposable
    {
        ~InstrumentMapperDevice()
        {
            Dispose(false);
        }

        public abstract bool Exists();
        public abstract void Open();
        public abstract void Close();

        public abstract int GetReadLength();
        public abstract ToGipAction GetGipConverter();
        public abstract void Read(Span<byte> buffer);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                DisposeManaged();
            DisposeUnmanaged();
        }

        protected virtual void DisposeManaged() {}
        protected virtual void DisposeUnmanaged() {}
    }
}
