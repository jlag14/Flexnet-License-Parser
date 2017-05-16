using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenseParser
{
    // Exception which is thrown when an invalid license block is found in our file (currently the only case
    // where this can happen is via unmatched quotes)
    class InvalidLicenseException : Exception
    {
        public InvalidLicenseException()
        {
        }

        public InvalidLicenseException(string message)
            : base(message)
        {
        }

        public InvalidLicenseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
