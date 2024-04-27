using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper
{
    internal class LibUsbDevice : InstrumentMapperDevice
    {
        public override bool Exists()
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override int GetReadLength()
        {
            throw new NotImplementedException();
        }

        public override ToGipAction GetGipConverter()
        {
            throw new NotImplementedException();
        }

        public override void Read(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }

    }
}
