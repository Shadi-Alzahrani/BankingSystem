using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem_Business;

namespace BankingSystem.Manage_Clients_Accounts
{
    public partial class frmClientAccountsList : Form
    {

        private DataTable dtAllAccounts;
        public frmClientAccountsList()
        {
            InitializeComponent();
        }

      


        private async void frmClientAccountsList_Load(object sender, EventArgs e)
        {
            dtAllAccounts = await ClsClient.GetFullAccountsInfo();
            dgvAllAccounts.DataSource = dtAllAccounts;

            if (dgvAllAccounts.Rows.Count > 0)
            {
                dgvAllAccounts.Columns[0].HeaderText = "Account ID";
                dgvAllAccounts.Columns[0].Width = 150;

                dgvAllAccounts.Columns[1].HeaderText = "Account Name";
                dgvAllAccounts.Columns[1].Width = 150;

                dgvAllAccounts.Columns[2].HeaderText = "Client Name";
                dgvAllAccounts.Columns[2].Width = 150;

                dgvAllAccounts.Columns[3].HeaderText = "Account Status";
                dgvAllAccounts.Columns[3].Width = 150;

                dgvAllAccounts.Columns[4].HeaderText = "Close Date";
                dgvAllAccounts.Columns[4].Width = 150;

                dgvAllAccounts.Columns[5].HeaderText = "Close Reason";
                dgvAllAccounts.Columns[5].Width = 150;
            }
        }

        private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int CurrentID =  (int )dgvAllAccounts.CurrentRow.Cells[0].Value;

            ClsClientAccount CurrentAccount = await ClsClientAccount.FindClientAccount(CurrentID); 
            
           if(CurrentAccount==null)
            {
                MessageBox.Show("Failed To Load Account Data please Try another time ","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            bool IsActive = CurrentAccount.AccountStatusID == (int)ClsClientAccount.enAccountsStatus.Active;
            bool DeActive = CurrentAccount.AccountStatusID == (int)ClsClientAccount.enAccountsStatus.anActive;
            bool IsSuspended = CurrentAccount.AccountStatusID == (int)ClsClientAccount.enAccountsStatus.Suspended;
            bool IsClosed = CurrentAccount.AccountStatusID == (int)ClsClientAccount.enAccountsStatus.Closed;


            activeToolStripMenuItem.Enabled = DeActive;
            deActiveToolStripMenuItem.Enabled = IsActive;
           suspendedToolStripMenuItem.Enabled = !IsSuspended&&!IsClosed;
            closedToolStripMenuItem.Enabled = !IsClosed;
           


        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentAccountID = (int)dgvAllAccounts.CurrentRow.Cells[0].Value;
            ClsClientAccount.UpdateAccountStatus(CurrentAccountID,ClsClientAccount.enAccountsStatus.Active,null);
            frmClientAccountsList_Load(null,null);
        }

        private void deActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentAccountID = (int)dgvAllAccounts.CurrentRow.Cells[0].Value;
            ClsClientAccount.UpdateAccountStatus(CurrentAccountID, ClsClientAccount.enAccountsStatus.anActive, null);
            frmClientAccountsList_Load(null, null);
        }

        private void suspendedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentAccountID = (int)dgvAllAccounts.CurrentRow.Cells[0].Value;
            ClsClientAccount.UpdateAccountStatus(CurrentAccountID, ClsClientAccount.enAccountsStatus.Suspended, null);
            frmClientAccountsList_Load(null, null);
        }

        private void closedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentAccountID = (int)dgvAllAccounts.CurrentRow.Cells[0].Value;
            frmCloseClientAccount frm  = new frmCloseClientAccount(CurrentAccountID);
            frm.ShowDialog();
            frmClientAccountsList_Load(null, null);

        }
    }
}
