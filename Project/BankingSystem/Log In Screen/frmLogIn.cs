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
using BankingSystem.Log_In_Screen.Controls;
using BankingSystem.Properties;
using BankingSystem.Utils;
using BankingSystem_Business;
using BankingSystem_Business.Utils;
using Org.BouncyCastle.Asn1.BC;

namespace BankingSystem.Log_In_Screen
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }
        int NumberOFWrongTries=0;
        int btnFreazeTimer = 30;
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtPassword.Tag=="Hide")
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.Tag = "Show";
                btnShowHidePass.Image = Resources.hide;
              
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPassword.Tag = "Hide";
                btnShowHidePass.Image = Resources.show;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some of the field are empty!","Not Allowed",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            string Username = txtUsername.Text.Trim();
            string Password =  txtPassword.Text.Trim();
            string PasswordAfterHashing = clsUtil.EncryptPasswordUsingHashing(Password);
          
        
            if( await clsUser.IsUserExists(Username, PasswordAfterHashing))
            {
               clsGlobal._GlobalUser = await clsUser.FindUserByUserName(Username);
                 clsGlobal.GlobalClient = await ClsClient.findClientBYPersonID(clsGlobal._GlobalUser.PersonID);
                if(!clsGlobal._GlobalUser.IsActive)
                {
                    MessageBox.Show("Your account is not activated. Please contact the administrator.",
                        "Account Inactive",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if(chkRemberMe.Checked)
                {
                    //save user info to windows registroy 
                  if(!  clsUtil.SaveUserAccountInWindowsRegistry(Username,Password))
                    {
                        MessageBox.Show("failed To Save User Info in windows Regestry!","error while saving"
                            ,MessageBoxButtons.OK,MessageBoxIcon.Error);

                        return;
                    }
                }
                else
                {
                    clsUtil.SaveUserAccountInWindowsRegistry(null,null);
                }

               

                this.Hide();
                clsUser.UpdateUserLastLoginDate(clsGlobal._GlobalUser.UserID);
                frmMain frm = new frmMain();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumberOFWrongTries++;
              
            }

            if(NumberOFWrongTries==3)
            {
             btnLogin.Enabled = false;
             lblwrongAttemtMessage.Visible = true;
             ccProgressBar1.Visible = true;
             timer1.Start();
            }
        }

        private void _LoadCredentialsFromRegistry()
        {
           string Info = clsUtil.GetUserInfoFromWindowsRegistry();

            if (!string.IsNullOrWhiteSpace(Info))
            {
                string[] Line = Info.Split(new string[] { "#//#" }, StringSplitOptions.None);
                
                txtUsername.Text = Line[0];
                txtPassword.Text = Line[1].Trim();
            }
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            _LoadCredentialsFromRegistry();
        }

        private void chkRemberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRemberMe.Checked)
            {
                clsUtil.SaveUserAccountInWindowsRegistry("","");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
             btnFreazeTimer--;
            ccProgressBar1.Value -=1;

            if (btnFreazeTimer==0)
            {
                btnLogin.Enabled=true;
                lblwrongAttemtMessage.Visible = false;
             
                ccProgressBar1.Visible = false;
                timer1.Stop();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
          

            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if(string.IsNullOrWhiteSpace(txt.Text))
            {
                errorProvider1.SetError(txt, "this field can't be empty ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txt, "");
                e.Cancel = false;
            }
        }
    }
}
