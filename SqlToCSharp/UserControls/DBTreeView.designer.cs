namespace SqlToCSharp
{
    partial class DBTreeView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvDBItems = new System.Windows.Forms.TreeView();
            this.cntxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterSettingToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFilterToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDBItems
            // 
            this.tvDBItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDBItems.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDBItems.HideSelection = false;
            this.tvDBItems.Location = new System.Drawing.Point(0, 0);
            this.tvDBItems.Name = "tvDBItems";
            this.tvDBItems.Size = new System.Drawing.Size(271, 565);
            this.tvDBItems.TabIndex = 1;
            this.tvDBItems.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDBItems_NodeMouseClick);
            // 
            // cntxMenu
            // 
            this.cntxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterSettingToolItem,
            this.resetFilterToolItem,
            this.copyNameToolStripMenuItem});
            this.cntxMenu.Name = "cntxMenu";
            this.cntxMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cntxMenu.Size = new System.Drawing.Size(146, 70);
            // 
            // filterSettingToolItem
            // 
            this.filterSettingToolItem.Name = "filterSettingToolItem";
            this.filterSettingToolItem.Size = new System.Drawing.Size(145, 22);
            this.filterSettingToolItem.Text = "Filter Settings";
            this.filterSettingToolItem.Click += new System.EventHandler(this.filterSettingToolItem_Click);
            // 
            // resetFilterToolItem
            // 
            this.resetFilterToolItem.Name = "resetFilterToolItem";
            this.resetFilterToolItem.Size = new System.Drawing.Size(145, 22);
            this.resetFilterToolItem.Text = "Reset Filter";
            this.resetFilterToolItem.Click += new System.EventHandler(this.resetFilterToolItem_Click);
            // 
            // copyNameToolStripMenuItem
            // 
            this.copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            this.copyNameToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.copyNameToolStripMenuItem.Text = "Copy Name";
            this.copyNameToolStripMenuItem.Click += new System.EventHandler(this.copyNameToolStripMenuItem_Click);
            // 
            // DBTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvDBItems);
            this.Name = "DBTreeView";
            this.Size = new System.Drawing.Size(271, 565);
            this.cntxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDBItems;
        private System.Windows.Forms.ContextMenuStrip cntxMenu;
        private System.Windows.Forms.ToolStripMenuItem filterSettingToolItem;
        private System.Windows.Forms.ToolStripMenuItem resetFilterToolItem;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem;
    }
}
