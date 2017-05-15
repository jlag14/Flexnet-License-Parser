using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LicenseParser
{
    // Defines Flexnet reserved words and defines simple methods for checking their presence.
    public static class FlexNetWords
    {
        // Current reserved words are SERVER, USE_SERVER, and VENDOR.
        // The server line should have a server address followed by a hex code.
        // USE_SERVER should follow, with nothing else on the line.
        // VENDOR should have the name of the vendor (such as adskflex for Autodesk products) and a port # for the connection.
        private static ArrayList reservedWords = new ArrayList() { "SERVER", "USE_SERVER", "VENDOR" };

        // Tests if a given line starts with a Flexnet reserved word, then removes word to prevent duplicates
        public static bool StartsWithReserved(String line)
        {
            foreach (string word in reservedWords)
            {
                if (line.StartsWith(word))
                {
                    reservedWords.Remove(word);
                    return true;
                }
            }
            return false;
        }

        // Used to check if a license file has a legitimate header (SERVER line followed by 
        // USE_SERVER followed by VENDOR line).
        public static bool StartsOK(String line1, String line2, String line3)
        {
            if (line1.Trim().StartsWith("SERVER"))
            {
                if (line2.Trim().StartsWith("USE_SERVER"))
                {
                    if (line3.Trim().StartsWith("VENDOR"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Checks if a line starts with a comment
        public static bool StartsWithComment(String line)
        {
            if (line.StartsWith("#") || line.StartsWith(PrefsForm.CommentChar.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Resets reserved words array; should be called after each time a file is parsed, as reserved words
        // list is cleared out to ensure each only appears once in the file
        public static void ResetReservedWords()
        {
            reservedWords.Clear();
            reservedWords.Add("SERVER");
            reservedWords.Add("USE_SERVER");
            reservedWords.Add("VENDOR");
        }
    }
}
