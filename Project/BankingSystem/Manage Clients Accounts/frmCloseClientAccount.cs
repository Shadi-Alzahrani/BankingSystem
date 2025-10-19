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
    public partial class frmCloseClientAccount : Form
    {
        int _CurrentAccountID = -1;
        public frmCloseClientAccount(int currentAccountID)
        {
            InitializeComponent();
            _CurrentAccountID = currentAccountID;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            

            string CloseReason = rtsCloseReason.Text.Trim();

          if( await  ClsClientAccount.UpdateAccountStatus(_CurrentAccountID,ClsClientAccount.enAccountsStatus.Closed,CloseReason))
            
            {
                MessageBox.Show("the account has been closed seccessfully ", "seccess"
                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           else
            {
                MessageBox.Show("an error occurd while Trying to close the Account ", "error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

          this.Close();
        }
    }
}
