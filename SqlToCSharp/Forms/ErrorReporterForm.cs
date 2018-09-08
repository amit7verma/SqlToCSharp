using SqlToCSharp.Properties;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace SqlToCSharp.Forms
{
    public partial class ErrorReporterForm : Form
    {
        public ErrorReporterForm()
        {
            InitializeComponent();
        }

        public static void ShowError(Exception ex, Form parent)
        {
            var form = new ErrorReporterForm();
            form.Text = $"Error - {parent.Text}";
            form.imageControl.Image = Resources.error_48;
            form.errorControl.Text = ex.Message;
            form.ShowDialog(parent);
        }

        public static void ShowInformation(string message, Form parent)
        {
            var form = new ErrorReporterForm();
            form.Text = $"Information - {parent.Text}";
            form.imageControl.Image = Resources.Info_icon_48;
            form.errorControl.Text = message;
            form.ShowDialog(parent);
        }

        public static void ShowWarning(string message, Form parent)
        {
            var form = new ErrorReporterForm();
            form.Text = $"Warning - {parent.Text}";
            form.imageControl.Image = Resources.warning_48;
            form.errorControl.Text = message;
            form.ShowDialog(parent);
        }

        public static void ShowSuccess(string message, Form parent)
        {
            var form = new ErrorReporterForm();
            form.Text = $"Success - {parent.Text}";
            form.imageControl.Image = Resources.ok_48;
            form.errorControl.Text = message;
            form.ShowDialog(parent);
        }
    }
}
