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

namespace BankingSystem.Transactions.Deposit_Screen.Controls
{
    public partial class CtrlSelectAccounts : UserControl
    {
        private class Account
        {
            public int AccountID { get; set; }
            public string AccountName { get; set; }
            public decimal Balance { get; set; }

            public override string ToString()
            {
                return $" Acc.ID : {AccountID}   -  Acc.Name : {AccountName} -  Acc.Balance:  {Balance} SR";
            }

        }

        public int CurrentAccountID = -1;
        public CtrlSelectAccounts()
        {
            InitializeComponent();
        }

        private void CtrlClientAccounts_Load(object sender, EventArgs e)
        {
            
        }

        public async void FillClientAccountToComboBox(int ClientID)
        {
            comboBox1.Items.Clear();
            ClsClient C = await ClsClient.findClient(10000);

            DataTable dt ;
            if (C!=null)
            {
                 dt = await C.GetAllAccounts();


                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(new Account
                    {
                        AccountID = Convert.ToInt32(dr["AccountID"]),
                        AccountName = dr["AccountName"].ToString().Trim(),
                        Balance = Convert.ToDecimal(dr["Balance"])
                    });
                }
            }
            

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var CurrentAcc = comboBox1.SelectedItem as Account;
            if (CurrentAcc != null)
            {
              CurrentAccountID = CurrentAcc.AccountID;
            }
        }

        private void gbSelectAccount_Enter(object sender, EventArgs e)
        {

        }
    }
}
