using SqlToCSharp.Classes;
using SqlToCSharp.Helpers;
using SqlToCSharp.UserControls;
using System;
using System.Collections.Generic;
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
            try
            {
                if (settings != null)
                    settings = null;

                if (e.ClassName.Length == 0)
                    e.ClassName = dbTreeView.GetSelectedDbItem();

                if (creator == null)
                    return;

                grpCSharpCode.Visible = true;
                settings = CSharpSettings.GetCSharpSettings(e);
                SQLHelper sql = new SQLHelper(AppStatic.DBConnectionString);
                var code = creator.GenerateCSharpCode(
                    settings
                    , sql.GetClrProperties(
                        dbTreeView.GetSelectedDbItemSchema()
                        , dbTreeView.GetSelectedDbItem()
                        , dbTreeView.GetDBObjectType()
                        )
                    );
                cSharpCodeControl.Text = code;
                grpCSharpCode.Text = $"{grpCSharpCode.Text} ({settings.ClassName})";
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
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
            try
            {
                grpCSharpCode.Text = "C# Class";
                if (creator != null)
                    creator = null;

                creator = new CSharpClassCreator();
                creatorSettings.ApplySettings();
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
                throw;
            }
        }

        /// <summary>
        /// Generate Simple Typed Datatable menu-item click evennt handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event Argument.</param>
        private void generateSimpleTypedDatatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                grpCSharpCode.Text = "Simple Typed Datatable";
                if (creator != null)
                    creator = null;

                creator = new TypedDatatableCreator();
                creatorSettings.ApplySettings();
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
        }

        private void dbTreeView_GenerateCSharpClass(object sender, EventArgs e)
        {
            pocoGenerateMenuItem_Click(sender, e);
        }

        private void dbTreeView_GenerateTypedDatatable(object sender, EventArgs e)
        {
            generateSimpleTypedDatatableToolStripMenuItem_Click(sender, e);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cSharpCodeControl.SelectAll();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cSharpCodeControl.Copy();
        }

        private void cSharpCodeControl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    textBoxContextMenu.Show(cSharpCodeControl, e.Location);
                }
            }
            catch (Exception ex)
            {
                ErrorViewerForm.ShowError(ex, this);
            }
        }
    }
}
