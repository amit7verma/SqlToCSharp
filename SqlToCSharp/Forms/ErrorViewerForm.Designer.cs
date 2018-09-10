namespace SqlToCSharp.Forms
{
    partial class ErrorViewerForm
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.close = new System.Windows.Forms.Button();
            this.moreDetails = new System.Windows.Forms.Button();
            this.imageControl = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorControl = new System.Windows.Forms.TextBox();
            this.moreDetailsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.imageControl)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 92);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(331, 30);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(253, 96);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            // 
            // moreDetails
            // 
            this.moreDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moreDetails.Location = new System.Drawing.Point(6, 96);
            this.moreDetails.Name = "moreDetails";
            this.moreDetails.Size = new System.Drawing.Size(26, 23);
            this.moreDetails.TabIndex = 3;
            this.moreDetails.Text = "?";
            this.moreDetails.UseVisualStyleBackColor = true;
            this.moreDetails.Click += new System.EventHandler(this.moreDetails_Click);
            // 
            // imageControl
            // 
            this.imageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageControl.Location = new System.Drawing.Point(0, 0);
            this.imageControl.Name = "imageControl";
            this.imageControl.Size = new System.Drawing.Size(100, 92);
            this.imageControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageControl.TabIndex = 0;
            this.imageControl.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 92);
            this.panel1.TabIndex = 4;
            // 
            // errorControl
            // 
            this.errorControl.BackColor = System.Drawing.SystemColors.Control;
            this.errorControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.errorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorControl.Location = new System.Drawing.Point(0, 0);
            this.errorControl.Multiline = true;
            this.errorControl.Name = "errorControl";
            this.errorControl.ReadOnly = true;
            this.errorControl.Size = new System.Drawing.Size(230, 92);
            this.errorControl.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.errorControl);
            this.splitContainer1.Size = new System.Drawing.Size(331, 92);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // ErrorViewerForm
            // 
            this.AcceptButton = this.close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(331, 122);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.moreDetails);
            this.Controls.Add(this.close);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ErrorViewerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorReporterForm";
            this.Load += new System.EventHandler(this.ErrorViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button moreDetails;
        private System.Windows.Forms.PictureBox imageControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip moreDetailsToolTip;
        private System.Windows.Forms.TextBox errorControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}