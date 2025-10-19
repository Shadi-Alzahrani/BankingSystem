using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.Global;
using BankingSystem.Utils;

namespace BankingSystem.Client_Mangment.Edit_info
{
    public partial class frmEditInfo : Form
    {
        public frmEditInfo()
        {
            InitializeComponent();
        }

        private void frmEditInfo_Load(object sender, EventArgs e)
        {
            LoadClientData();
        }

        public void LoadClientData()
        {
           

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            txtFirstName.Text=clsGlobal.GlobalClient.FirstName;
            txtLastName.Text=clsGlobal.GlobalClient.LastName;
            txtEmail.Text=clsGlobal.GlobalClient.Email;
            txtPhone.Text = clsGlobal.GlobalClient.PhoneNumber;
            rtsAddress.Text = clsGlobal.GlobalClient.Address;


            string ImagePath = clsGlobal.GlobalClient.ImageUrl;
            if (ImagePath != null)
            {
                pbPersonalImage.ImageLocation = ImagePath.Replace(@"//", @"/"); ;
            }

            llRemove.Enabled = pbPersonalImage.ImageLocation != null;
        }

        private void llChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select an Image";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
              string Image =   openFileDialog1.FileName;
              pbPersonalImage.ImageLocation= Image;
              llRemove.Enabled=pbPersonalImage.ImageLocation!=null;
               
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonalImage.Image.Dispose();
            pbPersonalImage.Image = null;
            pbPersonalImage.ImageLocation= null;
            llRemove.Enabled= false;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            TextBox btnOK = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(btnOK.Text))
            {
                errorProvider1.SetError(btnOK, "This Fiald Can'T be Empty!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(btnOK, "");
                e.Cancel = false;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!clsUtil.IsValidEmail(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail,"please enter a valid email!");
                e.Cancel= true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
                e.Cancel = false;
            }
        }

        private void rtsAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtsAddress.Text))
            {
                errorProvider1.SetError(rtsAddress, "This Fiald Can'T be Empty!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(rtsAddress, "");
                e.Cancel = false;
            }
        }
        private bool  _HandelPeronalImage()
        {
             
            if (clsGlobal.GlobalClient.ImageUrl != pbPersonalImage.ImageLocation)
            {
                
                    if (clsGlobal.GlobalClient.ImageUrl!=null && clsGlobal.GlobalClient.ImageUrl!="")
                    {
                    try
                    {
                        File.Delete(clsGlobal.GlobalClient.ImageUrl);
                    }
                    catch(Exception ex) 
                    { 
                    
                        clsUtil.LogUiExceptionToWinEventLog(ex);
                        return false;
                    }
                        
                    }


                    if (pbPersonalImage.ImageLocation != null)
                    {
                        string CurrentImage = pbPersonalImage.ImageLocation;
                        if (clsUtil.CopeImageToClientImageFolder(ref CurrentImage))
                        {
                            pbPersonalImage.ImageLocation = CurrentImage;
                        }
                        else
                        {
                            MessageBox.Show("an error occurd while handling the image", "error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }




            return true;
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please fill all failds!","Not Allowed",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            clsGlobal.GlobalClient.FirstName = txtFirstName.Text.Trim();
            clsGlobal.GlobalClient.LastName = txtLastName.Text.Trim();
            clsGlobal.GlobalClient.PhoneNumber = txtPhone.Text.Trim();
            clsGlobal.GlobalClient.Email = txtEmail.Text.Trim();
            clsGlobal.GlobalClient.Address = rtsAddress.Text.Trim();

           
            if(!_HandelPeronalImage())
            {
                MessageBox.Show("Failed to Handel the Personal Image","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }
               
            clsGlobal.GlobalClient.ImageUrl = pbPersonalImage.ImageLocation;


            if(await  clsGlobal.GlobalClient.Save())
            {
                MessageBox.Show("info Updated seccessfully !","Complete",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("info Updated seccessfully !", "Complete", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }

           
        }
    }
}
