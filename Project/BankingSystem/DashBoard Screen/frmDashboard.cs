using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.Controls;
using BankingSystem.Global;
using BankingSystem_Business;
using System.Threading.Tasks;
namespace BankingSystem.DashBoard_Screen
{
    public partial class frmDashboard : Form
    {
        private DataTable DtAllAccountsTransActions;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            clsGlobal.GlobalClient = ClsClient.findClient(10000);


            Task task = LoadData(clsGlobal.GlobalClient);

            DtAllAccountsTransActions = await clsGlobal.GlobalClient.GetAllAccountsTransActions();

            dgvAllClientsTransActions.DataSource = DtAllAccountsTransActions;

            if(dgvAllClientsTransActions.RowCount>0)
            {
                dgvAllClientsTransActions.Columns[0].HeaderText = "T.DateTime ";
                dgvAllClientsTransActions.Columns[0].Width = 200;
              
                dgvAllClientsTransActions.Columns[1].HeaderText = "T.Type ";
                dgvAllClientsTransActions.Columns[1].Width = 100;

                dgvAllClientsTransActions.Columns[2].HeaderText = "T.Description ";
                dgvAllClientsTransActions.Columns[2].Width = 150;

                dgvAllClientsTransActions.Columns[3].HeaderText = "T.Amount ";
                dgvAllClientsTransActions.Columns[3].Width = 100;

                dgvAllClientsTransActions.Columns[4].HeaderText = "T.Status ";
                dgvAllClientsTransActions.Columns[4].Width = 100;

            }
           
        }

        public async Task  LoadData(ClsClient Client)
        {
            lblClientID.Text = Client.ClientID.ToString();
            lblCurrentDate.Text = DateTime.Now.ToString();
            lblClientName.Text = Client.FullName;
            
            lblNumberOfAccounts.Text= (await Client._GetNumberOFAccounts()).ToString();
            lblTotalDeposit.Text = (await Client.GetTotalAmountPerTransAction(ClsClient.enTransactionType.Deposit)).ToString() + " SR";
            lblTotalWithDraw.Text = (await Client.GetTotalAmountPerTransAction(ClsClient.enTransactionType.Withdrawal)).ToString() + " SR";
            lblTotalTransfares.Text = (await Client.GetTotalAmountPerTransAction(ClsClient.enTransactionType.Transfer)).ToString() + " SR";
            lblTotalBalances.Text = Client.AccountsTotalBalance.ToString();
            if (File.Exists(Client.ImageUrl))
            {
                pbClientPic.ImageLocation = Client.ImageUrl;
            }
               
            
        

           await  _FillClientAccountInfoIntoAccountsPanel();

        }

        private async Task _FillClientAccountInfoIntoAccountsPanel ()
        {
            DataTable dtAccounts = new DataTable();
            dtAccounts = await clsGlobal.GlobalClient.GetAllAccounts();
            
            foreach (DataRow account in dtAccounts.Rows)
            {
                CtrlAccountInfo accountInfo = new CtrlAccountInfo();
                accountInfo.AccountName = account["AccountName"].ToString();
                accountInfo.AccountBalance = (decimal)account["Balance"];
                accountInfo.AccountID = account["AccountNumber"].ToString();
                accountInfo.SetValues(accountInfo.AccountName, accountInfo.AccountBalance, accountInfo.AccountID);
                flpAccounts.Controls.Add(accountInfo);
            }
        }
    }
}
