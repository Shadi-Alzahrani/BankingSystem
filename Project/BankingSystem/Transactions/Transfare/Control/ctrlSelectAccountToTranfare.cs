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

namespace BankingSystem.Transactions.Transfare.Control
{
    public partial class ctrlSelectAccountToTranfare : UserControl
    {
        
        public ctrlSelectAccountToTranfare()
        {
            InitializeComponent();
        }

        public int SelectedAccID=-1;
        private void ctrlSelectAccountToTranfare_Load(object sender, EventArgs e)
        {

        }

        private async void txtAccountID_TextChanged(object sender, EventArgs e)
        {
            
           
            
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrWhiteSpace(txtAccountID.Text.Trim()))
                { return; }

            int AccID = Convert.ToInt32(txtAccountID.Text.Trim());

            var _SelectedAcc = await ClsClientAccount.GetAccountForTransfer(AccID);
            if (_SelectedAcc.FullName != "")
            {
                lblFullName.Text = _SelectedAcc.FullName;
                SelectedAccID = Convert.ToInt32(txtAccountID.Text);
                lblAccID.Text = _SelectedAcc.AccountNumber;
            }
            else
            {
                MessageBox.Show("Selected Account Does Not Exist,Select another one!",
                    "Not Found",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                SelectedAccID = -1;
               
                return;
            }
        }

        private void txtAccountID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
