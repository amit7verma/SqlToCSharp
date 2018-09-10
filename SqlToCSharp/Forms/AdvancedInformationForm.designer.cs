namespace SqlToCSharp.Forms
{
    partial class AdvancedInformationForm
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
            this.splitContainerBase = new System.Windows.Forms.SplitContainer();
            this.splitContainerErrorInfo = new System.Windows.Forms.SplitContainer();
            this.tvError = new System.Windows.Forms.TreeView();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnSaveLocally = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBase)).BeginInit();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.Panel2.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerErrorInfo)).BeginInit();
            this.splitContainerErrorInfo.Panel1.SuspendLayout();
            this.splitContainerErrorInfo.Panel2.SuspendLayout();
            this.splitContainerErrorInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerBase
            // 
            this.splitContainerBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBase.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerBase.IsSplitterFixed = true;
            this.splitContainerBase.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBase.Name = "splitContainerBase";
            this.splitContainerBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBase.Panel1
            // 
            this.splitContainerBase.Panel1.Controls.Add(this.splitContainerErrorInfo);
            // 
            // splitContainerBase.Panel2
            // 
            this.splitContainerBase.Panel2.Controls.Add(this.btnSaveLocally);
            this.splitContainerBase.Panel2.Controls.Add(this.btnClose);
            this.splitContainerBase.Size = new System.Drawing.Size(498, 371);
            this.splitContainerBase.SplitterDistance = 338;
            this.splitContainerBase.TabIndex = 0;
            // 
            // splitContainerErrorInfo
            // 
            this.splitContainerErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerErrorInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerErrorInfo.Name = "splitContainerErrorInfo";
            // 
            // splitContainerErrorInfo.Panel1
            // 
            this.splitContainerErrorInfo.Panel1.Controls.Add(this.tvError);
            // 
            // splitContainerErrorInfo.Panel2
            // 
            this.splitContainerErrorInfo.Panel2.Controls.Add(this.txtValue);
            this.splitContainerErrorInfo.Size = new System.Drawing.Size(498, 338);
            this.splitContainerErrorInfo.SplitterDistance = 166;
            this.splitContainerErrorInfo.TabIndex = 0;
            // 
            // tvError
            // 
            this.tvError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvError.Location = new System.Drawing.Point(0, 0);
            this.tvError.Name = "tvError";
            this.tvError.Size = new System.Drawing.Size(166, 338);
            this.tvError.TabIndex = 0;
            this.tvError.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvError_AfterSelect);
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(0, 0);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValue.Size = new System.Drawing.Size(328, 338);
            this.txtValue.TabIndex = 0;
            // 
            // btnSaveLocally
            // 
            this.btnSaveLocally.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLocally.Location = new System.Drawing.Point(289, 3);
            this.btnSaveLocally.Name = "btnSaveLocally";
            this.btnSaveLocally.Size = new System.Drawing.Size(104, 23);
            this.btnSaveLocally.TabIndex = 1;
            this.btnSaveLocally.Text = "Save Error in file";
            this.btnSaveLocally.UseVisualStyleBackColor = true;
            this.btnSaveLocally.Click += new System.EventHandler(this.btnSaveLocally_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoEllipsis = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(412, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseMnemonic = false;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // SaveDialog
            // 
            this.SaveDialog.Filter = "Error files|*.error|All files|*.*";
            // 
            // AdvancedInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(498, 371);
            this.Controls.Add(this.splitContainerBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(514, 405);
            this.MinimumSize = new System.Drawing.Size(514, 405);
            this.Name = "AdvancedInformationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error Details";
            this.Load += new System.EventHandler(this.AdvancedInformationForm_Load);
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBase)).EndInit();
            this.splitContainerBase.ResumeLayout(false);
            this.splitContainerErrorInfo.Panel1.ResumeLayout(false);
            this.splitContainerErrorInfo.Panel2.ResumeLayout(false);
            this.splitContainerErrorInfo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerErrorInfo)).EndInit();
            this.splitContainerErrorInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerBase;
        private System.Windows.Forms.SplitContainer splitContainerErrorInfo;
        private System.Windows.Forms.TreeView tvError;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnSaveLocally;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
    }
}

