using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LicenseCleaner
{
    public class LicenseCleaner
    {
        public static int newIndex = 0;
        public ArrayList CleanedLic(ArrayList parsedFile)
        {
            if (parsedFile.Count > 3)
            {
                ArrayList returnedArray = new ArrayList();
                bool alreadyUsed = false;
                ArrayList lics = new ArrayList();
                ArrayList commentIndexes = new ArrayList();
                lics = Form1.Pars.Licenses();

                ArrayList licenseContent = new ArrayList();

                ArrayList chunks = new ArrayList();
                try
                {
                    while (!FlexNetWords.StartsOK(parsedFile[0].ToString(), parsedFile[1].ToString(), parsedFile[2].ToString()))
                    {
                        if (parsedFile.Count >= 1)
                        {
                            parsedFile.RemoveAt(0);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Form1.displayFailure("This license file does not begin with the mandatory SERVER, USE_SERVER, and VENDOR lines, and is therefore invalid.");
                    return new ArrayList();
                }
                for (int i = 0; i < parsedFile.Count; i++)
                {
                    String line = parsedFile[i].ToString();
                    String checkedLine = line.Trim();
                    //if (checkedLine.Length > LicenseLinesLength && !line.Contains("\\") && !line.Contains("\"") && !checkedLine.StartsWith("#") && !checkedLine.StartsWith("//"))
                    //{
                    //    badLineLocations.Add(manipulatedFile.IndexOf(line) + 1);                           // if the line is longer than the default line length, is not a comment, and does not
                    //}                                                                                      // contain any \s or "s, remember its location for later
                    if (FlexNetWords.StartsWithComment(checkedLine))
                    {
                        if (Form2.KeepComments)                                               //protects comments if comments if checkbox is clicked
                        {
                            chunks.Add(line);
                        }
                    }
                    else if (FlexNetWords.StartsWithReserved(checkedLine))                      // ensures only one copy of certain keywords exists. Important area for future code softening.
                    {
                        chunks.Add(line);
                    }

                    else
                    {
                        if (Form2.KeepBreaks)
                        {
                            if (String.IsNullOrWhiteSpace(line))
                            {
                                chunks.Add(line);
                            }
                        }
                        if (checkedLine.StartsWith("PACKAGE") || checkedLine.StartsWith("INCREMENT"))
                        {
                            String text = "";
                            String licName = "";
                            String featCode = "";
                            String licType = "";
                            String featureType = "";
                            String timeType = "";
                            String expirationDate = "";
                            String numSeats = "";
                            ArrayList comps = new ArrayList();
                            if (checkedLine.StartsWith("PACKAGE"))
                            {
                                licType = "PACKAGE";
                            }
                            else if (checkedLine.StartsWith("INCREMENT") && !checkedLine.StartsWith("INCREMENT PLIST"))
                            {
                                licType = "INCREMENT";
                            }
                            else if (checkedLine.StartsWith("INCREMENT PLIST"))
                            {
                                licType = "INCREMENT PLIST";
                            }

                            alreadyUsed = false;
                            text += Utilities.CheckEnd(line, i, parsedFile);

                            foreach (License license in lics)
                            {
                                if (line.Contains(license.FeatureCode))
                                {
                                    if (line.Contains("COMPONENT"))
                                    {
                                        if (line.IndexOf(license.FeatureCode) < line.IndexOf("COMPONENT"))
                                        {
                                            licName = license.LicenseName;
                                            featCode = license.FeatureCode;
                                            foreach (License l in Form1.licensesFound)
                                            {
                                                if (license.LicenseName.Equals(l.LicenseName))
                                                {
                                                    alreadyUsed = true;
                                                }
                                            }
                                            if (alreadyUsed == false)
                                            {
                                                Form1.licensesFound.Add(license);
                                            }

                                        }
                                    }
                                    else
                                    {
                                        licName = license.LicenseName;
                                        featCode = license.FeatureCode;
                                        foreach (License l in Form1.licensesFound)
                                        {
                                            if (license.LicenseName.Equals(l.LicenseName))
                                            {
                                                alreadyUsed = true;
                                            }
                                        }
                                        if (alreadyUsed == false)
                                        {
                                            Form1.licensesFound.Add(license);
                                        }
                                    }
                                }
                                if (parsedFile[i + 1].ToString().Contains(license.FeatureCode))
                                {
                                    if (parsedFile[i + 1].ToString().Contains("\"") && line.Contains("COMPONENT"))
                                    {
                                        comps.Add(license.LicenseName);
                                    }
                                }
                            }
                            if (licName.Equals(""))
                            {
                                licName = "Unknown License";
                            }
                            if (text.Contains("INCREMENT PLIST"))
                            {
                                if (!Form1.Plist)
                                {
                                    Form1.Plist = true;
                                }
                                else
                                {
                                    text = text.Remove(text.IndexOf("INCREMENT PLIST"));
                                }
                            }
                            if (checkedLine.StartsWith("PACKAGE"))
                            {
                                commentIndexes.Add(i);
                            }
                            else if (checkedLine.Trim().StartsWith("INCREMENT"))
                            {
                                commentIndexes.Add(i);
                            }
                            if (licType.Equals("PACKAGE"))
                            {
                                featureType = "Subscription Package";
                            }
                            if (text.Contains("permanent"))
                            {
                                timeType = "Permanent";
                            }
                            else if (text.Contains("temporary") || text.Contains("non-extendable"))
                            {
                                timeType = "Temporary";
                            }
                            if (!timeType.Equals("Permanent"))
                            {
                                int dateSpot = text.IndexOf("INCREMENT");
                                if (text.Contains("1.000") && text.IndexOf("1.000", dateSpot) > dateSpot)
                                {
                                    dateSpot = text.IndexOf("1.000", dateSpot);
                                    for (int pos = 0; pos < "01-jan-2000".Length; pos++)
                                    {
                                        expirationDate += text[dateSpot + "1.000 ".Length + pos];
                                    }
                                }
                            }
                            if (!expirationDate.Equals("") && text.Contains(expirationDate))
                            {
                                if (text[text.IndexOf(expirationDate) + expirationDate.Length + 1] >= '0' && text[text.IndexOf(expirationDate) + expirationDate.Length + 1] <= '9')
                                {
                                    numSeats += text[text.IndexOf(expirationDate) + expirationDate.Length + 1];
                                }

                            }
                            else if (text.Contains("permanent"))
                            {
                                int index = text.IndexOf("permanent") + "permanent".Length + 1;
                                while (text[index] >= '0' && text[index] <= '9')
                                {
                                    numSeats += text[index];
                                    index++;
                                }
                            }
                            if (text.Contains("COMPONENT"))
                            {
                                String mysteryCode = "";
                                bool added = false;
                                int startIndex = text.IndexOf("COMPONENT");
                                startIndex = text.IndexOf("\"", startIndex) + 1;
                                while (!text[startIndex].ToString().Equals("\""))
                                {
                                    added = false;
                                    mysteryCode = "";
                                    while (!text[startIndex].ToString().Equals(" ") && !text[startIndex].ToString().Equals("\""))
                                    {
                                        mysteryCode += text[startIndex];
                                        startIndex++;
                                    }
                                    if (text[startIndex].ToString().Equals(" "))
                                    {
                                        if (!text[startIndex + 1].ToString().Equals(" ") && !text[startIndex - 1].ToString().Equals(" "))
                                        {
                                            foreach (License lic in lics)
                                            {
                                                if (mysteryCode.Equals(lic.FeatureCode))
                                                {
                                                    if (!comps.Contains(lic.LicenseName))
                                                    {
                                                        comps.Add(lic.LicenseName);
                                                        mysteryCode = lic.LicenseName;
                                                    }
                                                    added = true;
                                                    break;
                                                }
                                            }
                                            if (!added)
                                            {
                                                comps.Add("Unknown License");
                                            }
                                        }
                                        startIndex++;
                                    }
                                    else if (text[startIndex].ToString().Equals("\""))
                                    {
                                        foreach (License lic in lics)
                                        {
                                            if (mysteryCode.Equals(lic.FeatureCode))
                                            {
                                                if (!comps.Contains(lic.LicenseName))
                                                {
                                                    comps.Add(lic.LicenseName);
                                                    mysteryCode = lic.LicenseName;
                                                }
                                                added = true;
                                                break;
                                            }
                                        }
                                        if (!added)
                                        {
                                            comps.Add("Unknown License");
                                        }
                                    }
                                }
                            }
                            ArrayList removes = comps;
                            foreach (String comp in comps)
                            {
                                for (int loop = 0; loop < comps.Count; loop++)
                                {
                                    String otherComp = comps[loop].ToString();
                                    if (comp.ToString().Equals(otherComp.ToString()))
                                    {
                                        removes.Remove(comps.IndexOf(otherComp));
                                    }
                                }
                            }
                            LicenseChunk c = new LicenseChunk(text.Trim(), featCode, licName, featureType, timeType, expirationDate, numSeats, licType, removes);
                            chunks.Add(c);
                            i = newIndex;
                        }
                    }

                }
                return chunks;
            }
            else
            {
                Form1.displayFailure("Error: The file is either blank or too short and cannot be cleaned.");
                return new ArrayList();
            }
                }
        }
    }
