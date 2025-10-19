using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.Global;
using BankingSystem_Business;

namespace BankingSystem.Transactions.Transfare
{
    public partial class frmTransfare : Form
    {
        public frmTransfare()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private decimal CurrentCurrencyExchange=1;
        private void ctrlSelectAccountToTranfare1_Load(object sender, EventArgs e)
        {
            _FillCurrencyComboBox();
        }

        private void frmTransfare_Load(object sender, EventArgs e)
        {
            int ClientID = clsGlobal.GlobalClient.ClientID;
            ctrlClientInfoPanel1.LoadData(ClientID);
            if(cbCurency.Items.Count==0)
            {
                _FillCurrencyComboBox();
            }
            ctrlSelectAccounts1.FillClientAccountToComboBox(ClientID);
           
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
       && !char.IsDigit(e.KeyChar)
       && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private async void cbCurency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurency.Text != "SR")
            {

                string Name = cbCurency.Text;
                clsCurrency C = await clsCurrency.FindCurrencyByCurrencySymbol(cbCurency.Text);
                if (C != null && C.CurrencyID != -1)

                {
                    CurrentCurrencyExchange = C.ExchangeRate;
                }
            }
        }

        private decimal _ConvertAmountToSR(Decimal Amount)
        {
            return Amount * CurrentCurrencyExchange;
        }

        private async void _FillCurrencyComboBox()
        {
            DataTable dt = await clsCurrency.GetAllCurrency();

            foreach (DataRow dr in dt.Rows)
            {
                if ((int)dr["Status"] != 2)
                    cbCurency.Items.Add(dr["Symbol"]);
            }

            cbCurency.SelectedIndex = 0;

        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Amount Field Must Not Be Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(ctrlSelectAccounts1.CurrentAccountID==ctrlSelectAccountToTranfare1.SelectedAccID)
            {
                MessageBox.Show(" you Can't transfare to your Current Account!, Choose another one  ", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClsClientAccount CurrentAccount = await  ClsClientAccount.FindClientAccount(clsGlobal.GlobalClient.ClientID,ctrlSelectAccounts1.CurrentAccountID);
            if (CurrentAccount == null)
            {
                MessageBox.Show(" Error occurd while retrieving Acc info, please Try Again","Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           Decimal AmountAfterExchangeRate = Convert.ToDecimal(txtAmount.Text.Trim())*CurrentCurrencyExchange;

            if(AmountAfterExchangeRate>CurrentAccount.Balance)
            {
                MessageBox.Show("Amount entered exceeds account balance",
                   "Not Allowed",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }

            int TransActionID = await CurrentAccount.Transfare(ctrlSelectAccountToTranfare1.SelectedAccID,-AmountAfterExchangeRate, rtsNote.Text.Trim());

            if (TransActionID != -1)
            {
                MessageBox.Show("Transfare completed successfully!",
              "Success",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);
                frmTransfare_Load(null, null);


            }
            else
            {
                MessageBox.Show("Tranfare failed. ", "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }

        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text.Trim()))
            {
                errorProvider1.SetError(txtAmount, "Amount Field Must Not Be Empty!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAmount, "");
                e.Cancel = false;
            }
        }
    }
}
