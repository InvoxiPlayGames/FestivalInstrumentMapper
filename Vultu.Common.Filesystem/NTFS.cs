using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Vultu: I just stole this from my own private lib
// i don't care if you steal it use it for whatever
namespace Vultu.Common.Filesystem
{
    public static class NTFS
    {
        public static readonly char[] ForbiddenFileNameCharacters = {
            '<', '>', ':', '\"', '/', '\\', '|', '?', '*'
        };
        public static readonly string[] ReservedFileNames = {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "PRN1", "PRN2", "PRN3", "PRN4", "PRN5", "PRN6", "PRN7", "PRN8", "PRN9",
        };

        public static bool IsFilenameValid(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                return false;

            if (filename.Length > byte.MaxValue)
                return false;

            string trimmed = filename.Trim();

            if (trimmed.Last() == ' ' || trimmed.Last() == '.') // Filenames cannot end with space or .
                trimmed = trimmed.Substring(0, trimmed.Length - 1);

            if (trimmed.Length == 0)
                return false;

            foreach (var @char in trimmed)
            {
                byte bChar = (byte)@char;
                if (bChar >= 0 && bChar <= 31)
                    return false; // No whitespace / nonprintable ascii

                if (ForbiddenFileNameCharacters.Contains(@char))
                    return false;
            }

            if (ReservedFileNames.Contains(trimmed.ToUpper()))
                return false;

            return true;
        }
    }
}
