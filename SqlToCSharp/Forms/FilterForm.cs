using System;
using System.Windows.Forms;

namespace SqlToCSharp.Forms
{
    public partial class FilterForm : Form
    {
        private string Server = string.Empty;
        private string Database = string.Empty;
        public string FilterType { get;  set; }
        public string FilterText { get;  set; }

        public FilterForm(string svr, string dbName)
        {
            InitializeComponent();
            this.Server = svr;
            this.Database = dbName;
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            ddlFilterType.SelectedIndex = 0;
            lblServer.Text = Server;
            lblDB.Text = Database;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ddlFilterType.SelectedIndex = 0;
            this.txtFilter.Text = string.Empty;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.FilterText = txtFilter.Text;
            this.FilterType = ddlFilterType.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
