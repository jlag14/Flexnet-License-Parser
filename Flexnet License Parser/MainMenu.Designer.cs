namespace LicenseParser
{
    partial class MainMenu
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
            this.rawFile = new System.Windows.Forms.TextBox();
            this.open = new System.Windows.Forms.Button();
            this.cleanedFile = new System.Windows.Forms.TextBox();
            this.clearBottom = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.parse = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cut = new System.Windows.Forms.ToolStripMenuItem();
            this.copy = new System.Windows.Forms.ToolStripMenuItem();
            this.paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.preferences = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.copyButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // rawFile
            // 
            this.rawFile.AcceptsReturn = true;
            this.rawFile.AcceptsTab = true;
            this.rawFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawFile.Location = new System.Drawing.Point(40, 71);
            this.rawFile.Margin = new System.Windows.Forms.Padding(4);
            this.rawFile.MaxLength = 1000000;
            this.rawFile.Multiline = true;
            this.rawFile.Name = "rawFile";
            this.rawFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rawFile.Size = new System.Drawing.Size(899, 249);
            this.rawFile.TabIndex = 0;
            this.rawFile.WordWrap = false;
            // 
            // open
            // 
            this.open.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.open.Location = new System.Drawing.Point(344, 329);
            this.open.Margin = new System.Windows.Forms.Padding(4);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(94, 29);
            this.open.TabIndex = 1;
            this.open.Text = "Open...";
            this.toolTip1.SetToolTip(this.open, "When clicked, opens a window to allow the user to\r\nselect a .lic or a .txt file t" +
        "o open. The selected file\r\nwill be formatted and placed into the upper text box." +
        "");
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click_1);
            // 
            // cleanedFile
            // 
            this.cleanedFile.AcceptsReturn = true;
            this.cleanedFile.AcceptsTab = true;
            this.cleanedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanedFile.Location = new System.Drawing.Point(40, 394);
            this.cleanedFile.Margin = new System.Windows.Forms.Padding(4);
            this.cleanedFile.MaxLength = 1000000;
            this.cleanedFile.Multiline = true;
            this.cleanedFile.Name = "cleanedFile";
            this.cleanedFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cleanedFile.Size = new System.Drawing.Size(899, 249);
            this.cleanedFile.TabIndex = 2;
            this.cleanedFile.WordWrap = false;
            // 
            // clearBottom
            // 
            this.clearBottom.Location = new System.Drawing.Point(600, 552);
            this.clearBottom.Margin = new System.Windows.Forms.Padding(4);
            this.clearBottom.Name = "clearBottom";
            this.clearBottom.Size = new System.Drawing.Size(0, 0);
            this.clearBottom.TabIndex = 4;
            this.clearBottom.Text = "Clear";
            this.clearBottom.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.save.Location = new System.Drawing.Point(344, 662);
            this.save.Margin = new System.Windows.Forms.Padding(4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(94, 29);
            this.save.TabIndex = 5;
            this.save.Text = "Save...";
            this.toolTip1.SetToolTip(this.save, "Saves the text in the lower text box as a .lic or a .txt file\r\nto a location of t" +
        "he user\'s choosing.");
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click_1);
            // 
            // parse
            // 
            this.parse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.parse.Location = new System.Drawing.Point(535, 329);
            this.parse.Margin = new System.Windows.Forms.Padding(4);
            this.parse.Name = "parse";
            this.parse.Size = new System.Drawing.Size(94, 29);
            this.parse.TabIndex = 6;
            this.parse.Text = "Parse";
            this.toolTip1.SetToolTip(this.parse, "When clicked, cleans the text in the upper text box using\r\npreviously defined lic" +
        "ense properties.");
            this.parse.UseVisualStyleBackColor = true;
            this.parse.Click += new System.EventHandler(this.parse_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.helpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(980, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.saveAs,
            this.toolStripSeparator4,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(44, 24);
            this.fileMenu.Text = "File";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(194, 26);
            this.menuOpen.Text = "Open...";
            this.menuOpen.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveAs
            // 
            this.saveAs.Name = "saveAs";
            this.saveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAs.Size = new System.Drawing.Size(194, 26);
            this.saveAs.Text = "Save As...";
            this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(191, 6);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exit.Size = new System.Drawing.Size(194, 26);
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click_1);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undo,
            this.toolStripSeparator2,
            this.cut,
            this.copy,
            this.paste,
            this.toolStripSeparator3,
            this.selectAll,
            this.toolStripSeparator1,
            this.preferences});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(47, 24);
            this.editMenu.Text = "Edit";
            // 
            // undo
            // 
            this.undo.Name = "undo";
            this.undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undo.Size = new System.Drawing.Size(219, 26);
            this.undo.Text = "Undo";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // cut
            // 
            this.cut.Name = "cut";
            this.cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cut.Size = new System.Drawing.Size(219, 26);
            this.cut.Text = "Cut";
            this.cut.Click += new System.EventHandler(this.cut_Click);
            // 
            // copy
            // 
            this.copy.Name = "copy";
            this.copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copy.Size = new System.Drawing.Size(219, 26);
            this.copy.Text = "Copy";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Name = "paste";
            this.paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.paste.Size = new System.Drawing.Size(219, 26);
            this.paste.Text = "Paste";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(216, 6);
            // 
            // selectAll
            // 
            this.selectAll.Name = "selectAll";
            this.selectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAll.Size = new System.Drawing.Size(219, 26);
            this.selectAll.Text = "Select All";
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // preferences
            // 
            this.preferences.Name = "preferences";
            this.preferences.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.preferences.Size = new System.Drawing.Size(219, 26);
            this.preferences.Text = "Preferences...";
            this.preferences.Click += new System.EventHandler(this.preferences_Click_1);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(53, 24);
            this.helpMenu.Text = "Help";
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.about.Size = new System.Drawing.Size(176, 26);
            this.about.Text = "About";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 729);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.status.Size = new System.Drawing.Size(980, 22);
            this.status.TabIndex = 10;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // copyButton
            // 
            this.copyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.copyButton.Location = new System.Drawing.Point(535, 662);
            this.copyButton.Margin = new System.Windows.Forms.Padding(4);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(94, 29);
            this.copyButton.TabIndex = 11;
            this.copyButton.Text = "Copy";
            this.toolTip1.SetToolTip(this.copyButton, "Copies all of the text in the lower text box to the clipboard.");
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 30000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(980, 751);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.status);
            this.Controls.Add(this.parse);
            this.Controls.Add(this.save);
            this.Controls.Add(this.clearBottom);
            this.Controls.Add(this.cleanedFile);
            this.Controls.Add(this.open);
            this.Controls.Add(this.rawFile);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(4796, 2688);
            this.MinimumSize = new System.Drawing.Size(996, 788);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flexnet License Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rawFile;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.TextBox cleanedFile;
        private System.Windows.Forms.Button clearBottom;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button parse;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAs;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem cut;
        private System.Windows.Forms.ToolStripMenuItem copy;
        private System.Windows.Forms.ToolStripMenuItem paste;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripMenuItem undo;
        private System.Windows.Forms.ToolStripMenuItem selectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem preferences;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

