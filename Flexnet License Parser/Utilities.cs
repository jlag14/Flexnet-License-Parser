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
        // Grabs a license chunk by looping until an empty line, eof, or another license is hit,
        // and returns the resulting text block.
        // "ar" should be the list of lines in our input file as handed to the LicenseParser for CleanedLic.
        // "index" should be the # line the parser is currently on ("i" in the overall lines loop)
        public static String CheckEnd(int index, ArrayList ar)
        {
            String dest = ""; // text output of "license block"
            String initialLine = ar[index].ToString(); // grab the first line, or leading line, in this block
            int quoteCount = 0; // number of quotes we find in our block; used for validation
            int featureCount = 0; // number of INCREMENT/PACKAGE lines we expect to see based on our leading line

            // Increment licenses shouldn't have any more elements; packages have one increment
            if (initialLine.Contains("INCREMENT"))
            {
                featureCount = 1;
            }
            else if (initialLine.Contains("PACKAGE"))
            {
                featureCount = 2;
            }
            // loop until we go off the end, hit an empty line, hit another license, or hit our 10 quote quota
            while (index < ar.Count && !String.IsNullOrWhiteSpace(ar[index].ToString()))
            {
                // this can either mean we're on the first line, first increment (in package case),
                // or that we've hit the next license
                if (ar[index].ToString().Contains("INCREMENT") || ar[index].ToString().Contains("PACKAGE"))
                {
                    // featureCount is tailored above to the exact number of increment/package lines we expect to find in a
                    // license; if we drop below 0, we're on a new license
                    featureCount--;
                    if(featureCount < 0)
                    {
                        break;
                    }
                }
                // assuming we're in the correct license, count the quotes for validation
                foreach(char c in ar[index].ToString())
                {
                    if (c == '\"')
                    {
                        quoteCount++;
                    }
                }
                // add the text to our aggregate "license block" and try the next line
                dest += ar[index].ToString() + Environment.NewLine;
                index++;
            }
            // validate block - check for unmatched quotes
            if (quoteCount % 2 != 0)
            {
                throw new InvalidLicenseException("Error: uneven quotes found at line " + index +
                            ". The main line of the block was:" + Environment.NewLine + initialLine);
            }
            // move the parser's line point
            LicenseParser.newIndex = index;
            return dest;
        }
    }
}
