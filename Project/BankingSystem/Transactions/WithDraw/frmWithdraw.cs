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

namespace BankingSystem.Transactions.WithDraw
{
    public partial class frmWithdraw : Form
    {
        public frmWithdraw()
        {
            InitializeComponent();
        }

        private void frmWithdraw_Load(object sender, EventArgs e)
        {

            ctrlClientInfoPanel1.LoadData(clsGlobal.GlobalClient.ClientID);
            ctrlSelectAccounts1.FillClientAccountToComboBox(clsGlobal.GlobalClient.ClientID);

            _FillCurrencyComboBox();
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

        private void _ResetValues()
        {
            txtAmount.Text = string.Empty;
            rtsNote.Text = string.Empty;
            cbCurency.SelectedIndex = 0;
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text.Trim()))
            {
                errorProvider1.SetError(txtAmount, "Amount Field Must Not Be Empty!");
            }
            else
            {
                errorProvider1.SetError(txtAmount, "");
            }
        }
    }
}
