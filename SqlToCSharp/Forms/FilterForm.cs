using System;
using System.Windows.Forms;

namespace SqlToCSharp.Forms
{
    /// <summary>
    /// This class represents the Filter criteria which will be applied on objects of TreeNode.
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Database Server name.
        /// </summary>
        private string Server = string.Empty;

        /// <summary>
        /// Database name.
        /// </summary>
        private string Database = string.Empty;

        /// <summary>
        /// Type of Filter e.g. 'Contains', 'Equals', 'Does not contain'
        /// </summary>
        public string FilterType { get;  set; }

        /// <summary>
        /// Filter string
        /// </summary>
        public string FilterText { get;  set; }

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="dbName">Database name.</param>
        public FilterForm(string serverName, string dbName)
        {
            InitializeComponent();
            this.Server = serverName;
            this.Database = dbName;
        }

        /// <summary>
        /// Load event handler of FilterForm.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event argument.</param>
        private void FilterForm_Load(object sender, EventArgs e)
        {
            ddlFilterType.SelectedIndex = 0;
            lblServer.Text = Server;
            lblDB.Text = Database;
        }

        /// <summary>
        /// Reset action handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event argument.</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ddlFilterType.SelectedIndex = 0;
            this.txtFilter.Text = string.Empty;
        }

        /// <summary>
        /// Apply action handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event argument.</param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            this.FilterText = txtFilter.Text;
            this.FilterType = ddlFilterType.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Close action handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event argument.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
