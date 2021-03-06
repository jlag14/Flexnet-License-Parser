﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace LicenseParser
{
    // Full representation of the text block accomopanying a license "block" in a license file.
    // Essentially, a License and all its accompanying data / characteristics.
    class LicenseChunk
    {
        String bodyText; // store plaintext of license block here
        String featureCode;
        String licenseName;
        // VV POSSIBLY REDUNDANT VV
        String featureType; // full name of the type of subscription the license represents with regards to its license type
        // ^^ POSSIBLY REDUNDANT ^^
        String timeType; // can be "perpetual" for permanent licenses or "term" for extendable/temporary
        String expirationDate; // if temporary
        String numSeats; // number of seats for the license
        String licenseType; // "package", "increment" or "increment plist" depending on the license
        ArrayList components = new ArrayList();

        // Basic constructor
        public LicenseChunk(String text, String fc, String ln, String ft, String tt, String ed, String ns, String lt, ArrayList comps, bool leading = true)
        {
            bodyText = text;
            featureCode = fc;
            licenseName = ln;
            featureType = ft;
            timeType = tt;
            expirationDate = ed;
            numSeats = ns;
            licenseType = lt;
            components = comps;
        }

        // Accessors for data which may be used for printing the full license details out
        public String LicType
        {
            get
            {
                return licenseType;
            }
        }

        public String TimeType 
        {
            get
            {
                return timeType;
            }
            set
            {
                timeType = value;
            }
        }
        public String ExpirationDate 
        {
            get
            {
                return expirationDate;
            }
            set
            {
                expirationDate = value;
            }
        }
        public String NumSeats 
        {
            get
            {
                return numSeats;
            }
            set
            {
                numSeats = value;
            }
        }

        // Allows for LicenseChunks to be directly printed, with header and comment preferences included
        public override String ToString()
        {
            String commentChar = ""; // comment character
            String headerChar = ""; // header character
            String result = ""; // contains the entire output block

            // Print information in the following order:
            // License name, feature type (aka license type), perpetual/term, expiration date, number of seats, 
            if (PrefsForm.AddComments)
            {
                // The following code accesses user preferences from the Preferences form to properly format
                // comments detailing the contents of a License (as selected by the user to display).
                if (PrefsForm.IndentedComments)
                {
                    for (int loop = 0; loop < PrefsForm.IndentSpaces; loop++)
                    {
                        commentChar += " ";
                    }
                }
                commentChar += PrefsForm.CommentChar.ToString();
                headerChar += PrefsForm.HeaderChar.ToString();
                String headerPiece = "" + commentChar; // the header char is the one going across the top/bottom following the comment char
                String space = "";

                result += commentChar;
                for (int i = 0; i < PrefsForm.LeadingCommentSpace; i++)
                {
                    space += " ";
                }
                result += space;

                result += licenseName;
                if (PrefsForm.ShowFeatureTypes)
                {
                    if (featureType != null)
                    {
                        result += " " + featureType;
                    }
                }
                if (PrefsForm.ShowLicenseTypes)
                {
                    result += ", " + timeType;
                    if (timeType.Equals("Temporary"))
                    {
                        result += " (Expires " + expirationDate + ")";
                    }
                }
                if (PrefsForm.ShowNumberOfSeats)
                {
                    if (!String.IsNullOrEmpty(numSeats))
                    {
                        if (numSeats.Equals("1"))
                        {
                            result += ", " + numSeats + " seat";
                        }
                        else
                        {
                            result += ", " + numSeats + " seats";
                        }
                    }
                    else
                    {
                        result += ", Unknown # seats";
                    }
                }

                // Store info text while we add in header / footer lines,
                // as well as license components (if requested);
                // this section could possibly be prepended to the section building the bulk of the output text above.
                // Either way this could probably be optimized.
                int length = result.Length;
                String holder = result;
                result = "";

                // add top line
                if (PrefsForm.CommentHeaders)
                {
                    if (PrefsForm.VariableHeaderLength)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            headerPiece += headerChar;
                        }
                        result += Environment.NewLine + headerPiece;
                    }
                    else if (PrefsForm.FixedHeaderLength)
                    {
                        for (int i = 0; i < PrefsForm.FixedCommentLength; i++)
                        {
                            headerPiece += headerChar;
                        }
                        result += Environment.NewLine + headerPiece;
                    }
                }
                result += Environment.NewLine + holder + Environment.NewLine;
                
                // check if components should be listed; indent them in a list
                if (PrefsForm.ListSubComponents)
                {
                    foreach (object obj in components)
                    {
                        result += commentChar + space + "    - " + obj.ToString() + Environment.NewLine;
                    }
                }

                // add footer line
                if (PrefsForm.CommentHeaders)
                {
                    if (PrefsForm.VariableHeaderLength)
                    {
                        result += headerPiece + Environment.NewLine + Environment.NewLine;
                    }
                    else if (PrefsForm.FixedHeaderLength)
                    {
                        result += headerPiece + Environment.NewLine + Environment.NewLine;
                    }
                }

            }

            // This summary is prepended to the raw text originally from the license file
            result += bodyText;

            return result;
        }
    }
}
