using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenseCleaner
{
    public class License
    {
        private String featureCode = "";
        private String licenseName = "";

        public License(String code, String name)
        {
            featureCode = code;
            licenseName = name;
        }

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
