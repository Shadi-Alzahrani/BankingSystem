using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.DashBoard_Screen;
using BankingSystem.DashBoard_Screen.Admin_Dashboard;
using BankingSystem.Log_In_Screen;
using BankingSystem.Manage_Users;

namespace BankingSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
        }
    }
}
