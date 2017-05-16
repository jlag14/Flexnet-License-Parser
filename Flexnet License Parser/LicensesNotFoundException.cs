using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenseParser
{
    // Exception which is thrown when our XML lookup file is not found
    class LicensesNotFoundException : Exception
    {
        public LicensesNotFoundException()
        {
        }

        public LicensesNotFoundException(string message)
            : base(message)
        {
        }

        public LicensesNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
