using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.Client_Mangment.Change_Password_Screen;
using BankingSystem.Client_Mangment.Edit_info;
using BankingSystem.DashBoard_Screen;
using BankingSystem.DashBoard_Screen.Admin_Dashboard;
using BankingSystem.Global;
using BankingSystem.Log_In_Screen;
using BankingSystem.Manage_Clients_Accounts;
using BankingSystem.Manage_Users;
using BankingSystem.Properties;
using BankingSystem.Reports;
using BankingSystem.Transactions.Deposit_Screen;
using BankingSystem.Transactions.Deposit_Screen;
using BankingSystem.Transactions.Transfare;
using BankingSystem_Business;
using Org.BouncyCastle.Asn1.Pkcs;

namespace BankingSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        clsUser _CurrentUser;
        frmLogIn frm;
        private bool _IsCollapsed=true;
        private bool _IsCollapsed_ClientMangment=true;
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Dashboard";
            this.pbTitle.Image = Resources.dashboard;
            CentalFormLogo();
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

        private async void frmMain_Load(object sender, EventArgs e)
        {
            _CurrentUser = clsGlobal._GlobalUser;

            if (_CurrentUser.IsAdmin)
            {
                btnAdminDashbourd.Visible = true;
                btnDashboard.Visible = false;
                btnClientMangments.Visible = false;
                ClientMangmentPanel.Visible = false;
                btnTransactions.Visible = false;
                btnReports.Visible = false;
                panelDragDrop.Visible = false;
                panel1.Visible = false;
            
                frmAdminDashboard frm = new frmAdminDashboard();
                _SelectCurrentScreen(frm);
                
            }
            else
            {
               btnManageUsers.Visible=false;
                btnAdminDashbourd.Visible = false;
                btnManageAccounts.Visible = false;
                frmDashboard frm = new frmDashboard();
                _SelectCurrentScreen(frm);
            }

          
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDepositAndWithDraw frm = new frmDepositAndWithDraw(frmDepositAndWithDraw.enTransactionType.Deposit);
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Deposit";
            this.pbTitle.Image = Resources.deposit;
            this.Text = "Deposit";
            CentalFormLogo();
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
            frmDepositAndWithDraw frm = new frmDepositAndWithDraw(frmDepositAndWithDraw.enTransactionType.WithDraw);
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "WithDraw";
            this.pbTitle.Image = Resources.money_withdrawal;
            this.Text = "Withdraw";
            CentalFormLogo();
        }

        private void btnTransfare_Click(object sender, EventArgs e)
        {
            frmTransfare frm = new frmTransfare();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Transfare";
             this.pbTitle.Image = Resources.icons8_transaction_32;
            this.Text = "Transfare";
            CentalFormLogo();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Reports";
            this.pbTitle.Image = Resources.ReporstLogo;
            this.Text = "Reports";
            CentalFormLogo();
        }

        private void ClientMangmentTimer_Tick(object sender, EventArgs e)
        {
            if(_IsCollapsed_ClientMangment)
            {
                btnClientMangments.Image = Resources.icons8_slide_up_32;
                if (ClientMangmentPanel.Size==ClientMangmentPanel.MaximumSize)
                {
                    _IsCollapsed_ClientMangment = false;
                    ClientMangmentTimer.Stop();
                }

                ClientMangmentPanel.Height+=10;

            }
            else
            {
                btnClientMangments.Image = Resources.icons8_down_button_32;
                
                if (ClientMangmentPanel.Size == ClientMangmentPanel.MinimumSize)
                {
                    _IsCollapsed_ClientMangment=true;
                    ClientMangmentTimer.Stop();
                }

                ClientMangmentPanel.Height-=10;
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            frmEditInfo frm = new frmEditInfo();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Edit Info";
            this.pbTitle.Image = Resources.profile;
            this.Text = "Edit Info";
            CentalFormLogo();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Change Password";
            CentalFormLogo();
              this.pbTitle.Image = Resources.password_manager;
            this.Text = "Change Password";
        }
        private void CentalFormLogo()
        {
            pbTitle.Left = lblTitle.Left + (lblTitle.Width - pbTitle.Width) / 2;
            pbTitle.Top = lblTitle.Top - pbTitle.Height - 5;
        }
        private void btnClientMangments_Click(object sender, EventArgs e)
        {
            ClientMangmentTimer.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = new frmLogIn();
            frm.ShowDialog();
        }

        private void btnAdminDashbourd_Click(object sender, EventArgs e)
        {
            frmAdminDashboard frm = new frmAdminDashboard();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Dashboard";
            CentalFormLogo();
            this.pbTitle.Image = Resources.password_manager;
            this.Text = "Dashboard";
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Manage Users";
            CentalFormLogo();
            this.pbTitle.Image = Resources.password_manager;
            this.Text = "Manage Users";
        }

        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            frmClientAccountsList frm = new frmClientAccountsList();
            _SelectCurrentScreen(frm);
            this.lblTitle.Text = "Manage Accounts";
            CentalFormLogo();
            this.pbTitle.Image = Resources.password_manager;
            this.Text = "Manage Accounts";
        }
    }
}
