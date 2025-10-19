using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BankingSystem.Utils;
using BankingSystem_Business;

namespace BankingSystem.DashBoard_Screen.Admin_Dashboard
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private async void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            double totalWithDraw = (double)(await ClsClientAccount.GetclientsTotalTransaction(ClsClientAccount.enTransactionType.WithDraw));
            double TotalDeposit = (double)(await ClsClientAccount.GetclientsTotalTransaction(ClsClientAccount.enTransactionType.Deposit));
            double TotalTransfare = (double)(await ClsClientAccount.GetclientsTotalTransaction(ClsClientAccount.enTransactionType.Transfare));
            _LoadData();
            clsUtil.CreateBarChart(chart1, "Transfare", TotalTransfare, "Deposit", TotalDeposit,"WithDraw", totalWithDraw);    


        }


       
        private async void _LoadData()
        {
           lblNumberOFClients.Text = (await ClsClient.GetNumberOfClients()).ToString();
           lblTotalAccounts.Text=  (await ClsClientAccount.GetNumberOfAccounts()).ToString();
           lblTotalNumberOFTranactions.Text=(await ClsClientAccount.GetNumberOfTransactions()).ToString();
            lblTotalBalances.Text = (await ClsClientAccount.GetTotalBalnces()).ToString();
            lblDeposit.Text = (await ClsClientAccount.GetclientsTotalTransaction(ClsClientAccount.enTransactionType.Deposit)).ToString();
            lblWithdraw.Text = (await ClsClientAccount.GetclientsTotalTransaction(ClsClientAccount.enTransactionType.WithDraw)).ToString();
            lblTranfare.Text = (await ClsClientAccount.GetclientsTotalTransaction(ClsClientAccount.enTransactionType.Transfare)).ToString();
        }

       
    }
}


