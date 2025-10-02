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

namespace BankingSystem.Transactions.Deposit_Screen
{
    public partial class frmDepositAndWithDraw : Form
    {
       public  enum enTransactionType {Deposit=1,WithDraw=2 }
        enTransactionType TransType = enTransactionType.Deposit;

        decimal CurrentCurrencyExchange=1;

        public frmDepositAndWithDraw(enTransactionType TransType)
        {
            this.TransType = TransType;
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
          
            cbCurency.Items.Clear();
            ctrlClientInfoPanel1.LoadData(clsGlobal.GlobalClient.ClientID);
            ctrlSelectAccounts1.FillClientAccountToComboBox(clsGlobal.GlobalClient.ClientID);

            _FillCurrencyComboBox();
        }

        private decimal _ConvertAmountToSR(Decimal Amount )
        {
            return Amount*CurrentCurrencyExchange;
        }

        private async void _FillCurrencyComboBox()
        {
            DataTable dt =  await clsCurrency.GetAllCurrency();

            foreach (DataRow dr in dt.Rows)
            {
                if ((int)dr["Status"] !=2)
                cbCurency.Items.Add(dr["Symbol"]);
            }

            cbCurency.SelectedIndex = 0;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
           if(!this.ValidateChildren())
            {
                MessageBox.Show("Amount Field Must Not Be Empty!", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

           


            decimal Amount = _ConvertAmountToSR(Convert.ToDecimal(txtAmount.Text));
            string Note = rtsNote.Text;
            ClsClientAccount Acc = await ClsClientAccount.FindClientAccount(clsGlobal.GlobalClient.ClientID, ctrlSelectAccounts1.CurrentAccountID);

            if (this.TransType==enTransactionType.Deposit)
            {

                if (Convert.ToDecimal(txtAmount.Text) <= 0)
                {
                    MessageBox.Show("Amount Field Must Be Greatar Than Zero ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Acc != null)
                {
                    int DeposeTransactionID = await Acc.Deposite(Amount, 1, Note,(int)enTransactionType.Deposit);

                    if (DeposeTransactionID != -1)
                    {
                        MessageBox.Show("Deposit completed successfully!",
                      "Success",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
                        _ResetValues();
                        frmDeposit_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Deposit failed. ", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    }
                }
            }

            else
            {
                

                if (Acc != null)
                {

                    
                    if (Amount > Acc.Balance)
                    {
                        MessageBox.Show("Amount entered exceeds account balance",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                        return;

                    }


                    int DeposeTransactionID = await Acc.Deposite(-Amount, 1, Note,(int)enTransactionType.WithDraw);

                    if (DeposeTransactionID != -1)
                    {
                        MessageBox.Show("WithDraw completed successfully!",
                      "Success",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
                        _ResetValues();
                        frmDeposit_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("WithDraw failed. ", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    }
                }
            }
            
            

           
           
            


           
        }

        private async void cbCurency_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(cbCurency.Text!="SR")
            {

                string Name = cbCurency.Text;
              clsCurrency C  = await clsCurrency.FindCurrencyByCurrencySymbol(cbCurency.Text);
                if ( C != null&&C.CurrencyID!=-1 )

                {
                    CurrentCurrencyExchange = C.ExchangeRate;
                }
            }
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

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {

        }

        private void _ResetValues()
        {
            txtAmount.Text= string.Empty;
            rtsNote.Text= string.Empty;
            cbCurency.SelectedIndex = 0;
        }

        private void txtAmount_Validating_1(object sender, CancelEventArgs e)
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
