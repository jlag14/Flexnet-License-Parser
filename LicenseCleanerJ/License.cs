using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenseParser
{
     // Represents a single software "license." A license has a name and a feature code.
    public class License
    {   
        // name and feature code variables
        private String featureCode = "";
        private String licenseName = "";

        // simple constructor; only way to set code and name
        public License(String code, String name)
        {
            featureCode = code;
            licenseName = name;
        }

        // accessors below; mutators not needed since we shouldn't be changing any data after parsing
        public String FeatureCode
        {
            get
            {
                return featureCode;
            }
        }

        public String LicenseName
        {
            get
            {
                return licenseName;
            }
        }
    }
}
