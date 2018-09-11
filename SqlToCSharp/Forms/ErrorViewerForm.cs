using SqlToCSharp.Properties;
using System;
using System.Windows.Forms;
using SqlToCSharp.Classes;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SqlToCSharp.Forms
{
    /// <summary>
    /// This form will show Errors, Information, Warning and Sucsess messages.
    /// </summary>
    public partial class ErrorViewerForm : Form
    {
        ExceptionWrapper exWrapper = null;
        /// <summary>
        /// Default Constructor.
        /// </summary>
        private ErrorViewerForm()
        {
            InitializeComponent();
            moreDetails.Visible = false;
            moreDetailsToolTip.SetToolTip(moreDetails, "Click to see details of error.");
        }

        /// <summary>
        /// Static method, which configures the form to show "Error" and opens this form as a dialog.
        /// </summary>
        /// <param name="ex">Exception object</param>
        /// <param name="parent">Parent control of the caller.</param>
        public static void ShowError(Exception ex, Control parent)
        {
            var form = new ErrorViewerForm();
            form.exWrapper = new ExceptionWrapper(ex);
            form.Text = $"Error - {parent.Text}";
            form.errorControl.Text = ex.Message;
            form.moreDetails.Visible = true;
            form.ShowIcon = true;
            form.Icon = SystemIcons.Error;
            form.pictureBox1.Image = SystemIcons.Error.ToBitmap();
            form.ShowDialog(parent);
        }

        /// <summary>
        /// Static method, which configures the form to show "Information" and opens this form as a dialog.
        /// </summary>
        /// <param name="message">Information to be shown on form.</param>
        /// <param name="parent">Parent control of the caller.</param>
        public static void ShowInformation(string message, Control parent)
        {
            var form = new ErrorViewerForm();
            form.Text = $"Information - {parent.Text}";
            form.errorControl.Text = message;
            form.Icon = SystemIcons.Information;
            form.pictureBox1.Image = SystemIcons.Information.ToBitmap();
            form.ShowDialog(parent);
        }

        /// <summary>
        /// Static method, which configures the form to show "Warning" and opens this form as a dialog.
        /// </summary>
        /// <param name="message">Warning to be shown on form.</param>
        /// <param name="parent">Parent control of the caller.</param>
        public static void ShowWarning(string message, Form parent)
        {
            var form = new ErrorViewerForm();
            form.Text = $"Warning - {parent.Text}";
            form.errorControl.Text = message;
            form.Icon = SystemIcons.Warning;
            form.pictureBox1.Image = SystemIcons.Warning.ToBitmap();
            form.ShowDialog(parent);
        }

        /// <summary>
        /// Static method, which configures the form to show "Success" and opens this form as a dialog.
        /// </summary>
        /// <param name="message">Success message to be shown on form.</param>
        /// <param name="parent">Parent control of the caller.</param>
        public static void ShowSuccess(string message, Form parent)
        {
            var form = new ErrorViewerForm();
            form.Text = $"Success - {parent.Text}";
            form.errorControl.Text = message;
            form.Icon = Resources.ok;
            form.pictureBox1.Image = Resources.ok.ToBitmap();
            form.ShowDialog(parent);
        }

        private void moreDetails_Click(object sender, EventArgs e)
        {
            if (exWrapper != null)
                AdvancedInformationForm.ShowDetailsDialog(exWrapper);
        }

        private void ErrorViewerForm_Load(object sender, EventArgs e)
        {
            if (this.errorControl.Text.Length > 250)
            {
                var newSize = new Size((int)(this.Size.Width * 1.2), (int)(this.Size.Height * 1.2));
                this.Size = newSize;
            }
            else if (this.errorControl.Text.Length > 150)
            {
                var newSize = new Size((int)(this.Size.Width * 1.1), (int)(this.Size.Height * 1.1));
                this.Size = newSize;
            }

            this.MinimumSize = this.MaximumSize = this.Size;
        }

        private const int GWL_STYLE = -16;
        private const int WS_CLIPSIBLINGS = 1 << 26;

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
        public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);

        protected override void OnLoad(EventArgs e)
        {
            int style = (int)((long)GetWindowLong32(new HandleRef(this, this.Handle), GWL_STYLE));
            SetWindowLongPtr32(new HandleRef(this, this.Handle), GWL_STYLE, new HandleRef(null, (IntPtr)(style & ~WS_CLIPSIBLINGS)));

            base.OnLoad(e);
        }
    }
}