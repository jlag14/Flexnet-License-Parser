using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Collections;
using System.Xml;

namespace LicenseParser
{
    public partial class Form1 : Form
    {
        private String licenseFileName = "";
        private string cleanFile = "";
        private ArrayList manipulatedFile = new ArrayList();
        public static bool Plist = false;
        public static ArrayList printMe = new ArrayList();
        private ArrayList keepthese = new ArrayList();
        private ArrayList parsedXML = new ArrayList();
        private ArrayList reservedWords = new ArrayList() { "SERVER", "USE_SERVER", "VENDOR" };
        public static Parser Pars = new Parser();
        LicenseParser cleaner = new LicenseParser();

        public Form1()
        {
            InitializeComponent();
            Form2.StartUp();
        }

        private void displayStatus(string message)
        {
            statusLabel.Text = message;
        }

        private void open_Click_1(object sender, EventArgs e)               //creates a default Windows open window and writes the data from the selected file into the input text box when the
        {                                                                   //open button is pressed. The name of the file is stored in licenseFileName, but does not expose the location of the file.
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text Files | *.txt|License Files | *.lic";
            openDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openDialog.FileName))
            {
                using (StreamReader reader = new StreamReader(openDialog.FileName))
                {
                    uncleanFile.Text = reader.ReadToEnd();
                    licenseFileName = openDialog.SafeFileName;
                    reader.Close();
                }
                displayStatus("File opened.");
            }
        }

        private void save_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();               //creates a default Windows save window and populates some default conditions when Save button is clicked
            saveDialog.DefaultExt = "lic";
            saveDialog.AddExtension = true;
            saveDialog.FileName = "Cleaned_" + licenseFileName;
            saveDialog.InitialDirectory = Environment.SpecialFolder.UserProfile + "\\Documents\\";
            saveDialog.OverwritePrompt = true;
            saveDialog.Title = "License Cleaner";
            saveDialog.ValidateNames = true;
            saveDialog.Filter = "Text Files | *.txt|License Files | *.lic";

            saveDialog.ShowDialog();
            using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
            {
                writer.WriteLine(cleanedFile.Text);
            }
            displayStatus("Cleaned file saved.");
        }

        private void clean_Click(object sender, EventArgs e)
        {
            manipulatedFile = Pars.Parse(uncleanFile.Text);
            FlexNetWords.ResetReservedWords();
            cleanFile = "";
            cleanedFile.Text = "";
            keepthese = cleaner.CleanedLic(manipulatedFile);
            if (keepthese.Count >= 1)
            {
                foreach (object obj in printMe)
                {
                    cleanedFile.Text += Environment.NewLine + obj.ToString();
                }
                int start = 0;
                int pos = 0;
                while (start * 1000 <= keepthese.Count)                                     //checks to make sure the loop will not be starting past the end of the file,
                {                                                                           //then uses a for loop to break the ArrayList into chunks of a thousand lines each and places the chunks in a holder string. 
                    for (pos = (start * 1000); pos < ((start + 1) * 1000); pos++)           //(The last chunk will not be 1000 lines, it will be the remainder of lines left after the other chunks.)
                    {                                                                       //Adds a newLine character after each line as the for loop executes. After each chunk is created,
                        if (pos < keepthese.Count)                                          //it is added to the existing text in the output TextBox and the holder string is reset.
                        {
                            cleanFile += keepthese[pos] + Environment.NewLine;
                        }
                    }
                    cleanedFile.Text += cleanFile;
                    cleanFile = "";
                    start++;
                }
                    displayStatus("File cleaned.");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)       //this is the "Open" item from the "File" menu
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openDialog.FileName))
            {
                using (StreamReader reader = new StreamReader(openDialog.FileName))
                {
                    uncleanFile.Text = reader.ReadToEnd();
                    licenseFileName = openDialog.SafeFileName;
                }
                displayStatus("File opened.");
            }
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "lic";
            saveDialog.AddExtension = true;
            saveDialog.FileName = "Cleaned_" + licenseFileName;
            saveDialog.InitialDirectory = @"C:\Users\Joe Lagnese\Documents\";
            saveDialog.OverwritePrompt = true;
            saveDialog.Title = "License Cleaner";
            saveDialog.ValidateNames = true;
            saveDialog.Filter = "Text Files | *.txt|License Files | *.lic";
            saveDialog.ShowDialog();
            using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
            {
                writer.WriteLine(cleanedFile.Text);
            }
            displayStatus("Cleaned file saved.");
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cut_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Cut();
                }
            }
        }

        public static void displayFailure(String message)
        {
            MessageBox.Show(message);
        }

        private void copy_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Copy();
                }
            }
        }

        private void paste_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Paste();
                }
            }
        }

        private void undo_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Undo();
                    tb.ClearUndo();
                }
            }
        }

        private void about_Click(object sender, EventArgs e)        //todo
        {
            String display = "Created 8/5/13";
            MessageBox.Show(display);
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.SelectAll();
                }
            }
        }

        private void Form1_FormClosing(object sender, CancelEventArgs ar)
        {
            //MessageBoxResult key = MessageBox.Show(
            //    "Are you sure you want to quit?",
            //    "Confirm",
            //    MessageBoxButton.YesNo,
            //    MessageBoxImage.Question,
            //    MessageBoxResult.No);
            //e.Cancel = (key == MessageBoxResult.No);
            var mBox = MessageBox.Show("Are you sure you want to quit?", "Confirm", MessageBoxButtons.YesNo);
            if (mBox == DialogResult.No)
            {
                ar.Cancel = true;
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            cleanedFile.SelectAll();
            cleanedFile.Copy();
            displayStatus("Cleaned license copied to clipboard.");
        }

        private void preferences_Click_1(object sender, EventArgs e)
        {
            Form2 preferencesForm = new Form2();
            RegistryKey rkHKCU = Registry.CurrentUser.OpenSubKey("Software");
            if (!rkHKCU.GetSubKeyNames().Contains("MDi"))
            {
                preferencesForm.CreateDefault();
            }
            else
            {
                preferencesForm.Open();
            }
            rkHKCU.Close();
            preferencesForm.ShowDialog();
        }
    }
}
