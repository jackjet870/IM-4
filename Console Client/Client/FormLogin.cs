using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{
    public partial class FormLogin : Form
    {
        public FormLogin(params ILogin[] loginMethods)
        {
            InitializeComponent();

            foreach (ILogin login in loginMethods)
            {
                // Add control to the pnlAlternateLoginMethods with the relevant icon, organisation name and tag
            }
        }

        public string Username => "";

        public string Password => this.txtPassword.Text;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;

                Close();
            }
        }
    }

    public interface ILogin
    {
        Image MyIcon { get; }

        string OrganisationName { get; }

        bool AttemptLogin(string username, string password);
    }
}
