using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace LicenseCleaner
{
    public static class StarAdder
    {
        public static ArrayList StarItems = new ArrayList();

        public static String AddStars(Object obj)
        {
            String stars = "";
            for (int loop = 0; loop < StarItems.IndexOf(obj) + 1; loop++)
            {
                stars += "*";
            }
            return stars;
        }
    }
}
