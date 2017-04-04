//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.IO;
//using Microsoft.Win32;
//using System.Windows.Threading;
//using System.Threading;
//using System.Collections;
//namespace LicenseCleanupJ_V1._0
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        private String licenseFileName = "";
//        private String cleanFile;
//        private ArrayList manipulatedFile = new ArrayList();
//        private bool keepComments = false;
//        private bool serverNameDisplayed = false;
//        private ArrayList keepthese = new ArrayList();

//        public MainWindow()
//        {
//            InitializeComponent();
//        }

        //private void open_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openDialog = new OpenFileDialog();
        //    if (openDialog.ShowDialog().Value)
        //    {
        //        using (StreamReader reader = new StreamReader(openDialog.FileName))
        //        {
        //            uncleanFile.Text = reader.ReadToEnd();
        //            licenseFileName = openDialog.SafeFileName;
        //        }
        //        displayStatus("File opened.");
        //    }
        //}

//        private void clearTop_Click(object sender, RoutedEventArgs e)
//        {
//            uncleanFile.Text = String.Empty;
//            displayStatus("Input file cleared.");
//        }

//        private void clearBottom_Click(object sender, RoutedEventArgs e)
//        {
//            cleanedFile.Text = String.Empty;
//            displayStatus("Output file cleared.");
//        }

//        private void saveCleanFile_Click(object sender, RoutedEventArgs e)
//        {
//            SaveFileDialog saveDialog = new SaveFileDialog();
//            saveDialog.DefaultExt = "lic";
//            saveDialog.AddExtension = true;
//            saveDialog.FileName = "Cleaned_" + licenseFileName;
//            saveDialog.InitialDirectory = @"C:\Users\Joe Lagnese\Documents\";
//            saveDialog.OverwritePrompt = true;
//            saveDialog.Title = "License Cleaner J V1.0";
//            saveDialog.ValidateNames = true;
//            saveDialog.Filter = "Text Files | *.txt|License Files | *.lic";

//            if (saveDialog.ShowDialog().Value)
//            {
//                using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
//                {
//                    writer.WriteLine(cleanFile);
//                }
//                displayStatus("Cleaned file saved.");
//            }
//        }

//        private void cleaner_Click(object sender, RoutedEventArgs e)
//        {
//            cleanFile = "";
//            serverNameDisplayed = false;
//            keepthese = cleanedLic();
//            //String[] licText = (String[])keepthese.ToArray(typeof(string));
//            //String result = "";
//            int start = 0;
//            int pos = 0;
//            while (start * 1000 <= keepthese.Count)
//            {
//                for (pos = (start * 1000); pos < ((start + 1) * 1000); pos++)
//                {
//                    if (pos < keepthese.Count)
//                    {
//                        cleanFile += keepthese[pos] + "\n";
//                    }
//                }
//                cleanedFile.Text += cleanFile;
//                cleanFile = "";
//                start++;
//            }
//            //            cleanedFile.Text = licText.Length.ToString();
//            //foreach (String line in licText)
//            //{
//            //    result += line + Environment.NewLine;
//            //}

//            //cleanedFile.Text = result;

//            displayStatus("File cleaned.");
//        }

//        private void displayStatus(string message)
//        {
//            Action clearStatus = new Action(() => { status.Items.Clear(); });
//            this.Dispatcher.Invoke(clearStatus, DispatcherPriority.ApplicationIdle);
//            Action action = new Action(() => { status.Items.Add(message); });
//            this.Dispatcher.Invoke(action, DispatcherPriority.ApplicationIdle);
//        }

//        private void comments_Click(object sender, RoutedEventArgs e)
//        {
//            if ((bool)comments.IsChecked)
//            {
//                keepComments = true;
//                displayStatus("Comments protected.");
//            }
//            else if (!(bool)comments.IsChecked)
//            {
//                keepComments = false;
//                displayStatus("Comments unprotected.");
//            }
//        }

//        private ArrayList licenseParser(String licenseSrc)
//        {
//            int licLen = 0;
//            int stPtr = 0;  // Start position pointer
//            int eolPtr = 0; // EOL pointer
//            int readLen = 0; // read length
//            Boolean eof = false;
//            String line;
//            //      String[] result;
//            ArrayList licLines = new ArrayList();
//            // get lenth of licenseSrc
//            licLen = licenseSrc.Length;
//            // Does the source have any content?
//            if (licLen > 0)
//            {
//                // loop through lines of src looking for EOLs or end of src
//                // get the first end point
//                eolPtr = licenseSrc.IndexOf(Environment.NewLine, eolPtr);

//                // check that there is an endpoint and we are not past the end of the file length
//                while (!eof)
//                {
//                    // put each line into an array item
//                    // get the eol pointer
//                    if (eolPtr != -1)
//                    {
//                        eolPtr = licenseSrc.IndexOf(Environment.NewLine, eolPtr);
//                    }

//                    /* read a line from the source file
//                     * the read length = EOL position - start position
//                     * if there is no EOL at the end of the source, use the source length instead
//                    */
//                    if (eolPtr == -1)
//                    {
//                        readLen = licLen - stPtr;
//                        eof = true;
//                    }
//                    else
//                    {
//                        readLen = eolPtr - stPtr;
//                    }

//                    line = licenseSrc.Substring(stPtr, readLen);

//                    // Check that the line is not an simple EOL itself, if not add it to the array
//                    if (line != Environment.NewLine && line != "")
//                    {
//                        // Add the line to our array
//                        licLines.Add(line);
//                    }
//                    // Move the EOL pointer to the next start point (assume Windows /r/n or two chars
//                    eolPtr = eolPtr + 2;
//                    // Move the start pointer to the next start point
//                    stPtr = eolPtr;
//                }
//                // Convert ArrayList to an array of String and return
//                //result = (String[])licLines.ToArray(typeof(string));
//            }
//            else
//            {
//                licLines.Add("No data found");
//            }

//            return licLines;
//        }

//        private ArrayList cleanedLic()
//        {
//            ArrayList protectedLines = new ArrayList();
//            manipulatedFile = licenseParser(uncleanFile.Text);
//            int startIndex = 0;
//            int endIndex = 0;

//            foreach (string line in manipulatedFile)
//            {
//                string checkedLine = line.Trim();
//                if (checkedLine.StartsWith("#") || checkedLine.StartsWith("//"))
//                {
//                    if (keepComments == true)
//                    {
//                        protectedLines.Add(line);
//                    }
//                }
//                else if (checkedLine.StartsWith("SERVER") && !serverNameDisplayed)
//                {
//                    string nextLine = manipulatedFile[manipulatedFile.IndexOf(line) + 1].ToString();
//                    if (nextLine.Trim().StartsWith("USE_SERVER"))
//                    {
//                        nextLine = manipulatedFile[manipulatedFile.IndexOf(nextLine) + 1].ToString();
//                        if (nextLine.Trim().StartsWith("VENDOR"))
//                        {
//                            protectedLines.Add(line);
//                            protectedLines.Add(manipulatedFile[manipulatedFile.IndexOf(line) + 1].ToString());
//                            protectedLines.Add(nextLine);
//                            serverNameDisplayed = true;
//                        }
//                    }
//                }

//                else
//                {
//                    if (checkedLine.StartsWith("PACKAGE") || checkedLine.StartsWith("INCREMENT"))
//                    {
//                        startIndex = manipulatedFile.IndexOf(line);
//                        endIndex = startIndex;
//                        protectedLines.Add(manipulatedFile[endIndex]);
//                        while (manipulatedFile[endIndex].ToString().Trim().EndsWith("\\"))
//                        {
//                            endIndex++;
//                            protectedLines.Add(manipulatedFile[endIndex]);
//                        }
//                    }
//                }
//            }
//            return protectedLines;
//        }
//    }
//}
