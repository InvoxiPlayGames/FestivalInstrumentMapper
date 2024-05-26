using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vultu.Extensions.Filesystem
{
    public static class NTFS
    {
        public static readonly char[] ForbiddenFileNameCharacters = {
            (char)00, (char)01, (char)02, (char)03, (char)04, (char)05, (char)06, (char)07, (char)08, (char)09,
            (char)10, (char)11, (char)12, (char)13, (char)14, (char)15, (char)16, (char)17, (char)18, (char)19,
            (char)20, (char)21, (char)22, (char)23, (char)24, (char)25, (char)26, (char)27, (char)28, (char)29, 
            (char)30, (char)31,
            '<', '>', ':', '\"', '/', '\\', '|', '?', '*'
        };
        public static readonly string[] ReservedFileNames = {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "PRN1", "PRN2", "PRN3", "PRN4", "PRN5", "PRN6", "PRN7", "PRN8", "PRN9",
        };
    }
}
