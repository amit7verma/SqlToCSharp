using SqlToCSharp.Classes;
using SqlToCSharp.Helpers;
using SqlToCSharp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SqlToCSharp
{
    public partial class DBTreeView : UserControl
    {
        private Dictionary<string, List<string[]>> _dbObjects = null;
        private string dbFilter = string.Empty;
        private string procFilter = string.Empty;
        private string filterType = string.Empty;
        private string _server = string.Empty;
        private string _dbName = string.Empty;

        private readonly string[] filterableNodes = new string[5] { Constants.Tables, Constants.TableValuedFunctions, Constants.Views, Constants.StoredProcedures, Constants.UserDefinedTableTypes };

        public DBTreeView()
        {
            InitializeComponent();
        }

        public TreeView TreeView => this.tvDBItems;
        public void LoadTreeView(Dictionary<string, List<string[]>> dbItems, string server, string database)
        {
            this._dbObjects = dbItems;
            this._server = server;
            this._dbName = database;

            if (tvDBItems.Nodes != null)
                tvDBItems.Nodes.Clear();

            TreeNode n = tvDBItems.Nodes.Add("Server(" + _server + ")");
            var serverNode = n.Nodes.Add(_dbName);
            string[] dbItemNames = _dbObjects.Keys.ToArray();
            for (int i = 0; i < dbItemNames.Length; i++)
            {
                string dbItemType = dbItemNames[i];
                if (CanBeAdded(dbItemType, dbFilter))
                {
                    TreeNode dbItemTypeNode = serverNode.Nodes.Add(dbItemType);
                    LoadTreeNode(dbItemTypeNode);
                }
            }
            n.Expand();
            serverNode.Expand();
        }
        public void LoadTreeNode(TreeNode n)
        {
            List<string[]> listProc = _dbObjects[n.Text];
            for (int j = 0; j < listProc.Count; j++)
            {
                if (CanBeAdded(listProc[j][1], procFilter))
                {
                    n.Nodes.Add(listProc[j][0] + "." + listProc[j][1]);
                }
            }
        }
        private bool CanBeAdded(string input, string filter)
        {
            if (filter.Length == 0)
                return true;
            if (filterType.Length == 0)
                return true;
            switch (filterType)
            {
                case Constants.Contains:
                    return input.ToLower().Contains(filter.ToLower());
                case Constants.DoesNotContain:
                    return !(input.ToLower().Contains(filter.ToLower()));
                case Constants.Equals:
                    return input.ToLower().Equals(filter.ToLower());
            }
            return true;
        }
        private void FilterNode(TreeNode tn, string filter)
        {
            List<TreeNode> addList = new List<TreeNode>();
            for (int i = 0; i < tn.Nodes.Count; i++)
            {
                if (CanBeAdded(tn.Nodes[i].Text, filter))
                {
                    addList.Add(tn.Nodes[i]);
                }
            }

            tn.Nodes.Clear();
            for (int i = 0; i < addList.Count; i++)
            {
                tn.Nodes.Add(addList[i]);
            }

            tn.Expand();
        }

        private void filterSettingToolItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvDBItems.SelectedNode != null)
                {
                    TreeNode tn = tvDBItems.SelectedNode;

                    if (tn.Text.Trim().StartsWithAnItemInArray(filterableNodes))
                    {
                        FilterForm filterForm = (tn.Tag as FilterForm);
                        if (filterForm == null)
                        {
                            filterForm = new FilterForm(this._server, tn.Parent.Text.Trim());
                            tn.Tag = filterForm;
                        }
                        if (filterForm.ShowDialog(this) == DialogResult.OK)
                        {
                            if (filterForm.FilterText.Length > 0)
                            {
                                this.procFilter = filterForm.FilterText.Trim();
                                this.filterType = filterForm.FilterType.Trim();
                                FilterNode(tn, procFilter);
                                if (!tn.Text.EndsWith(Constants.FilteredText))
                                    tn.Text = tn.Text + Constants.FilteredText;
                            }
                            else
                            {
                                ResetFilter(tn);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message, this);
            }
        }

        private void resetFilterToolItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvDBItems.SelectedNode != null)
                {
                    TreeNode tn = tvDBItems.SelectedNode;

                    if (tn.Text.Trim().StartsWithAnItemInArray(filterableNodes) && tn.Tag != null)
                    {
                        ResetFilter(tn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message, this);
            }
        }

        private void ResetFilter(TreeNode tn)
        {
            FilterForm filterForm = (tn.Tag as FilterForm);
            tn.Nodes.Clear();
            this.procFilter = this.filterType = string.Empty;
            tn.Text = tn.Text.Replace(Constants.FilteredText, string.Empty);
            LoadTreeNode(tn);
            filterForm.Dispose();
            filterForm = null;
            tn.Tag = null;
        }

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvDBItems != null && tvDBItems.SelectedNode != null)
                Clipboard.SetText(tvDBItems.SelectedNode.Text);
        }

        private void tvDBItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.Node.Text.Trim().StartsWithAnItemInArray(filterableNodes))
                    {
                        filterSettingToolItem.Enabled = resetFilterToolItem.Enabled = true;
                    }
                    else if (e.Node.Parent != null && e.Node.Parent.Text.Trim().StartsWithAnItemInArray(filterableNodes))
                    {
                        filterSettingToolItem.Enabled = resetFilterToolItem.Enabled = false;
                    }
                    else
                    {
                        filterSettingToolItem.Enabled = resetFilterToolItem.Enabled = false;
                    }
                    cntxMenu.Show(tvDBItems, e.Location);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message, this);
            }
        }
    }
}
