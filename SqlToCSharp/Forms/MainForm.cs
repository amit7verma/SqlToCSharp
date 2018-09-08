using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlToCSharp.UserControls;
using SqlToCSharp.Classes;
using SqlToCSharp.Helpers;

namespace SqlToCSharp.Forms
{
    public partial class MainForm : Form
    {
        CSharpCreatorBase creator = null;
        private Dictionary<string, List<string[]>> dbObjects = null;

        public MainForm()
        {
            InitializeComponent();
            grpCSharpCode.Visible = false;
        }

        CSharpSettings settings = null;

        private void creatorSettings_ClassSettingChangedEventHandler(ClassSettings sender, ClassSettingsEventArgs e)
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
                MessageHelper.ShowError(ex.Message, this);
            }
        }

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

        private void FormLoad()
        {
            LoadData();
            this.dbTreeView.LoadTreeView(this.dbObjects, AppStatic.Server, AppStatic.Database);
            creator = null;
            grpCSharpCode.Visible = false;
        }

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
                MessageHelper.ShowError(ex.Message, this);
            }
        }
        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCode();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message, this);
            }
        }

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

        private void pocoGenerateMenuItem_Click(object sender, EventArgs e)
        {
            grpCSharpCode.Text = "C# Class";
            if (creator != null)
                creator = null;

            creator = new CSharpClassCreator();
            creatorSettings.ApplySettings();
        }

        private void generateSimpleTypedDatatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpCSharpCode.Text = "Simple Typed Datatable";
            if (creator != null)
                creator = null;

            creator = new TypedDatatableCreator();
            creatorSettings.ApplySettings();
        }


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
        private string GetSelectedDbItemSchema()
        {
            if (dbTreeView.TreeView.SelectedNode == null)
                return string.Empty;

            var item = dbTreeView.TreeView.SelectedNode.Text.Trim();
            return item.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (cSharpCodeControl.Text.Trim().Length > 0 && e.Control && e.Control && e.KeyCode == Keys.S)
            {
                SaveCode();
            }
        }
    }
}
