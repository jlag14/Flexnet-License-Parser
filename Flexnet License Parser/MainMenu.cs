using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Collections;

namespace LicenseParser
{
    // This is the main form which the user interacts with. This class contains the event handlers for all
    // the various buttons and actions the user can perform on the form.
    public partial class MainMenu : Form
    {
        private String licenseFileName = ""; // stores name of file which was opened for default save name
        private string cleanFile = ""; // stores parsed text in block form
        private ArrayList manipulatedFile = new ArrayList(); // stores processed text from InputParser to pass to LicenseParser
        private ArrayList keepThese = new ArrayList(); // stores list of lines of parsed text
        private LicenseParser parser = new LicenseParser(); // used to actually execute parsing

        // Constructor called when the program begins
        public MainMenu()
        {
            InitializeComponent();
            MinimizeBox = true;
            MaximizeBox = true;
            PrefsForm.StartUp();
        }

        // Simple method to change the status message shown in the MainMenu in the lower left 
        // after an action is completed
        private void DisplayStatus(string message)
        {
            statusLabel.Text = message;
        }

        // Simple method to display an error message
        public static void DisplayFailure(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK);
        }

        // Creates a default Windows open window and writes the data from the selected file 
        // into the input text box when the Open button is pressed. 
        // The name of the file is stored in licenseFileName for later use in saving.
        private void open_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "License Files | *.lic|Text Files | *.txt";
            openDialog.ShowDialog();

            // Make sure user selected a file and didn't just move on with an empty name
            if (!string.IsNullOrEmpty(openDialog.FileName))
            {
                using (StreamReader reader = new StreamReader(openDialog.FileName))
                {
                    rawFile.Text = reader.ReadToEnd();
                    licenseFileName = openDialog.SafeFileName;
                    reader.Close();
                }
                DisplayStatus("File opened.");
            }
        }

        // Event handler for Save button click
        private void save_Click_1(object sender, EventArgs e)
        {
            // Create a save dialog with a few custom ease-of-use conditions
            // Save to user's documents by default
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "lic";
            saveDialog.AddExtension = true;
            saveDialog.FileName = "Parsed_" + licenseFileName;
            saveDialog.InitialDirectory = Environment.SpecialFolder.UserProfile + "\\Documents\\";
            saveDialog.OverwritePrompt = true;
            saveDialog.ValidateNames = true;
            saveDialog.Filter = "License Files | *.lic";
            saveDialog.ShowDialog();

            // cleanedFile is the output text box containing the entirety of our output text
            using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
            {
                writer.WriteLine(cleanedFile.Text);
            }
            DisplayStatus("Parsed file saved.");
        }

        // Event handler for Parse button click
        private void parse_Click(object sender, EventArgs e)
        {
            // Get input text and reset parser variables
            manipulatedFile = InputParser.Parse(rawFile.Text);
            FlexNetWords.ResetReservedWords();
            cleanFile = "";
            cleanedFile.Text = "";

            // Attempt to clean file
            try
            {
                keepThese = parser.CleanedLic(manipulatedFile);
            }
            // Handle XML lookup file not being found in the specified location (or not having a set location)
            catch (LicensesNotFoundException lnfe)
            {
                var result = MessageBox.Show(lnfe.Message + " Would you like to set the file path for the XML lookup file now?" +
                    " The path can be set at any time via Edit > Preferences, but you will not be able to parse any files" +
                    " without having a valid XML file path set. If you would like more details, please see the help link " +
                    "under Help > Help Documentation.",
                    "File Could Not Be Cleaned", MessageBoxButtons.YesNo);

                // Let user immediately specify XML location if he/she wants to
                if (result == DialogResult.Yes)
                {
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "XML Files | *.xml";
                    openDialog.ShowDialog();
                    if (!string.IsNullOrEmpty(openDialog.FileName))
                    {
                        PrefsForm.SetXML(openDialog.FileName);
                        DisplayStatus("XML selected.");
                    }
                }
                return;
            }
            // Handle an invalid license being found in the license file (e.g. missing a quote)
            catch (InvalidLicenseException ile)
            {
                var result = MessageBox.Show(ile.Message, "Invalid License File", MessageBoxButtons.OK);
            }

            // Process the parsed lines into one output text block
            for (int pos = 0; pos < keepThese.Count; pos++)
            {
                cleanFile += keepThese[pos] + Environment.NewLine;
                cleanedFile.Text += cleanFile;
                cleanFile = "";
            }
            DisplayStatus("File parsed.");
        }

        // Click event handler for the "Open" item from the "File" menu
        // Essentially identical to open_Click_1
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Create "open file" window
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "License Files | *.lic|Text Files | *.txt";
            openDialog.ShowDialog();

            // Read in file's text, and save the name
            if (!string.IsNullOrEmpty(openDialog.FileName))
            {
                using (StreamReader reader = new StreamReader(openDialog.FileName))
                {
                    rawFile.Text = reader.ReadToEnd();
                    licenseFileName = openDialog.SafeFileName;
                    reader.Close();
                }
                DisplayStatus("File opened.");
            }
        }

        // Event handler for clicking "Save As" under the "File" menu
        private void saveAs_Click(object sender, EventArgs e)
        {
            // Create customized save window
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "lic";
            saveDialog.AddExtension = true;
            saveDialog.FileName = "Parsed_" + licenseFileName;
            saveDialog.InitialDirectory = Environment.SpecialFolder.UserProfile + @"\Documents\";
            saveDialog.OverwritePrompt = true;
            saveDialog.ValidateNames = true;
            saveDialog.Filter = "License Files | *.lic";
            saveDialog.ShowDialog();

            // Save output text
            using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
            {
                writer.WriteLine(cleanedFile.Text);
            }
            DisplayStatus("Parsed file saved.");
        }

        // Event handler for X button in upper right being clicked
        private void exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler called when Cut is selected / hotkeyed
        private void cut_Click(object sender, EventArgs e)
        {
            // grab the active form element
            Control ctrl = this.ActiveControl;

            // just call the Cut method if it's actually a text box
            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Cut();
                }
            }
        }

        // Event handler called when Copy is selected / hotkeyed from Edit menu
        private void copy_Click(object sender, EventArgs e)
        {
            // get the active form element
            Control ctrl = this.ActiveControl;

            // call built-in copy method if text box is selected
            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Copy();
                }
            }
        }

        // Event handler called when Paste is selected / hotkeyed
        private void paste_Click(object sender, EventArgs e)
        {
            // get the active form element
            Control ctrl = this.ActiveControl;

            // call built-in paste method if text box is selected
            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Paste();
                }
            }
        }

        // Event handler called when Undo is selected / hotkeyed
        private void undo_Click(object sender, EventArgs e)
        {
            // get the active form element
            Control ctrl = this.ActiveControl;

            // call built-in undo method if text box is selected
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

        // Event handler called when Help is selected from the Help menu
        private void help_Click(object sender, EventArgs e)
        {
            String helpURL = "https://github.com/jlag14/flexnet-license-parser";
            MessageBox.Show("Additional help documentation can be found at " + helpURL);
        }

        // Event handler called when Select All is selected / hotkeyed
        private void selectAll_Click(object sender, EventArgs e)
        {
            // get the active form element
            Control ctrl = this.ActiveControl;

            // call built-in select all method if text box is selected
            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.SelectAll();
                }
            }
        }

        // Called when the user attempts to exit to main form
        private void Form1_FormClosing(object sender, CancelEventArgs ar)
        {
            var mBox = MessageBox.Show("Are you sure you want to quit?", "Confirm", MessageBoxButtons.YesNo);
            if (mBox == DialogResult.No)
            {
                ar.Cancel = true;
            }
        }

        // Called when the user clicks the Copy button (not the one under the Edit menu)
        private void copyButton_Click(object sender, EventArgs e)
        {
            cleanedFile.SelectAll();
            cleanedFile.Copy();
            DisplayStatus("Parsed license copied to clipboard.");
        }

        // Called when the user selects Preferences via hotkey or the Edit menu
        private void preferences_Click_1(object sender, EventArgs e)
        {
            PrefsForm preferencesForm = new PrefsForm();
            RegistryKey rkHKCU = Registry.CurrentUser.OpenSubKey("Software");

            // Our exception handling will catch a missing subdirectory structure for user preferences
            // even if we don't make this check, but most of the time if there's no MDi key under
            // Software we can assume that this is the user's first time going into preferences, so that
            // should be a good enough check to catch most cases where the user would get the jarring "prefs
            // not found" error output.
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
