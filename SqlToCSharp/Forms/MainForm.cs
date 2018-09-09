using SqlToCSharp.Classes;
using SqlToCSharp.Helpers;
using SqlToCSharp.UserControls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SqlToCSharp.Forms
{
    /// <summary>
    /// The Main form which contains all the features of Sql to C# code generator.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// C# Code generator base class.
        /// </summary>
        CSharpCreatorBase creator = null;

        /// <summary>
        /// Dictionary of Database objects types and Database objects.
        /// </summary>
        private Dictionary<string, List<string[]>> dbObjects = null;

        /// <summary>
        /// Default Contructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            grpCSharpCode.Visible = false;
        }

        /// <summary>
        /// Settings object.
        /// </summary>
        CSharpSettings settings = null;

        /// <summary>
        /// Settings changed event handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event Argument.</param>
        private void creatorSettings_ClassSettingChangedEventHandler(ClassGeneratorSettings sender, ClassGeneratorSettingsEventArgs e)
        {
            if (settings != null)
                settings = null;

            if (e.ClassName.Length == 0)
                e.ClassName = GetSelectedDbItem();

            if (creator == null)
                return;

            grpCSharpCode.Visible = true;
            settings = CSharpSettings.GetCSharpSettings(e);
            creator.Settings = settings;
            StringBuilder code = new StringBuilder();
            SQLHelper sql = new SQLHelper(AppStatic.DBConnectionString);
            creator.WriteClass(ref code, sql.GetClrProperties(GetSelectedDbItemSchema(), GetSelectedDbItem(), GetDBObjectType()));
            cSharpCodeControl.Text = code.ToString();
        }

        /// <summary>
        /// Load event handler of Main Form.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event Argument.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (AppStatic.DBConnectionString.Length == 0)
                {
                    var sqlConnForm = new SQLConnectionForm();
                    if (sqlConnForm.ShowDialog(this) == DialogResult.OK && sqlConnForm.ConnectionSuccess)
                    {
                        AppStatic.DBConnectionString = sqlConnForm.ConnReq.SqlConn.ConnectionString;
                        AppStatic.Database = sqlConnForm.ConnReq.SqlConn.Database;
                        AppStatic.Server = sqlConnForm.ConnReq.SqlConn.DataSource;

                        FormLoad();
                    }
                    else
                        this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        /// <summary>
        /// Loads Database object types and Database object names to Dictionary object.
        /// </summary>
        private void LoadData()
        {
            if (dbObjects != null)
            {
                dbObjects.Clear();
                dbObjects = null;
            }
            dbObjects = new Dictionary<string, List<string[]>>();
            SQLHelper sql = new SQLHelper(AppStatic.DBConnectionString);
            List<string> listDB = new List<string>() { AppStatic.Database };

            var listDbItems = sql.GetTables();
            dbObjects.Add(Constants.Tables, listDbItems);

            listDbItems = sql.GetViews();
            dbObjects.Add(Constants.Views, listDbItems);

            listDbItems = sql.GetProcedures();
            dbObjects.Add(Constants.StoredProcedures, listDbItems);

            listDbItems = sql.GetTableValuedFunctions();
            dbObjects.Add(Constants.TableValuedFunctions, listDbItems);

            listDbItems = sql.GetTableTypes();
            dbObjects.Add(Constants.UserDefinedTableTypes, listDbItems);

        }

        /// <summary>
        /// Configures the form on load.
        /// </summary>
        private void FormLoad()
        {
            LoadData();
            this.dbTreeView.LoadTreeView(this.dbObjects, AppStatic.Server, AppStatic.Database);
            creator = null;
            grpCSharpCode.Visible = false;
        }

        /// <summary>
        /// Database change menu-item click event handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event Argument.</param>
        private void dbConnectionStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var sqlConnForm = new SQLConnectionForm();
                if (sqlConnForm.ShowDialog(this) == DialogResult.OK && sqlConnForm.ConnectionSuccess)
                {
                    AppStatic.DBConnectionString = sqlConnForm.ConnReq.SqlConn.ConnectionString;
                    AppStatic.Database = sqlConnForm.ConnReq.SqlConn.Database;
                    AppStatic.Server = sqlConnForm.ConnReq.SqlConn.DataSource;

                    FormLoad();

                }
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        /// <summary>
        /// Save to file menu-item click event handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event Argument.</param>
        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCode();
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        /// <summary>
        /// Saves code to .cs file.
        /// </summary>
        private void SaveCode()
        {
            var diagSave = new SaveFileDialog();
            diagSave.FileName = settings.ClassName + ".cs";
            diagSave.Filter = "C# files|*.cs";
            if (diagSave.ShowDialog(this) == DialogResult.OK)
            {
                System.IO.File.WriteAllText(diagSave.FileName, cSharpCodeControl.Text);
            }
        }

        /// <summary>
        /// Generate C# Class menu-item click event handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event Argument.</param>
        private void pocoGenerateMenuItem_Click(object sender, EventArgs e)
        {
            grpCSharpCode.Text = "C# Class";
            if (creator != null)
                creator = null;

            creator = new CSharpClassCreator();
            creatorSettings.ApplySettings();
        }

        /// <summary>
        /// Generate Simple Typed Datatable menu-item click evennt handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event Argument.</param>
        private void generateSimpleTypedDatatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpCSharpCode.Text = "Simple Typed Datatable";
            if (creator != null)
                creator = null;

            creator = new TypedDatatableCreator();
            creatorSettings.ApplySettings();
        }

        /// <summary>
        /// Gets name of selected database object, without schema.
        /// </summary>
        /// <returns>Name of database object, without schema.</returns>
        private string GetSelectedDbItem()
        {
            if (dbTreeView.TreeView.SelectedNode == null)
                return string.Empty;

            var item = dbTreeView.TreeView.SelectedNode.Text.Trim();
            var names = item.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length > 1)
                return names[1];

            return string.Empty;
        }

        /// <summary>
        /// Gets schema name of selected database object.
        /// </summary>
        /// <returns>Schema name of selected database object.</returns>
        private string GetSelectedDbItemSchema()
        {
            if (dbTreeView.TreeView.SelectedNode == null)
                return string.Empty;

            var item = dbTreeView.TreeView.SelectedNode.Text.Trim();
            return item.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        /// <summary>
        /// Gets database object type of selected database object.
        /// </summary>
        /// <returns>SQLHelper.DBObjectType</returns>
        private SQLHelper.DBObjectType GetDBObjectType()
        {
            var item = dbTreeView.TreeView.SelectedNode;
            if (item != null && item.Parent != null)
            {
                item = item.Parent;
                switch (item.Text.Trim())
                {
                    case Constants.Tables: return SQLHelper.DBObjectType.Table;
                    case Constants.Views: return SQLHelper.DBObjectType.Views;
                    case Constants.TableValuedFunctions: return SQLHelper.DBObjectType.Functions;
                    case Constants.StoredProcedures: return SQLHelper.DBObjectType.StoredProcedure;
                    case Constants.UserDefinedTableTypes: return SQLHelper.DBObjectType.UserDefinedTableTypes;
                }
            }
            return SQLHelper.DBObjectType.None;
        }        
    }
}
