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
using System.Drawing.Printing;
using System.Runtime.InteropServices;
namespace BankingSystem.DashBoard_Screen
{
    public partial class frmDashboard : Form
    {
        int CurrentPage = 1;
        int totalRecords = 0;
        int totalPages = 0;



        private DataTable DtAllAccountsTransActions;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            if(!clsGlobal._GlobalUser.IsAdmin)
            {
                await LoadData(clsGlobal.GlobalClient);

                LoadTransactionGrid(CurrentPage);
            }
           
           
        }
        

        public async Task LoadData(ClsClient Client)
        {
            lblClientID.Text = Client.ClientID.ToString();
            lblCurrentDate.Text = DateTime.Now.ToString();
            lblClientName.Text = Client.FullName;

            lblNumberOfAccounts.Text = (await Client._GetNumberOFAccounts()).ToString();
            lblTotalDeposit.Text = (await Client.GetTotalAmountPerTransAction(ClsClient.enTransactionType.Deposit)).ToString() + " SR";
            lblTotalWithDraw.Text = (await Client.GetTotalAmountPerTransAction(ClsClient.enTransactionType.Withdrawal)).ToString() + " SR";
            lblTotalTransfares.Text = (await Client.GetTotalAmountPerTransAction(ClsClient.enTransactionType.Transfer)).ToString() + " SR";
            lblCurrentPage.Text = CurrentPage.ToString();
            decimal TotalBalance = await Client.GetAccountTotalBalance();
            lblTotalBalances.Text = TotalBalance.ToString();
            _EnableDisableNextPrevBtn();



            if (File.Exists(Client.ImageUrl))
            {
                pbClientPic.ImageLocation = Client.ImageUrl;
            }




            await _FillClientAccountInfoIntoAccountsPanel();

        }

        private async Task _FillClientAccountInfoIntoAccountsPanel()
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

        private async void LoadTransactionGrid(int pageNumber)
        {

            totalRecords = await clsGlobal.GlobalClient.GetTotalTransactions();
            totalPages = (int)Math.Ceiling(totalRecords / (double)4);
            lblToPages.Text = totalPages.ToString();
            DtAllAccountsTransActions = await clsGlobal.GlobalClient.GetAllAccountsTransActions(CurrentPage);

            dataGridView1.DataSource = DtAllAccountsTransActions;

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Columns[0].HeaderText = "T.Type ";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Amount";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "T.Description ";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "T.Status";

                dataGridView1.Columns[4].HeaderText = "T.Date ";
                dataGridView1.Columns[4].Width = 150;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
                CurrentPage++;
            lblCurrentPage.Text = CurrentPage.ToString();
            LoadTransactionGrid(CurrentPage);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
           

             CurrentPage--;
            lblCurrentPage.Text = CurrentPage.ToString();
            LoadTransactionGrid(CurrentPage);
        }


        private void _EnableDisableNextPrevBtn()
        {
            if (CurrentPage == 1)
            {
                btnPrev.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
            }

            if(CurrentPage==totalPages)
            {
                btnNext.Enabled=false;
            }
            else
            {
                btnNext.Enabled=true;
            }

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentPage_TextChanged(object sender, EventArgs e)
        {
            _EnableDisableNextPrevBtn();
        }
    }
}
