using System.Windows.Forms;

namespace SqlToCSharp.Helpers
{
    public class MessageHelper
    {
        public static void ShowError(string message, IWin32Window owner)
        {
            MessageBox.Show(owner, message, $"Error - {Control.FromHandle(owner.Handle).Text}", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        public static void ShowMessage(string message, IWin32Window owner)
        {
            MessageBox.Show(owner, message, $"Message - {Control.FromHandle(owner.Handle).Text}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
