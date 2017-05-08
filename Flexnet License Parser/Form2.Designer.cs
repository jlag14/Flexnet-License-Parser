namespace LicenseParser
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.comments2 = new System.Windows.Forms.CheckBox();
            this.linebreaks2 = new System.Windows.Forms.CheckBox();
            this.addComments = new System.Windows.Forms.CheckBox();
            this.headers = new System.Windows.Forms.CheckBox();
            this.commentContent = new System.Windows.Forms.GroupBox();
            this.subComponents = new System.Windows.Forms.CheckBox();
            this.numberSeats = new System.Windows.Forms.CheckBox();
            this.licenseTypes = new System.Windows.Forms.CheckBox();
            this.featureTypes = new System.Windows.Forms.CheckBox();
            this.headerChar = new System.Windows.Forms.TextBox();
            this.headerCharLabel = new System.Windows.Forms.Label();
            this.commentCharLabel = new System.Windows.Forms.Label();
            this.commentChar = new System.Windows.Forms.TextBox();
            this.leadingCommentSpace = new System.Windows.Forms.NumericUpDown();
            this.variableLength = new System.Windows.Forms.RadioButton();
            this.fixedNumber = new System.Windows.Forms.NumericUpDown();
            this.fixedLength = new System.Windows.Forms.RadioButton();
            this.headerLengthBox = new System.Windows.Forms.GroupBox();
            this.commentSpaceLabel = new System.Windows.Forms.Label();
            this.indentSpacesLabel = new System.Windows.Forms.Label();
            this.numberOfSpacesPerIndent = new System.Windows.Forms.NumericUpDown();
            this.indentedComments = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.reset = new System.Windows.Forms.Button();
            this.savePrefs = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.generalOptions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.XMLPathBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.commentOptions = new System.Windows.Forms.GroupBox();
            this.headerOptions = new System.Windows.Forms.GroupBox();
            this.commentContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leadingCommentSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedNumber)).BeginInit();
            this.headerLengthBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSpacesPerIndent)).BeginInit();
            this.generalOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.commentOptions.SuspendLayout();
            this.headerOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // comments2
            // 
            this.comments2.AutoSize = true;
            this.comments2.Location = new System.Drawing.Point(8, 23);
            this.comments2.Margin = new System.Windows.Forms.Padding(4);
            this.comments2.Name = "comments2";
            this.comments2.Size = new System.Drawing.Size(193, 21);
            this.comments2.TabIndex = 8;
            this.comments2.Text = "Keep Existing Comments?";
            this.toolTip1.SetToolTip(this.comments2, resources.GetString("comments2.ToolTip"));
            this.comments2.UseVisualStyleBackColor = true;
            this.comments2.Click += new System.EventHandler(this.comments2_Click);
            // 
            // linebreaks2
            // 
            this.linebreaks2.AutoSize = true;
            this.linebreaks2.Location = new System.Drawing.Point(8, 48);
            this.linebreaks2.Margin = new System.Windows.Forms.Padding(4);
            this.linebreaks2.Name = "linebreaks2";
            this.linebreaks2.Size = new System.Drawing.Size(202, 21);
            this.linebreaks2.TabIndex = 10;
            this.linebreaks2.Text = "Keep Existing Line Breaks?";
            this.toolTip1.SetToolTip(this.linebreaks2, resources.GetString("linebreaks2.ToolTip"));
            this.linebreaks2.UseVisualStyleBackColor = true;
            this.linebreaks2.Click += new System.EventHandler(this.linebreaks2_Click);
            // 
            // addComments
            // 
            this.addComments.AutoSize = true;
            this.addComments.Location = new System.Drawing.Point(8, 23);
            this.addComments.Margin = new System.Windows.Forms.Padding(4);
            this.addComments.Name = "addComments";
            this.addComments.Size = new System.Drawing.Size(215, 21);
            this.addComments.TabIndex = 11;
            this.addComments.Text = "Add License Documentation?";
            this.toolTip1.SetToolTip(this.addComments, "When checked, allows comments to be created which \r\ncontain the details of each l" +
        "icense.");
            this.addComments.UseVisualStyleBackColor = true;
            this.addComments.Click += new System.EventHandler(this.addComments_Click);
            // 
            // headers
            // 
            this.headers.AutoSize = true;
            this.headers.Location = new System.Drawing.Point(8, 23);
            this.headers.Margin = new System.Windows.Forms.Padding(4);
            this.headers.Name = "headers";
            this.headers.Size = new System.Drawing.Size(184, 21);
            this.headers.TabIndex = 12;
            this.headers.Text = "Add Comment Headers?";
            this.toolTip1.SetToolTip(this.headers, "When checked, each time a license documentation line is \r\ngenerated and added, ad" +
        "ds a commented header line above\r\nand below the documentation line.");
            this.headers.UseVisualStyleBackColor = true;
            this.headers.Click += new System.EventHandler(this.headers_Click);
            // 
            // commentContent
            // 
            this.commentContent.Controls.Add(this.subComponents);
            this.commentContent.Controls.Add(this.numberSeats);
            this.commentContent.Controls.Add(this.licenseTypes);
            this.commentContent.Controls.Add(this.featureTypes);
            this.commentContent.Location = new System.Drawing.Point(8, 48);
            this.commentContent.Margin = new System.Windows.Forms.Padding(4);
            this.commentContent.Name = "commentContent";
            this.commentContent.Padding = new System.Windows.Forms.Padding(4);
            this.commentContent.Size = new System.Drawing.Size(223, 154);
            this.commentContent.TabIndex = 16;
            this.commentContent.TabStop = false;
            this.commentContent.Text = "Comment Content";
            // 
            // subComponents
            // 
            this.subComponents.AutoSize = true;
            this.subComponents.Location = new System.Drawing.Point(9, 113);
            this.subComponents.Margin = new System.Windows.Forms.Padding(4);
            this.subComponents.Name = "subComponents";
            this.subComponents.Size = new System.Drawing.Size(173, 21);
            this.subComponents.TabIndex = 3;
            this.subComponents.Text = "List Sub-Components?";
            this.toolTip1.SetToolTip(this.subComponents, "When checked, an indented and commented list of the\r\nsub-components in a license " +
        "(if any) will be displayed as\r\npart of the documentation comment.");
            this.subComponents.UseVisualStyleBackColor = true;
            this.subComponents.Click += new System.EventHandler(this.subComponents_Click);
            // 
            // numberSeats
            // 
            this.numberSeats.AutoSize = true;
            this.numberSeats.Location = new System.Drawing.Point(9, 84);
            this.numberSeats.Margin = new System.Windows.Forms.Padding(4);
            this.numberSeats.Name = "numberSeats";
            this.numberSeats.Size = new System.Drawing.Size(193, 21);
            this.numberSeats.TabIndex = 2;
            this.numberSeats.Text = "Include Number of Seats?";
            this.toolTip1.SetToolTip(this.numberSeats, "Displays the number of seats held by the given license.");
            this.numberSeats.UseVisualStyleBackColor = true;
            this.numberSeats.Click += new System.EventHandler(this.numberSeats_Click);
            // 
            // licenseTypes
            // 
            this.licenseTypes.AutoSize = true;
            this.licenseTypes.Location = new System.Drawing.Point(9, 54);
            this.licenseTypes.Margin = new System.Windows.Forms.Padding(4);
            this.licenseTypes.Name = "licenseTypes";
            this.licenseTypes.Size = new System.Drawing.Size(179, 21);
            this.licenseTypes.TabIndex = 1;
            this.licenseTypes.Text = "Include License Types?";
            this.toolTip1.SetToolTip(this.licenseTypes, "Displays whether a license is permanent or temporary. If\r\na license is temporary," +
        " its expiration date is also shown.");
            this.licenseTypes.UseVisualStyleBackColor = true;
            this.licenseTypes.Click += new System.EventHandler(this.licenseTypes_Click);
            // 
            // featureTypes
            // 
            this.featureTypes.AutoSize = true;
            this.featureTypes.Location = new System.Drawing.Point(9, 25);
            this.featureTypes.Margin = new System.Windows.Forms.Padding(4);
            this.featureTypes.Name = "featureTypes";
            this.featureTypes.Size = new System.Drawing.Size(179, 21);
            this.featureTypes.TabIndex = 0;
            this.featureTypes.Text = "Include Feature Types?";
            this.toolTip1.SetToolTip(this.featureTypes, "Displays whether or not a license is a Subscription\r\nPackage in a documentation.");
            this.featureTypes.UseVisualStyleBackColor = true;
            this.featureTypes.Click += new System.EventHandler(this.featureTypes_Click);
            // 
            // headerChar
            // 
            this.headerChar.Location = new System.Drawing.Point(17, 26);
            this.headerChar.Margin = new System.Windows.Forms.Padding(4);
            this.headerChar.MaxLength = 1;
            this.headerChar.Name = "headerChar";
            this.headerChar.Size = new System.Drawing.Size(25, 22);
            this.headerChar.TabIndex = 17;
            this.headerChar.Text = "=";
            this.headerChar.TextChanged += new System.EventHandler(this.headerChar_TextChanged);
            // 
            // headerCharLabel
            // 
            this.headerCharLabel.AutoSize = true;
            this.headerCharLabel.Location = new System.Drawing.Point(52, 31);
            this.headerCharLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headerCharLabel.Name = "headerCharLabel";
            this.headerCharLabel.Size = new System.Drawing.Size(121, 17);
            this.headerCharLabel.TabIndex = 18;
            this.headerCharLabel.Text = "Header Character";
            this.toolTip1.SetToolTip(this.headerCharLabel, "This character will be printed repeatedly in order to form\r\ncomment headers (when" +
        " comment headers are enabled).");
            // 
            // commentCharLabel
            // 
            this.commentCharLabel.AutoSize = true;
            this.commentCharLabel.Location = new System.Drawing.Point(52, 64);
            this.commentCharLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commentCharLabel.Name = "commentCharLabel";
            this.commentCharLabel.Size = new System.Drawing.Size(133, 17);
            this.commentCharLabel.TabIndex = 19;
            this.commentCharLabel.Text = "Comment Character";
            this.toolTip1.SetToolTip(this.commentCharLabel, resources.GetString("commentCharLabel.ToolTip"));
            // 
            // commentChar
            // 
            this.commentChar.Location = new System.Drawing.Point(17, 59);
            this.commentChar.Margin = new System.Windows.Forms.Padding(4);
            this.commentChar.MaxLength = 1;
            this.commentChar.Name = "commentChar";
            this.commentChar.Size = new System.Drawing.Size(25, 22);
            this.commentChar.TabIndex = 20;
            this.commentChar.Text = "#";
            this.commentChar.TextChanged += new System.EventHandler(this.commentChar_TextChanged);
            // 
            // leadingCommentSpace
            // 
            this.leadingCommentSpace.Location = new System.Drawing.Point(32, 225);
            this.leadingCommentSpace.Margin = new System.Windows.Forms.Padding(4);
            this.leadingCommentSpace.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.leadingCommentSpace.Name = "leadingCommentSpace";
            this.leadingCommentSpace.Size = new System.Drawing.Size(61, 22);
            this.leadingCommentSpace.TabIndex = 17;
            this.toolTip1.SetToolTip(this.leadingCommentSpace, "The number of spaces between a comment character\r\nand a documentation. See the \"L" +
        "eading Comment Space\"\r\ntooltip (hover over the label to view).");
            this.leadingCommentSpace.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.leadingCommentSpace.ValueChanged += new System.EventHandler(this.leadingCommentSpace_ValueChanged);
            // 
            // variableLength
            // 
            this.variableLength.AutoSize = true;
            this.variableLength.Location = new System.Drawing.Point(8, 23);
            this.variableLength.Margin = new System.Windows.Forms.Padding(4);
            this.variableLength.Name = "variableLength";
            this.variableLength.Size = new System.Drawing.Size(81, 21);
            this.variableLength.TabIndex = 13;
            this.variableLength.TabStop = true;
            this.variableLength.Text = "Variable";
            this.toolTip1.SetToolTip(this.variableLength, resources.GetString("variableLength.ToolTip"));
            this.variableLength.UseVisualStyleBackColor = true;
            this.variableLength.Click += new System.EventHandler(this.variableLength_Click);
            // 
            // fixedNumber
            // 
            this.fixedNumber.Location = new System.Drawing.Point(97, 48);
            this.fixedNumber.Margin = new System.Windows.Forms.Padding(4);
            this.fixedNumber.Name = "fixedNumber";
            this.fixedNumber.Size = new System.Drawing.Size(61, 22);
            this.fixedNumber.TabIndex = 14;
            this.toolTip1.SetToolTip(this.fixedNumber, "The specific number of header characters included in a\r\nfixed-length comment head" +
        "er.");
            this.fixedNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fixedNumber.Visible = false;
            this.fixedNumber.ValueChanged += new System.EventHandler(this.fixedNumber_ValueChanged);
            // 
            // fixedLength
            // 
            this.fixedLength.AutoSize = true;
            this.fixedLength.Location = new System.Drawing.Point(8, 52);
            this.fixedLength.Margin = new System.Windows.Forms.Padding(4);
            this.fixedLength.Name = "fixedLength";
            this.fixedLength.Size = new System.Drawing.Size(62, 21);
            this.fixedLength.TabIndex = 16;
            this.fixedLength.TabStop = true;
            this.fixedLength.Text = "Fixed";
            this.toolTip1.SetToolTip(this.fixedLength, "When selected, comment headers will contain the exact\r\nnumber of header character" +
        "s as specified in the \r\naccompanying value box. (The value box will not be \r\nvis" +
        "ible unless this option is selected.)");
            this.fixedLength.UseVisualStyleBackColor = true;
            this.fixedLength.Click += new System.EventHandler(this.fixedLength_Click);
            // 
            // headerLengthBox
            // 
            this.headerLengthBox.Controls.Add(this.fixedNumber);
            this.headerLengthBox.Controls.Add(this.fixedLength);
            this.headerLengthBox.Controls.Add(this.variableLength);
            this.headerLengthBox.Location = new System.Drawing.Point(8, 52);
            this.headerLengthBox.Margin = new System.Windows.Forms.Padding(4);
            this.headerLengthBox.Name = "headerLengthBox";
            this.headerLengthBox.Padding = new System.Windows.Forms.Padding(4);
            this.headerLengthBox.Size = new System.Drawing.Size(247, 95);
            this.headerLengthBox.TabIndex = 21;
            this.headerLengthBox.TabStop = false;
            this.headerLengthBox.Text = "Header Length";
            // 
            // commentSpaceLabel
            // 
            this.commentSpaceLabel.AutoSize = true;
            this.commentSpaceLabel.Location = new System.Drawing.Point(8, 206);
            this.commentSpaceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commentSpaceLabel.Name = "commentSpaceLabel";
            this.commentSpaceLabel.Size = new System.Drawing.Size(166, 17);
            this.commentSpaceLabel.TabIndex = 22;
            this.commentSpaceLabel.Text = "Leading Comment Space";
            this.toolTip1.SetToolTip(this.commentSpaceLabel, resources.GetString("commentSpaceLabel.ToolTip"));
            // 
            // indentSpacesLabel
            // 
            this.indentSpacesLabel.AutoSize = true;
            this.indentSpacesLabel.Location = new System.Drawing.Point(49, 282);
            this.indentSpacesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indentSpacesLabel.Name = "indentSpacesLabel";
            this.indentSpacesLabel.Size = new System.Drawing.Size(125, 17);
            this.indentSpacesLabel.TabIndex = 23;
            this.indentSpacesLabel.Text = "Number of Spaces";
            // 
            // numberOfSpacesPerIndent
            // 
            this.numberOfSpacesPerIndent.Enabled = false;
            this.numberOfSpacesPerIndent.Location = new System.Drawing.Point(87, 302);
            this.numberOfSpacesPerIndent.Margin = new System.Windows.Forms.Padding(4);
            this.numberOfSpacesPerIndent.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numberOfSpacesPerIndent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfSpacesPerIndent.Name = "numberOfSpacesPerIndent";
            this.numberOfSpacesPerIndent.Size = new System.Drawing.Size(61, 22);
            this.numberOfSpacesPerIndent.TabIndex = 24;
            this.toolTip1.SetToolTip(this.numberOfSpacesPerIndent, "The number of spaces to be added before the comment\r\ncharacters that prefix docum" +
        "entation and header lines.");
            this.numberOfSpacesPerIndent.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfSpacesPerIndent.ValueChanged += new System.EventHandler(this.numberOfSpacesPerIndent_ValueChanged);
            // 
            // indentedComments
            // 
            this.indentedComments.AutoSize = true;
            this.indentedComments.Location = new System.Drawing.Point(5, 257);
            this.indentedComments.Margin = new System.Windows.Forms.Padding(4);
            this.indentedComments.Name = "indentedComments";
            this.indentedComments.Size = new System.Drawing.Size(230, 21);
            this.indentedComments.TabIndex = 27;
            this.indentedComments.Text = "Add Spaces Before Comments?";
            this.toolTip1.SetToolTip(this.indentedComments, "When checked, allows spaces to be added in front of\r\nthe comment characters on do" +
        "cumentation and header\r\nlines.");
            this.indentedComments.UseVisualStyleBackColor = true;
            this.indentedComments.Click += new System.EventHandler(this.indentedComments_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 30000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(606, 279);
            this.reset.Margin = new System.Windows.Forms.Padding(4);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(132, 28);
            this.reset.TabIndex = 28;
            this.reset.Text = "Reset to Default";
            this.toolTip1.SetToolTip(this.reset, "Resets all of the values on the preferences form to their\r\ndefault values. This c" +
        "hange is not saved if the \"Cancel\"\r\nbutton is used to exit the form.");
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // savePrefs
            // 
            this.savePrefs.Location = new System.Drawing.Point(621, 188);
            this.savePrefs.Margin = new System.Windows.Forms.Padding(4);
            this.savePrefs.Name = "savePrefs";
            this.savePrefs.Size = new System.Drawing.Size(100, 28);
            this.savePrefs.TabIndex = 29;
            this.savePrefs.Text = "Save";
            this.toolTip1.SetToolTip(this.savePrefs, resources.GetString("savePrefs.ToolTip"));
            this.savePrefs.UseVisualStyleBackColor = true;
            this.savePrefs.Click += new System.EventHandler(this.savePrefs_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(621, 233);
            this.cancel.Margin = new System.Windows.Forms.Padding(4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 28);
            this.cancel.TabIndex = 33;
            this.cancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.cancel, "Exits Preferences and returns the user to the main form.\r\nIf clicked, any changes" +
        " made to the form from its most\r\nrecently saved version will not be saved.");
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // generalOptions
            // 
            this.generalOptions.Controls.Add(this.label1);
            this.generalOptions.Controls.Add(this.XMLPathBox);
            this.generalOptions.Controls.Add(this.groupBox1);
            this.generalOptions.Controls.Add(this.comments2);
            this.generalOptions.Controls.Add(this.linebreaks2);
            this.generalOptions.Location = new System.Drawing.Point(7, 9);
            this.generalOptions.Margin = new System.Windows.Forms.Padding(4);
            this.generalOptions.Name = "generalOptions";
            this.generalOptions.Padding = new System.Windows.Forms.Padding(4);
            this.generalOptions.Size = new System.Drawing.Size(276, 256);
            this.generalOptions.TabIndex = 30;
            this.generalOptions.TabStop = false;
            this.generalOptions.Text = "General Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "LicenseMeta.xml Path:";
            // 
            // XMLPathBox
            // 
            this.XMLPathBox.Location = new System.Drawing.Point(5, 225);
            this.XMLPathBox.Name = "XMLPathBox";
            this.XMLPathBox.Size = new System.Drawing.Size(263, 22);
            this.XMLPathBox.TabIndex = 34;
            this.XMLPathBox.TextChanged += new System.EventHandler(this.XMLPathBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.headerCharLabel);
            this.groupBox1.Controls.Add(this.headerChar);
            this.groupBox1.Controls.Add(this.commentCharLabel);
            this.groupBox1.Controls.Add(this.commentChar);
            this.groupBox1.Location = new System.Drawing.Point(9, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(259, 102);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Special Characters";
            // 
            // commentOptions
            // 
            this.commentOptions.Controls.Add(this.addComments);
            this.commentOptions.Controls.Add(this.commentContent);
            this.commentOptions.Controls.Add(this.commentSpaceLabel);
            this.commentOptions.Controls.Add(this.leadingCommentSpace);
            this.commentOptions.Controls.Add(this.numberOfSpacesPerIndent);
            this.commentOptions.Controls.Add(this.indentedComments);
            this.commentOptions.Controls.Add(this.indentSpacesLabel);
            this.commentOptions.Location = new System.Drawing.Point(291, 9);
            this.commentOptions.Margin = new System.Windows.Forms.Padding(4);
            this.commentOptions.Name = "commentOptions";
            this.commentOptions.Padding = new System.Windows.Forms.Padding(4);
            this.commentOptions.Size = new System.Drawing.Size(243, 341);
            this.commentOptions.TabIndex = 31;
            this.commentOptions.TabStop = false;
            this.commentOptions.Text = "Comment Options";
            // 
            // headerOptions
            // 
            this.headerOptions.Controls.Add(this.headers);
            this.headerOptions.Controls.Add(this.headerLengthBox);
            this.headerOptions.Location = new System.Drawing.Point(541, 9);
            this.headerOptions.Margin = new System.Windows.Forms.Padding(4);
            this.headerOptions.Name = "headerOptions";
            this.headerOptions.Padding = new System.Windows.Forms.Padding(4);
            this.headerOptions.Size = new System.Drawing.Size(263, 160);
            this.headerOptions.TabIndex = 32;
            this.headerOptions.TabStop = false;
            this.headerOptions.Text = "Header Options";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(804, 393);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.headerOptions);
            this.Controls.Add(this.commentOptions);
            this.Controls.Add(this.generalOptions);
            this.Controls.Add(this.savePrefs);
            this.Controls.Add(this.reset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Preferences";
            this.TopMost = true;
            this.commentContent.ResumeLayout(false);
            this.commentContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leadingCommentSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedNumber)).EndInit();
            this.headerLengthBox.ResumeLayout(false);
            this.headerLengthBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSpacesPerIndent)).EndInit();
            this.generalOptions.ResumeLayout(false);
            this.generalOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.commentOptions.ResumeLayout(false);
            this.commentOptions.PerformLayout();
            this.headerOptions.ResumeLayout(false);
            this.headerOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox comments2;
        private System.Windows.Forms.CheckBox linebreaks2;
        private System.Windows.Forms.CheckBox addComments;
        private System.Windows.Forms.CheckBox headers;
        private System.Windows.Forms.GroupBox commentContent;
        private System.Windows.Forms.CheckBox subComponents;
        private System.Windows.Forms.CheckBox numberSeats;
        private System.Windows.Forms.CheckBox licenseTypes;
        private System.Windows.Forms.CheckBox featureTypes;
        private System.Windows.Forms.TextBox headerChar;
        private System.Windows.Forms.Label headerCharLabel;
        private System.Windows.Forms.Label commentCharLabel;
        private System.Windows.Forms.TextBox commentChar;
        private System.Windows.Forms.NumericUpDown leadingCommentSpace;
        private System.Windows.Forms.RadioButton variableLength;
        private System.Windows.Forms.NumericUpDown fixedNumber;
        private System.Windows.Forms.RadioButton fixedLength;
        private System.Windows.Forms.GroupBox headerLengthBox;
        private System.Windows.Forms.Label commentSpaceLabel;
        private System.Windows.Forms.Label indentSpacesLabel;
        private System.Windows.Forms.NumericUpDown numberOfSpacesPerIndent;
        private System.Windows.Forms.CheckBox indentedComments;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button savePrefs;
        private System.Windows.Forms.GroupBox generalOptions;
        private System.Windows.Forms.GroupBox commentOptions;
        private System.Windows.Forms.GroupBox headerOptions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox XMLPathBox;
        private System.Windows.Forms.Label label1;
    }
}