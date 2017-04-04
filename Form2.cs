using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Collections;

namespace LicenseCleaner
{
    public partial class Form2 : Form
    {
        public static bool ShowFeatureTypes = false;
        public static bool ShowLicenseTypes = false;
        public static bool ShowNumberOfSeats = false;
        public static bool listSubComponents = false;

        public static char CommentChar = '#';
        public static char HeaderChar = '=';
        public static int LeadingCommentSpace = 1;
        public static int IndentSpaces = 4;

        public static bool IndentedComments = false;
        public static bool KeepComments = false;
        public static bool KeepBreaks = false;
        public static bool AddComments = true;
        public static bool CommentHeaders = true;
        public static bool FixedHeaderLength = false;
        public static bool VariableHeaderLength = true;
        public static int FixedCommentLength = 10;

        public Form2()
        {
            InitializeComponent();
        }


        public void CreateDefault()
        {
            RegistryKey rkHKCU = Registry.CurrentUser;
            RegistryKey rkRun;

            ShowFeatureTypes = false;
            ShowLicenseTypes = false;
            ShowNumberOfSeats = false;
            listSubComponents = false;

            CommentChar = '#';
            HeaderChar = '=';
            LeadingCommentSpace = 1;
            IndentSpaces = 4;

            IndentedComments = false;
            KeepComments = false;
            KeepBreaks = false;
            AddComments = true;
            CommentHeaders = true;
            FixedHeaderLength = false;
            VariableHeaderLength = true;
            FixedCommentLength = 10;

            rkRun = recurse(rkHKCU);
            rkRun.SetValue("KeepComments", Form2.KeepComments);
            rkRun.SetValue("KeepBreaks", Form2.KeepBreaks);
            rkRun.SetValue("AddComments", Form2.AddComments);
            rkRun.SetValue("FeatureTypes", Form2.ShowFeatureTypes);
            rkRun.SetValue("LicenseTypes", Form2.ShowLicenseTypes);
            rkRun.SetValue("NumOfSeats", Form2.ShowNumberOfSeats);
            rkRun.SetValue("SubComponents", Form2.listSubComponents);
            rkRun.SetValue("Headers", Form2.CommentHeaders);
            rkRun.SetValue("FixedLength", Form2.FixedHeaderLength);
            rkRun.SetValue("VariableLength", Form2.VariableHeaderLength);
            rkRun.SetValue("FixedNumber", Form2.FixedCommentLength);
            rkRun.SetValue("FixedNumberEnabled", Form2.FixedHeaderLength);
            rkRun.SetValue("HeaderChar", Form2.HeaderChar);
            rkRun.SetValue("CommentChar", Form2.CommentChar);
            rkRun.SetValue("SpaceAfterCommentChar", Form2.LeadingCommentSpace);
            rkRun.SetValue("IndentedComments", Form2.IndentedComments);
            rkRun.SetValue("SpacesInIndent", Form2.IndentSpaces);
            rkRun.SetValue("SpacesInIndentEnabled", Form2.IndentedComments);

            featureTypes.Checked = false;
            licenseTypes.Checked = false;
            numberSeats.Checked = false;
            subComponents.Checked = false;
            commentChar.Text = "#";
            headerChar.Text = "=";
            leadingCommentSpace.Value = 1;
            numberOfSpacesPerIndent.Value = 4;
            numberOfSpacesPerIndent.Enabled = false;
            indentedComments.Checked = false;
            comments2.Checked = false;
            linebreaks2.Checked = false;
            addComments.Checked = true;
            headers.Checked = true;
            fixedLength.Checked = false;
            variableLength.Checked = true;
            fixedNumber.Visible = false;
            fixedNumber.Value = 10;

            rkHKCU.Close();
            rkRun.Close();
        }

        public static void StartUp()
        {
            try
            {
                RegistryKey rkHKCU = Registry.CurrentUser;
                RegistryKey key = originalRecurse(rkHKCU);
                RegistryKey rkRun = key;
                KeepComments = Convert.ToBoolean(rkRun.GetValue("KeepComments").ToString());
                KeepBreaks = Convert.ToBoolean(rkRun.GetValue("KeepBreaks").ToString());
                AddComments = Convert.ToBoolean(rkRun.GetValue("AddComments").ToString());
                ShowFeatureTypes = Convert.ToBoolean(rkRun.GetValue("FeatureTypes").ToString());
                ShowLicenseTypes = Convert.ToBoolean(rkRun.GetValue("LicenseTypes").ToString());
                ShowNumberOfSeats = Convert.ToBoolean(rkRun.GetValue("NumOfSeats").ToString());
                listSubComponents = Convert.ToBoolean(rkRun.GetValue("SubComponents").ToString());
                CommentHeaders = Convert.ToBoolean(rkRun.GetValue("Headers").ToString());
                FixedHeaderLength = Convert.ToBoolean(rkRun.GetValue("FixedLength").ToString());
                VariableHeaderLength = Convert.ToBoolean(rkRun.GetValue("VariableLength").ToString());
                FixedCommentLength = Convert.ToInt32(rkRun.GetValue("FixedNumber").ToString());
                HeaderChar = (char)rkRun.GetValue("HeaderChar").ToString()[0];
                CommentChar = (char)rkRun.GetValue("CommentChar").ToString()[0];
                LeadingCommentSpace = Convert.ToInt32(rkRun.GetValue("SpaceAfterCommentChar").ToString());
                IndentedComments = Convert.ToBoolean(rkRun.GetValue("IndentedComments").ToString());
                IndentSpaces = Convert.ToInt32(rkRun.GetValue("SpacesInIndent").ToString());
            }
            catch (NullReferenceException e)
            {
                ShowFeatureTypes = false;
                ShowLicenseTypes = false;
                ShowNumberOfSeats = false;
                listSubComponents = false;

                CommentChar = '#';
                HeaderChar = '=';
                LeadingCommentSpace = 1;
                IndentSpaces = 4;

                IndentedComments = false;
                KeepComments = false;
                KeepBreaks = false;
                AddComments = true;
                CommentHeaders = true;
                FixedHeaderLength = false;
                VariableHeaderLength = true;
                FixedCommentLength = 10;
            }
        }

        public void Open()
        {
            try
            {
                RegistryKey rkHKCU = Registry.CurrentUser;
                RegistryKey key = recurse(rkHKCU);
                RegistryKey rkRun = key;
                comments2.Checked = Convert.ToBoolean(rkRun.GetValue("KeepComments").ToString());
                linebreaks2.Checked = Convert.ToBoolean(rkRun.GetValue("KeepBreaks").ToString());
                addComments.Checked = Convert.ToBoolean(rkRun.GetValue("AddComments").ToString());
                featureTypes.Checked = Convert.ToBoolean(rkRun.GetValue("FeatureTypes").ToString());
                licenseTypes.Checked = Convert.ToBoolean(rkRun.GetValue("LicenseTypes").ToString());
                numberSeats.Checked = Convert.ToBoolean(rkRun.GetValue("NumOfSeats").ToString());
                subComponents.Checked = Convert.ToBoolean(rkRun.GetValue("SubComponents").ToString());
                headers.Checked = Convert.ToBoolean(rkRun.GetValue("Headers").ToString());
                fixedLength.Checked = Convert.ToBoolean(rkRun.GetValue("FixedLength").ToString());
                variableLength.Checked = Convert.ToBoolean(rkRun.GetValue("VariableLength").ToString());
                fixedNumber.Value = Convert.ToInt32(rkRun.GetValue("FixedNumber").ToString());
                fixedNumber.Visible = Convert.ToBoolean(rkRun.GetValue("FixedNumberEnabled").ToString());
                headerChar.Text = rkRun.GetValue("HeaderChar").ToString();
                commentChar.Text = rkRun.GetValue("CommentChar").ToString();
                leadingCommentSpace.Value = Convert.ToInt32(rkRun.GetValue("SpaceAfterCommentChar").ToString());
                indentedComments.Checked = Convert.ToBoolean(rkRun.GetValue("IndentedComments").ToString());
                numberOfSpacesPerIndent.Value = Convert.ToInt32(rkRun.GetValue("SpacesInIndent").ToString());
                if (addComments.Checked)
                {
                    numberOfSpacesPerIndent.Enabled = Convert.ToBoolean(rkRun.GetValue("SpacesInIndentEnabled").ToString());
                }
                else
                {
                    numberOfSpacesPerIndent.Enabled = false;
                }
                leadingCommentSpace.Enabled = addComments.Checked;
                commentContent.Enabled = addComments.Checked;
                headerOptions.Enabled = addComments.Checked;
                indentedComments.Enabled = addComments.Checked;
                headerLengthBox.Enabled = headers.Checked;
                rkRun.Close();

                ShowFeatureTypes = featureTypes.Checked;
                KeepComments = comments2.Checked;
                KeepBreaks = linebreaks2.Checked;
                AddComments = addComments.Checked;
                ShowLicenseTypes = licenseTypes.Checked;
                ShowNumberOfSeats = numberSeats.Checked;
                listSubComponents = subComponents.Checked;
                CommentHeaders = headers.Checked;
                FixedHeaderLength = fixedLength.Checked;
                VariableHeaderLength = variableLength.Checked;
                FixedCommentLength = (int)fixedNumber.Value;
                HeaderChar = (char)headerChar.Text[0];
                CommentChar = (char)commentChar.Text[0];
                IndentSpaces = (int)numberOfSpacesPerIndent.Value;
                IndentedComments = indentedComments.Checked;
                LeadingCommentSpace = (int)leadingCommentSpace.Value;

                key.Close();
                rkHKCU.Close();
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("One or more of the stored values for user preferences was found to be missing from the registry. Preferences have been reset to their default values.");
                this.CreateDefault();
            }
        }

        public void Save()
        {
            RegistryKey rkHKCU = Registry.CurrentUser;
            RegistryKey rkRun = recurse(rkHKCU);
            rkRun.SetValue("KeepComments", comments2.Checked);
            rkRun.SetValue("KeepBreaks", linebreaks2.Checked);
            rkRun.SetValue("AddComments", addComments.Checked);
            rkRun.SetValue("FeatureTypes", featureTypes.Checked);
            rkRun.SetValue("LicenseTypes", licenseTypes.Checked);
            rkRun.SetValue("NumOfSeats", numberSeats.Checked);
            rkRun.SetValue("SubComponents", subComponents.Checked);
            rkRun.SetValue("Headers", headers.Checked);
            rkRun.SetValue("FixedLength", fixedLength.Checked);
            rkRun.SetValue("VariableLength", variableLength.Checked);
            rkRun.SetValue("FixedNumber", fixedNumber.Value);
            rkRun.SetValue("FixedNumberEnabled", fixedNumber.Visible);
            rkRun.SetValue("HeaderChar", headerChar.Text);
            rkRun.SetValue("CommentChar", commentChar.Text);
            rkRun.SetValue("SpaceAfterCommentChar", leadingCommentSpace.Value);
            rkRun.SetValue("IndentedComments", indentedComments.Checked);
            rkRun.SetValue("SpacesInIndent", numberOfSpacesPerIndent.Value);
            rkRun.SetValue("SpacesInIndentEnabled", numberOfSpacesPerIndent.Enabled);

            
            rkHKCU.Close();
            rkRun.Close();
            Form1.displayFailure("Preferences saved.");
        }

        private void comments2_Click(object sender, EventArgs e)
        {
            if (comments2.Checked)
            {
                Form2.KeepComments = true;
            }
            else
            {
                Form2.KeepComments = false;
            }
            
        }

        private void linebreaks2_Click(object sender, EventArgs e)
        {
            if (linebreaks2.Checked)
            {
                Form2.KeepBreaks = true;
            }
            else
            {
                Form2.KeepBreaks = false;
            }
            
        }

        private void addComments_Click(object sender, EventArgs e)
        {
            if (addComments.Checked)
            {
                Form2.AddComments = true;
                headerOptions.Enabled = true;
                commentContent.Enabled = true;
                if (indentedComments.Checked)
                {
                    numberOfSpacesPerIndent.Enabled = true;
                }
                indentedComments.Enabled = true;
                leadingCommentSpace.Enabled = true;
            }
            else
            {
                Form2.AddComments = false;
                headerOptions.Enabled = false;
                commentContent.Enabled = false;
                numberOfSpacesPerIndent.Enabled = false;
                indentedComments.Enabled = false;
                leadingCommentSpace.Enabled = false;
            }
            
        }

        private void fixedNumber_ValueChanged(object sender, EventArgs e)
        {
                Form2.FixedCommentLength = (int)fixedNumber.Value;
                
        }
        private void fixedLength_Click(object sender, EventArgs e)
        {
            if (fixedLength.Checked)
            {
                fixedNumber.Visible = true;
                Form2.FixedHeaderLength = true;
                Form2.VariableHeaderLength = false;
            }
            else
            {
                Form2.FixedHeaderLength = false;
            }
            
        }

        private void variableLength_Click(object sender, EventArgs e)
        {
            if (variableLength.Checked)
            {
                fixedNumber.Visible = false;
                Form2.VariableHeaderLength = true;
                Form2.FixedHeaderLength = false;
            }
            else
            {
                Form2.VariableHeaderLength = false;
            }
            
        }

        private void featureTypes_Click(object sender, EventArgs e)
        {
            if (featureTypes.Checked)
            {
                Form2.ShowFeatureTypes = true;
            }
            else
            {
                Form2.ShowFeatureTypes = false;
            }
            
        }

        private void licenseTypes_Click(object sender, EventArgs e)
        {
            if (licenseTypes.Checked)
            {
                Form2.ShowLicenseTypes = true;
            }
            else
            {
                Form2.ShowLicenseTypes = false;
            }
            
        }

        private void numberSeats_Click(object sender, EventArgs e)
        {
            if (numberSeats.Checked)
            {
                Form2.ShowNumberOfSeats = true;
            }
            else
            {
                Form2.ShowNumberOfSeats = false;
            }
            
        }

        private void subComponents_Click(object sender, EventArgs e)
        {
            if (subComponents.Checked)
            {
                Form2.listSubComponents = true;
            }
            else
            {
                Form2.listSubComponents = false;
            }
            
        }

        private void headers_Click(object sender, EventArgs e)
        {
            if (headers.Checked)
            {
                Form2.CommentHeaders = true;
                headerLengthBox.Enabled = true;
            }
            else
            {
                Form2.CommentHeaders = false;
                headerLengthBox.Enabled = false;
            }
            
        }

        private void headerChar_TextChanged(object sender, EventArgs e)
        {
            if (!headerChar.Text.Equals(""))
            {
                Form2.HeaderChar = headerChar.Text[0];
            }
            else
            {
                Form2.HeaderChar = '=';
            }
            
        }

        private void commentChar_TextChanged(object sender, EventArgs e)
        {
            if (!commentChar.Text.Equals(""))
            {
                Form2.CommentChar = commentChar.Text[0];
            }
            else
            {
                Form2.CommentChar = '#';
            }
            
        }

        private void leadingCommentSpace_ValueChanged(object sender, EventArgs e)
        {
            Form2.LeadingCommentSpace = (int)leadingCommentSpace.Value;
            
        }

        private void numberOfSpacesPerIndent_ValueChanged(object sender, EventArgs e)
        {
            Form2.IndentSpaces = (int)numberOfSpacesPerIndent.Value;
            
        }

        private void indentedComments_Click(object sender, EventArgs e)
        {
            if (indentedComments.Checked)
            {
                Form2.IndentedComments = true;
                numberOfSpacesPerIndent.Enabled = true;
            }
            else
            {
                Form2.IndentedComments = false;
                numberOfSpacesPerIndent.Enabled = false;
            }
            
        }

        private void reset_Click(object sender, EventArgs e)
        {
              Form2.ShowFeatureTypes = false;
              Form2.ShowLicenseTypes = false;
              Form2.ShowNumberOfSeats = false;
              Form2.listSubComponents = false;

              Form2.CommentChar = '#';
              Form2.HeaderChar = '=';
              Form2.LeadingCommentSpace = 1;
              Form2.IndentSpaces = 4;

              Form2.IndentedComments = false;
              Form2.KeepComments = false;
              Form2.KeepBreaks = false;
              Form2.AddComments = true;
              Form2.CommentHeaders = true;
              Form2.FixedHeaderLength = false;
              Form2.VariableHeaderLength = true;
              Form2.FixedCommentLength = 10;

              featureTypes.Checked = false;
              licenseTypes.Checked = false;
              numberSeats.Checked = false;
              subComponents.Checked = false;
              commentChar.Text = "#";
              headerChar.Text = "=";
              leadingCommentSpace.Value = 1;
              numberOfSpacesPerIndent.Value = 4;
              numberOfSpacesPerIndent.Enabled = false;
              indentedComments.Checked = false;
              comments2.Checked = false;
              linebreaks2.Checked = false;
              addComments.Checked = true;
              headers.Checked = true;
              fixedLength.Checked = false;
              variableLength.Checked = true;
              fixedNumber.Visible = false;
              fixedNumber.Value = 10;

              
        }

        private void savePrefs_Click(object sender, EventArgs e)
        {
            this.Save();
            this.Close();
        }

        //private void Form2_FormClosing(object sender, CancelEventArgs ar)
        //{
        //    if (justSaved == false)
        //    {
        //        var mBox = MessageBox.Show("Changes have not yet been saved. Exit without saving?", "Exit Without Saving", MessageBoxButtons.YesNo);
        //        if (mBox == DialogResult.No)
        //        {
        //            ar.Cancel = true;
        //        }
        //    }

        //}
        //SOFTWARE\\MDi\\License Cleaner\\1.0\\Prefs
        private RegistryKey recurse(RegistryKey reg)
        {
            RegistryKey rk = reg;
            RegistryKey temp = null;
            foreach (String s in reg.GetSubKeyNames())
            {
                if (s.Equals("Software") || s.Equals("SOFTWARE"))
                {
                    temp = reg.OpenSubKey(s, true);
                    temp = temp.CreateSubKey("MDi");
                    temp = temp.CreateSubKey("License Cleaner");
                    temp = temp.CreateSubKey("1.0");
                    temp = temp.CreateSubKey("Prefs");
                    break;
                }
            }
            return temp;

            //foreach (String name in temp.GetSubKeyNames())
            //        {
            //            if (name.Equals("MDi"))
            //            {
            //                temp = temp.OpenSubKey(name);
            //                foreach (String st in temp.GetSubKeyNames())
            //                {
            //                    if (st.Equals("License Cleaner"))
            //                    {
            //                        temp = temp.OpenSubKey(st);
            //                        foreach (String nam in temp.GetSubKeyNames())
            //                        {
            //                            if (nam.Equals("1.0"))
            //                            {
            //                                temp = temp.OpenSubKey(nam);
            //                                foreach (String strin in temp.GetSubKeyNames())
            //                                {
            //                                    if (strin.Equals("Prefs"))
            //                                    {
            //                                        temp = temp.OpenSubKey(strin);
            //                                        break;
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        }
            //                        break;
            //                    }
            //                }
            //                break;
            //            }
            //        }
            //        break;
        }

        private static RegistryKey originalRecurse(RegistryKey reg)
        {
            RegistryKey rk = reg;
            RegistryKey temp = null;
            foreach (String s in reg.GetSubKeyNames())
            {
                if (s.Equals("Software") || s.Equals("SOFTWARE"))
                {
                    temp = reg.OpenSubKey(s, true);
                    temp = temp.CreateSubKey("MDi");
                    temp = temp.CreateSubKey("License Cleaner");
                    temp = temp.CreateSubKey("1.0");
                    temp = temp.CreateSubKey("Prefs");
                    break;
                }
            }
            return temp;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
