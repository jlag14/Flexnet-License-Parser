using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenseParser
{
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
