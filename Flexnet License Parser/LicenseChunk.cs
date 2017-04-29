using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace LicenseParser
{
    // 
    class LicenseChunk
    {
        String bodyText;
        String featureCode;
        String licenseName;
        String featureType;
        String timeType;
        String expirationDate;
        String numSeats;
        String licenseType;
        ArrayList components = new ArrayList();
        int length = 0;
        String holder = "";

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

        public override String ToString()
        {
            String commentChar = "";
            String headerChar = "";
            String result = "";
                if (Form2.IndentedComments)
                {
                    for (int loop = 0; loop < Form2.IndentSpaces; loop++)
                    {
                        commentChar += " ";
                    }
                }
                commentChar += Form2.CommentChar.ToString();
                headerChar += Form2.HeaderChar.ToString();
                String headerPiece = "" + commentChar;
                String space = "";
                    result += commentChar;
                    for (int i = 0; i < Form2.LeadingCommentSpace; i++)
                    {
                        space += " ";
                    }
                    result += space;
                    if (Form2.AddComments)
                    {
                        result += licenseName;
                        if (Form2.ShowFeatureTypes)
                        {
                            if (featureType != null)
                            {
                                result += " " + featureType;
                            }
                        }
                        if (Form2.ShowLicenseTypes)
                        {
                            result += ", " + timeType;
                            if (timeType.Equals("Temporary"))
                            {
                                result += " (Expires " + expirationDate + ")";
                            }
                        }
                        if (Form2.ShowNumberOfSeats)
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
                        length = result.Length;
                        holder = result;
                        result = "";
                        if (Form2.CommentHeaders)
                        {
                            if (Form2.VariableHeaderLength)
                            {
                                for (int i = 0; i < length; i++)
                                {
                                    headerPiece += headerChar;
                                }
                                result += Environment.NewLine + headerPiece;
                            }
                            else if (Form2.FixedHeaderLength)
                            {
                                for (int i = 0; i < Form2.FixedCommentLength; i++)
                                {
                                    headerPiece += headerChar;
                                }
                                result += Environment.NewLine + headerPiece;
                            }
                        }
                        result += Environment.NewLine + holder;
                        if (Form2.listSubComponents)
                        {
                            foreach (object obj in components)
                            {
                                result += Environment.NewLine + commentChar + space + "    - " + obj.ToString();
                            }
                        }
                        if (Form2.CommentHeaders)
                        {
                            if (Form2.VariableHeaderLength)
                            {
                                result += Environment.NewLine + headerPiece + Environment.NewLine + Environment.NewLine;
                            }
                            else if (Form2.FixedHeaderLength)
                            {
                                result += Environment.NewLine + headerPiece + Environment.NewLine + Environment.NewLine;
                            }
                        }

                    }
                result += bodyText;

            return result;
        }
    }
}
