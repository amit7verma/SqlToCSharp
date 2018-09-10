using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using SqlToCSharp.Classes;

namespace SqlToCSharp.Forms
{
    public partial class AdvancedInformationForm : Form
    {
        public static AdvancedInformationForm ShowDetailsDialog(ExceptionWrapper ex, IWin32Window owner = null)
        {
            AdvancedInformationForm form = new AdvancedInformationForm(ex);
            form.ShowDialog(owner);
            return form;
        }
        public ExceptionWrapper Error { get; private set; }
        private AdvancedInformationForm()
        {
            InitializeComponent();
        }
        private AdvancedInformationForm(ExceptionWrapper ex) : this()
        {
            this.Error = ex;
        }
        private void AdvancedInformationForm_Load(object sender, EventArgs e)
        {
            LoadTreeView(this.Error);
        }
        private void btnSaveLocally_Click(object sender, EventArgs e)
        {
            SaveDialog.FileName = $"Error_{DateTime.Now.ToString("yyyyMMdd")}.error";
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SaveDialog.FileName, Error.ToXmlString(), Encoding.ASCII);
            }            
        }
        private void LoadTreeView(ExceptionWrapper exWrap)
        {
            tvError.Nodes.Add(GetTreeNode(exWrap));
            tvError.ExpandAll();
            tvError.SelectedNode = tvError.Nodes[0];
        }
        private TreeNode GetTreeNode(ExceptionWrapper exWrap)
        {
            TreeNode tn = new TreeNode("Error");
            tn.Nodes.Add(new TreeNode(nameof(exWrap.Message)) { Tag = exWrap.Message });
            tn.Nodes.Add(new TreeNode(nameof(exWrap.Source)) { Tag = exWrap.Source });
            tn.Nodes.Add(new TreeNode(nameof(exWrap.Helplink)) { Tag = exWrap.Helplink });
            tn.Nodes.Add(new TreeNode(nameof(exWrap.StackTrace)) { Tag = exWrap.StackTrace });

            if (exWrap.InnerException != null)
            {
                TreeNode tnInner = GetTreeNode(exWrap.InnerException);
                tn.Nodes.Add(tnInner);
            }
            return tn;
        }
        private void tvError_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node;
            if (tn != null && tn.Tag != null)
                txtValue.Text = tn.Tag.ToString();
            else
                txtValue.Text = string.Empty;
        }
    }
}
