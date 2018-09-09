using System;
using System.Windows.Forms;
using SqlToCSharp.Helpers;
using SqlToCSharp.Classes;

namespace SqlToCSharp.Forms
{
    /// <summary>
    /// Represents Form which will establish connection to Sql server database connnection.
    /// </summary>
    public partial class SQLConnectionForm : Form
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SQLConnectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Property of ConnectionRequest type.
        /// </summary>
        public ConnectionRequest ConnReq { get; private set; }

        /// <summary>
        /// Represents whether connection was established.
        /// </summary>
        public bool ConnectionSuccess { get; private set; }

        /// <summary>
        /// Form load event handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event argument</param>
        private void SQLConnectionForm_Load(object sender, EventArgs e)
        {
            ddlAuth.SelectedIndex = 0;
            txtServer.Text = System.Environment.MachineName;
            ddlDb.Focus();
        }

        /// <summary>
        /// SelectedIndexChanged event handler for Authorization dropdownlist.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event argument</param>
        private void ddlAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUser.Enabled = txtUser.Enabled = lblPass.Enabled = txtPass.Enabled = (!(ddlAuth.SelectedIndex == 0));
        }

        /// <summary>
        /// Click event handler of Cancel button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event argument</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Click event handler of Connect button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event argument</param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectionRequest req = null;
            try
            {
                if (ddlDb.SelectedValue == null || ddlDb.SelectedValue.ToString() == string.Empty)
                    throw new Exception("Invalid database");

                if (this.ddlAuth.SelectedIndex == 0)//Win auth
                {
                    req = new ConnectionRequest(txtServer.Text.Trim(), ddlDb.SelectedValue.ToString());
                }
                else
                {
                    req = new ConnectionRequest(txtServer.Text.Trim(), txtUser.Text.Trim(), txtPass.Text.Trim());
                }
                if (!req.TryConnect())
                {
                    throw new Exception("Sql Connection failed.");
                }
                this.ConnectionSuccess = true;
                this.ConnReq = req;

                AppStatic.DBConnectionString = req.SqlConn.ConnectionString;
                AppStatic.Database = req.SqlConn.Database;
                AppStatic.Server = req.SqlConn.DataSource;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.ConnectionSuccess = false;
                ErrorViewerForm.ShowError(ex, this);
                ///MessageHelper.ShowError(ex.Message, this);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Enter event handler of Database combobox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event argument</param>
        private void ddlDb_Enter(object sender, EventArgs e)
        {
            try
            {
                ConnectionRequest serverConnReq = GetServerConnection();
                var sqlHelp = new SQLHelper(serverConnReq.SqlConn.ConnectionString);
                var databases = sqlHelp.GetDatabaseList();

                ddlDb.DataSource = databases;
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        /// <summary>
        /// Creates database connection from UI controls and tries to connect.
        /// </summary>
        /// <returns>Instance of ConnectionRequest type.</returns>
        private ConnectionRequest GetServerConnection()
        {
            ConnectionRequest serverConnReq = null;

            if (this.ddlAuth.SelectedIndex == 0)//Win auth
            {
                serverConnReq = new ConnectionRequest(txtServer.Text.Trim());
            }

            else
            {
                serverConnReq = new ConnectionRequest(txtServer.Text.Trim(), txtUser.Text.Trim(), txtPass.Text.Trim());
            }

            if (!serverConnReq.TryConnect())
            {
                throw new Exception("Sql Connection failed.");
            }

            return serverConnReq;
        }
    }
}
