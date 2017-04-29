using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LicenseCleaner
{
    public static class FlexNetWords
    {
        private static ArrayList reservedWords = new ArrayList() { "SERVER", "USE_SERVER", "VENDOR" };

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

        public static bool StartsWithComment(String line)
        {
            if (line.StartsWith("#") || line.StartsWith(Form2.CommentChar.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ResetReservedWords()
        {
            reservedWords.Clear();
            reservedWords.Add("SERVER");
            reservedWords.Add("USE_SERVER");
            reservedWords.Add("VENDOR");
        }
    }
}
