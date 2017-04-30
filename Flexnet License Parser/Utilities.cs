using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LicenseParser
{
    // Class which contains utility methods for use during parsing
    public static class Utilities
    {
        // Grabs a license chunk by looping until an empty line or eof and returns the resulting text block.
        // ar should be the list of lines in our input file as handed to the LicenseParser for CleanedLic.
        // THIS METHOD NEEDS TO BE CHANGED, SEE COMMENTS ON ITS USAGE IN LicenseParser.cs
        public static String CheckEnd(String line, int index, ArrayList ar)
        {
            String dest = "";
            while (index < ar.Count && !String.IsNullOrWhiteSpace(ar[index].ToString()))
            {
                dest += ar[index].ToString() + Environment.NewLine;
                index++;
            }
            LicenseParser.newIndex = index;
            return dest;
        }
    }
}
