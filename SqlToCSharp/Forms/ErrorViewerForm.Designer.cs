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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.close = new System.Windows.Forms.Button();
            this.moreDetails = new System.Windows.Forms.Button();
            this.imageControl = new System.Windows.Forms.PictureBox();
            this.errorControl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imageControl)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 81);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(319, 30);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(241, 85);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            // 
            // moreDetails
            // 
            this.moreDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moreDetails.Location = new System.Drawing.Point(6, 85);
            this.moreDetails.Name = "moreDetails";
            this.moreDetails.Size = new System.Drawing.Size(26, 23);
            this.moreDetails.TabIndex = 3;
            this.moreDetails.Text = "?";
            this.moreDetails.UseVisualStyleBackColor = true;
            // 
            // imageControl
            // 
            this.imageControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.imageControl.Location = new System.Drawing.Point(0, 0);
            this.imageControl.Name = "imageControl";
            this.imageControl.Size = new System.Drawing.Size(78, 81);
            this.imageControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageControl.TabIndex = 0;
            this.imageControl.TabStop = false;
            // 
            // errorControl
            // 
            this.errorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorControl.Location = new System.Drawing.Point(78, 0);
            this.errorControl.Name = "errorControl";
            this.errorControl.Padding = new System.Windows.Forms.Padding(10, 25, 10, 10);
            this.errorControl.Size = new System.Drawing.Size(241, 81);
            this.errorControl.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.errorControl);
            this.panel1.Controls.Add(this.imageControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 81);
            this.panel1.TabIndex = 4;
            // 
            // ErrorViewerForm
            // 
            this.AcceptButton = this.close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(319, 111);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.moreDetails);
            this.Controls.Add(this.close);
            this.Controls.Add(this.splitter1);
            this.Name = "ErrorViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorReporterForm";
            ((System.ComponentModel.ISupportInitialize)(this.imageControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button moreDetails;
        private System.Windows.Forms.PictureBox imageControl;
        private System.Windows.Forms.Label errorControl;
        private System.Windows.Forms.Panel panel1;
    }
}