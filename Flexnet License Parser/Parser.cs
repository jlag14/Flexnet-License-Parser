using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

namespace LicenseParser
{
    // This class processes the user's input text for the LicenseParser file and handles the parsing of the XML license lookup file.
    // Note: only handles preprocessing of input text -- does not actually do any documentation/validation/cleaning.
    public class Parser
    {
        public ArrayList Parse(String licenseSrc)                                      
        {
            int licLen = 0;
            int stPtr = 0;  // Start position pointer
            int eolPtr = 0; // EOL pointer
            int readLen = 0; // read length
            Boolean eof = false;
            String line;
            //      String[] result;
            ArrayList licLines = new ArrayList();
            // get lenth of licenseSrc
            licLen = licenseSrc.Length;
            // Does the source have any content?
            if (licLen > 0)
            {
                // loop through lines of src looking for EOLs or end of src
                // get the first end point
                eolPtr = licenseSrc.IndexOf(Environment.NewLine, eolPtr);

                // check that there is an endpoint and we are not past the end of the file length
                while (!eof)
                {
                    // put each line into an array item
                    // get the eol pointer
                    if (eolPtr != -1)
                    {
                        eolPtr = licenseSrc.IndexOf(Environment.NewLine, eolPtr);
                    }

                    /* read a line from the source file
                     * the read length = EOL position - start position
                     * if there is no EOL at the end of the source, use the source length instead
                    */
                    if (eolPtr == -1)
                    {
                        readLen = licLen - stPtr;
                        eof = true;
                    }
                    else
                    {
                        readLen = eolPtr - stPtr;
                    }

                    line = licenseSrc.Substring(stPtr, readLen);

                    // Check that the line is not an simple EOL itself, if not add it to the array
                    //if (line != Environment.NewLine && line != "")
                    //{
                    // Add the line to our array
                    licLines.Add(line);
                    //}
                    // Move the EOL pointer to the next start point (assume Windows /r/n or two chars)
                    eolPtr = eolPtr + 2;
                    // Move the start pointer to the next start point
                    stPtr = eolPtr;
                }
                // Convert ArrayList to an array of String and return
                //result = (String[])licLines.ToArray(typeof(string));
            }
            else
            {
                licLines.Add("No data found");
            }

            return licLines;
        }

        // PLEASE ADD FILE NOT FOUND EXCEPTION CONTROL
        public ArrayList ParseXML()
        {
            ArrayList result = new ArrayList();
            XmlDocument doc = new XmlDocument();

            // make sure XML loads before trying to parse it
            try
            {
                doc.Load(Form2.LicenseMetaXMLPath);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode childnode in node)
                    {
                        string text = childnode.InnerText;
                        result.Add(text);
                    }
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                // Do nothing, just pass the empty result to LicenseParser, where we'll throw a special exception if we have
                // an empty license list
            }
            // Apparently this exception is getting thrown as opposed to FileNotFound when the XML is missing
            catch (System.ArgumentException e)
            {
                // Do nothing, just pass the empty result to LicenseParser, where we'll throw a special exception if we have
                // an empty license list
            }
            // If there was any other problem opening the XML, still continue with our standard recovery technique, but
            // also print the error and exception type to the console so we can add a catch for it
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " | my type is " + e.GetType().ToString());
            }
            return result;
        }

        public ArrayList Licenses()
        {
            ArrayList licenses = new ArrayList();
            ArrayList z = ParseXML();
            if (z.Count > 0)
            {
                for (int i = 0; i < z.Count; i += 2)
                {
                    License lic = new License(z[i].ToString(), z[i + 1].ToString());
                    licenses.Add(lic);
                }
            }
            return licenses;
        }
    }
}
