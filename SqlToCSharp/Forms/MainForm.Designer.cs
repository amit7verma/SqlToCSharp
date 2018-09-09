namespace SqlToCSharp.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbConnectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pocoGenerateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSimpleTypedDatatableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpCSharpCode = new System.Windows.Forms.GroupBox();
            this.cSharpCodeControl = new FastColoredTextBoxNS.FastColoredTextBox();
            this.dbTreeView = new SqlToCSharp.DBTreeView();
            this.creatorSettings = new SqlToCSharp.UserControls.ClassGeneratorSettings();
            this.topMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpCSharpCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cSharpCodeControl)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pocoGenerateMenuItem,
            this.generateSimpleTypedDatatableToolStripMenuItem});
            this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topMenuStrip.Name = "topMenuStrip";
            this.topMenuStrip.Size = new System.Drawing.Size(900, 24);
            this.topMenuStrip.TabIndex = 0;
            this.topMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbConnectionMenuItem,
            this.toolStripSeparator2,
            this.saveToFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "&Menu";
            // 
            // dbConnectionMenuItem
            // 
            this.dbConnectionMenuItem.Name = "dbConnectionMenuItem";
            this.dbConnectionMenuItem.Size = new System.Drawing.Size(187, 22);
            this.dbConnectionMenuItem.Text = "&Database Connection";
            this.dbConnectionMenuItem.Click += new System.EventHandler(this.dbConnectionStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveToFileToolStripMenuItem.Text = "&Save to file";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // pocoGenerateMenuItem
            // 
            this.pocoGenerateMenuItem.Name = "pocoGenerateMenuItem";
            this.pocoGenerateMenuItem.Size = new System.Drawing.Size(114, 20);
            this.pocoGenerateMenuItem.Text = "Generate &C# Class";
            this.pocoGenerateMenuItem.Click += new System.EventHandler(this.pocoGenerateMenuItem_Click);
            // 
            // generateSimpleTypedDatatableToolStripMenuItem
            // 
            this.generateSimpleTypedDatatableToolStripMenuItem.Name = "generateSimpleTypedDatatableToolStripMenuItem";
            this.generateSimpleTypedDatatableToolStripMenuItem.Size = new System.Drawing.Size(193, 20);
            this.generateSimpleTypedDatatableToolStripMenuItem.Text = "Generate Simple &Typed Datatable";
            this.generateSimpleTypedDatatableToolStripMenuItem.Click += new System.EventHandler(this.generateSimpleTypedDatatableToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dbTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(900, 514);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpCSharpCode);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.creatorSettings);
            this.splitContainer2.Size = new System.Drawing.Size(684, 514);
            this.splitContainer2.SplitterDistance = 424;
            this.splitContainer2.TabIndex = 0;
            // 
            // grpCSharpCode
            // 
            this.grpCSharpCode.Controls.Add(this.cSharpCodeControl);
            this.grpCSharpCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCSharpCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCSharpCode.Location = new System.Drawing.Point(0, 0);
            this.grpCSharpCode.Name = "grpCSharpCode";
            this.grpCSharpCode.Size = new System.Drawing.Size(422, 512);
            this.grpCSharpCode.TabIndex = 0;
            this.grpCSharpCode.TabStop = false;
            this.grpCSharpCode.Text = "grpCSharpCode";
            // 
            // cSharpCodeControl
            // 
            this.cSharpCodeControl.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.cSharpCodeControl.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
            this.cSharpCodeControl.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.cSharpCodeControl.BackBrush = null;
            this.cSharpCodeControl.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.cSharpCodeControl.CharHeight = 14;
            this.cSharpCodeControl.CharWidth = 8;
            this.cSharpCodeControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cSharpCodeControl.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cSharpCodeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSharpCodeControl.IsReplaceMode = false;
            this.cSharpCodeControl.Language = FastColoredTextBoxNS.Language.CSharp;
            this.cSharpCodeControl.LeftBracket = '(';
            this.cSharpCodeControl.LeftBracket2 = '{';
            this.cSharpCodeControl.Location = new System.Drawing.Point(3, 19);
            this.cSharpCodeControl.Name = "cSharpCodeControl";
            this.cSharpCodeControl.Paddings = new System.Windows.Forms.Padding(0);
            this.cSharpCodeControl.ReadOnly = true;
            this.cSharpCodeControl.RightBracket = ')';
            this.cSharpCodeControl.RightBracket2 = '}';
            this.cSharpCodeControl.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.cSharpCodeControl.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cSharpCodeControl.ServiceColors")));
            this.cSharpCodeControl.Size = new System.Drawing.Size(416, 490);
            this.cSharpCodeControl.TabIndex = 1;
            this.cSharpCodeControl.Zoom = 100;
            // 
            // dbTreeView
            // 
            this.dbTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbTreeView.Location = new System.Drawing.Point(0, 0);
            this.dbTreeView.Name = "dbTreeView";
            this.dbTreeView.Size = new System.Drawing.Size(210, 512);
            this.dbTreeView.TabIndex = 0;
            // 
            // creatorSettings
            // 
            this.creatorSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creatorSettings.Location = new System.Drawing.Point(0, 0);
            this.creatorSettings.Name = "creatorSettings";
            this.creatorSettings.Size = new System.Drawing.Size(254, 512);
            this.creatorSettings.TabIndex = 0;
            this.creatorSettings.ClassGeneratorSettingsChangedEventHandler += new SqlToCSharp.UserControls.ClassGeneratorSettings.ClassGeneratorSettingsEventHandler(this.creatorSettings_ClassSettingChangedEventHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.topMenuStrip);
            this.MainMenuStrip = this.topMenuStrip;
            this.Name = "MainForm";
            this.Text = "Sql To C#";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpCSharpCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cSharpCodeControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dbConnectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pocoGenerateMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private UserControls.ClassGeneratorSettings creatorSettings;
        private System.Windows.Forms.ToolStripMenuItem generateSimpleTypedDatatableToolStripMenuItem;
        private DBTreeView dbTreeView;
        private System.Windows.Forms.GroupBox grpCSharpCode;
        private FastColoredTextBoxNS.FastColoredTextBox cSharpCodeControl;
    }
}