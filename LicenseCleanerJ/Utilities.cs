using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LicenseCleaner
{
    public static class Utilities
    {
        public static String CheckEnd(String line, int index, ArrayList ar)
        {
            String dest = "";
            while (index < ar.Count && !String.IsNullOrWhiteSpace(ar[index].ToString()))
            {
                dest += ar[index].ToString() + Environment.NewLine;
                index++;
            }
            LicenseCleaner.newIndex = index;
            return dest;
        }
    }
}
