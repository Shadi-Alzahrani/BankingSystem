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
using BankingSystem.Utils;
using BankingSystem_Business;

namespace BankingSystem.Client_Mangment.Change_Password_Screen
{
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        public frmChangePassword()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

        }

        private async void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
         
            if(clsUtil.EncryptPasswordUsingHashing( txtCurrentPassword.Text.Trim())!=_User.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, @"The entered password does not match the actual password  ");
               
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, @"");

                e.Cancel = false;
            }
        }

        private async void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = await clsUser.FindUserByPersonID(clsGlobal.GlobalClient.PersonID);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword,"this field can't be empty!");
                e.Cancel= true;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
                e.Cancel = false;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim()!=txtNewPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "The entered password does not match the New  password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
                e.Cancel = false;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please check the highlighted fields and try again ❌",
                       "Validation Failed",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                return;
            }

            string NewPassword = txtNewPassword.Text.Trim();
            string PasswordAfterHashing = clsUtil.EncryptPasswordUsingHashing(NewPassword);

            bool UpdateStatus = await clsUser.UpdatePassword(_User.UserID, PasswordAfterHashing);
            
            if (UpdateStatus)
            {
                MessageBox.Show("Password updated successfully","successfully",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("an error occurd while updating the password ", "seccussfully",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
