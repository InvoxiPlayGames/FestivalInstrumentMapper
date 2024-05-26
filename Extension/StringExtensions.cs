using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper.Extension
{
    public static class StringExtensions
    {
        public static readonly char[] ForbiddenFileNameChars = { 
            '<', '>', ':', '\"', '/', '\\', '|', '?', '*'
        };
        public static readonly string[] ReservedFileNames = {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4"
        };
    }
}
