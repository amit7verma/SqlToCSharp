using SqlToCSharp.Classes;
using SqlToCSharp.Forms;
using SqlToCSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SqlToCSharp
{
    public partial class DBTreeView : UserControl
    {
        /// <summary>
        /// Dictionary to cache the database objects.
        /// </summary>
        private Dictionary<string, List<string[]>> _dbObjects = null;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler GenerateCSharpClass;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler GenerateTypedDatatable;

        public event TreeViewEventHandler SelectedNodeChanged;

        /// <summary>
        /// Server name of currennt database connection.
        /// </summary>
        private string _server = string.Empty;

        /// <summary>
        /// Database name of current database connection.
        /// </summary>
        private string _dbName = string.Empty;

        /// <summary>
        /// Array of name of nodes, on which filter can be added.
        /// </summary>
        private readonly string[] filterableNodes = new string[5] { Constants.Tables, Constants.TableValuedFunctions, Constants.Views, Constants.StoredProcedures, Constants.UserDefinedTableTypes };

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DBTreeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The TreeView control.
        /// </summary>
        public TreeView TreeView => this.tvDBItems;

        /// <summary>
        /// Populates data into TreeView Control.
        /// </summary>
        /// <param name="dbItems">Dictionary of database items.</param>
        /// <param name="server">Server name.</param>
        /// <param name="database">Database name.</param>
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
                TreeNode dbItemTypeNode = serverNode.Nodes.Add(dbItemType);
                LoadTreeNode(dbItemTypeNode);
            }

            n.Expand();
            serverNode.Expand();
        }

        /// <summary>
        /// Populates data into TreeNode UI control.
        /// </summary>
        /// <param name="n">An object of type TreeNode, in which data has to be populated.</param>
        public void LoadTreeNode(TreeNode n)
        {
            List<string[]> listProc = _dbObjects[n.Text];

            var dbObjectFilter = string.Empty;
            var filterType = string.Empty;

            if (n.Tag is FilterForm filterForm)
            {
                dbObjectFilter = filterForm.FilterText;
                filterType = filterForm.FilterType;
            }

            for (int j = 0; j < listProc.Count; j++)
            {
                if (CanBeAdded(listProc[j][1], dbObjectFilter, filterType))
                {
                    n.Nodes.Add(listProc[j][0] + "." + listProc[j][1]);
                }
            }
        }

        /// <summary>
        /// Decides where the input item can be added to TreeNode or TreeView as per filter specified.
        /// </summary>
        /// <param name="input">The database object name.</param>
        /// <param name="filter">Filter applied.</param>
        /// <param name="filterType">Type of filter.</param>
        /// <returns>If can be added then True else False.</returns>
        private bool CanBeAdded(string input, string filter, string filterType)
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

        /// <summary>
        /// Applies Filter on TreeNode UI control as per specified filter string and filter type.
        /// </summary>
        /// <param name="tn">Object of TreeNode type.</param>
        /// <param name="filter">Filter string.</param>
        /// <param name="filterType">Type of Filter</param>
        private void FilterNode(TreeNode tn, string filter, string filterType)
        {
            List<TreeNode> addList = new List<TreeNode>();
            for (int i = 0; i < tn.Nodes.Count; i++)
            {
                if (CanBeAdded(tn.Nodes[i].Text, filter, filterType))
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

        /// <summary>
        /// Click event handler when 'Filter' menu item is clicked.
        /// </summary>
        /// <param name="sender">sender of this event.</param>
        /// <param name="e">Event argument of this handler.</param>
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
                                var dbObjectFilter = filterForm.FilterText.Trim();
                                var filterType = filterForm.FilterType.Trim();
                                FilterNode(tn, dbObjectFilter, filterType);
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
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        /// <summary>
        /// Event handler when 'Reset filter' menu item is clicked.
        /// </summary>
        /// <param name="sender">sender of this event.</param>
        /// <param name="e">Event argument of this handler.</param>
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
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        /// <summary>
        /// Resets filter criteria for specified TreeNode object.
        /// </summary>
        /// <param name="tn">The TreeNode object on which filter criteria has to be reset.</param>
        private void ResetFilter(TreeNode tn)
        {
            if (tn.Tag is FilterForm filterForm)
            {
                filterForm.Dispose();
                filterForm = null;
                tn.Tag = null;
            }
            tn.Nodes.Clear();
            tn.Text = tn.Text.Replace(Constants.FilteredText, string.Empty);
            LoadTreeNode(tn);
        }

        /// <summary>
        /// Event handler of 'Copy Name' mmenu Item cllick.
        /// </summary>
        /// <param name="sender">sender of this event.</param>
        /// <param name="e">event argument of this event.</param>
        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvDBItems != null && tvDBItems.SelectedNode != null)
                    Clipboard.SetText(tvDBItems.SelectedNode.Text);
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
                throw;
            }
        }

        /// <summary>
        /// MouseClick event handler to intercept the mouse right-click, to show Context Menu.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void tvDBItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.TreeView.SelectedNode = e.Node;

                    if (e.Node.Text.Trim().StartsWithAnItemInArray(filterableNodes))
                    {
                        filterSettingToolItem.Enabled = resetFilterToolItem.Enabled = true;
                        generateCClassToolStripMenuItem.Enabled = generateSimpleTypedDatatableToolStripMenuItem.Enabled = false;
                    }
                    else if (e.Node.Parent != null && e.Node.Parent.Text.Trim().StartsWithAnItemInArray(filterableNodes))
                    {
                        filterSettingToolItem.Enabled = resetFilterToolItem.Enabled = false;
                        generateCClassToolStripMenuItem.Enabled = generateSimpleTypedDatatableToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        filterSettingToolItem.Enabled = resetFilterToolItem.Enabled = false;
                        generateCClassToolStripMenuItem.Enabled = generateSimpleTypedDatatableToolStripMenuItem.Enabled = false;
                    }
                    cntxMenu.Show(tvDBItems, e.Location);
                }
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        /// <summary>
        /// Gets name of selected database object, without schema.
        /// </summary>
        /// <returns>Name of database object, without schema.</returns>
        public string GetSelectedDbItem()
        {
            if (this.TreeView.SelectedNode == null)
                return string.Empty;

            var item = this.TreeView.SelectedNode.Text.Trim();
            var names = item.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length > 1)
                return names[1];

            return string.Empty;
        }

        /// <summary>
        /// Gets schema name of selected database object.
        /// </summary>
        /// <returns>Schema name of selected database object.</returns>
        public string GetSelectedDbItemSchema()
        {
            if (this.TreeView.SelectedNode == null)
                return string.Empty;

            var item = this.TreeView.SelectedNode.Text.Trim();
            return item.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        /// <summary>
        /// Gets database object type of selected database object.
        /// </summary>
        /// <returns>DBObjectType</returns>
        public DBObjectType GetDBObjectType()
        {
            var item = this.TreeView.SelectedNode;
            if (item != null && item.Parent != null)
            {
                item = item.Parent;
                switch (item.Text.Trim())
                {
                    case Constants.Tables: return DBObjectType.Table;
                    case Constants.Views: return DBObjectType.Views;
                    case Constants.TableValuedFunctions: return DBObjectType.Functions;
                    case Constants.StoredProcedures: return DBObjectType.StoredProcedure;
                    case Constants.UserDefinedTableTypes: return DBObjectType.UserDefinedTableTypes;
                }
            }
            return DBObjectType.None;
        }

        public string GetSelectedNode()
        {
            return this.TreeView.SelectedNode.Text;
        }

        private void generateCClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateCSharpClass(sender, e);
        }

        private void generateSimpleTypedDatatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTypedDatatable(sender, e);
        }

        private void tvDBItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, e);
        }
    }
}
