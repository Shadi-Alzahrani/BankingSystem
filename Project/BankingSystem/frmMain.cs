using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.DashBoard_Screen;
using BankingSystem.Properties;
using BankingSystem.Transactions.Deposit_Screen;
using BankingSystem.Transactions.WithDraw;

namespace BankingSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool _IsCollapsed;

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Dashboard";
        }

        private void _SelectCurrentScreen(Form frm)
        {
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pMainContent.Controls.Add(frm);
            this.pMainContent.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }

        private void pMainContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            _SelectCurrentScreen(frm);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDeposit frm = new frmDeposit();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Deposit";
            this.pbTitle.Image = Resources.deposit;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DropDownTimer.Start();
        }

        private void DropDownTimer_Tick(object sender, EventArgs e)
        {
            if (_IsCollapsed)
            {
                btnTransactions.Image = Resources.icons8_slide_up_32;
              
                panelDragDrop.Height += 10;
                if (panelDragDrop.Height == panelDragDrop.MaximumSize.Height)
                {
                    DropDownTimer.Stop();
                    _IsCollapsed = false;
                }


            }

            else
            {
                btnTransactions.Image = Resources.icons8_down_button_32;
                panelDragDrop.Height -= 10;
                if (panelDragDrop.Height == panelDragDrop.MinimumSize.Height)
                {
                    DropDownTimer.Stop();
                    _IsCollapsed = true;
                }
            }
        }

        private void btnWithDraw_Click(object sender, EventArgs e)
        {
           frmWithdraw frm = new frmWithdraw();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Withdraw";
            this.pbTitle.Image = Resources.money_withdrawal;
        }

        private void btnTransfare_Click(object sender, EventArgs e)
        {

        }
    }
}
