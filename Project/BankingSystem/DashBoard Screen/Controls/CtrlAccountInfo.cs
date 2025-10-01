using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem.Controls
{
    public partial class CtrlAccountInfo : UserControl
    {
        public string AccountName { get; set; } = "Account Name";
        public decimal AccountBalance { get; set; } = 1000;
        public string AccountID {  get; set; }
        public CtrlAccountInfo()
        {
            InitializeComponent();
        }

        private void CtrlAccountInfo_Load(object sender, EventArgs e)
        {

        }

        public  void SetValues(string AccountName,decimal AccountBalance,string AccountID)
        {
            lblAccountName.Text = AccountName;
            lblAccountNumber.Text = AccountID;
            lblTotalBalance.Text = AccountBalance.ToString();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
