using System;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool loginSuccessful = false;

            FormLogin login = new FormLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Attempt login

            }


            if (true) // TODO Login successful
            {
                Application.Run(new FormMain());
            }
        }
    }
}
