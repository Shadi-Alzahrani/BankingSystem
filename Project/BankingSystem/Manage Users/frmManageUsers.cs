using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.Properties;
using BankingSystem_Business;

namespace BankingSystem.Manage_Users
{
    public partial class frmManageUsers : Form
    {

        private DataTable _dtUsers;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private async void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtUsers = await clsUser.GetAllUsers();
            FillUserDataGrid();
            cbFilterName.SelectedIndex = 0;
            cbIsActveAndIsAdmin.SelectedIndex = 0;
        }

        private async void FillUserDataGrid()
        {
            
            dgvUsers.DataSource = _dtUsers;

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 100;


                dgvUsers.Columns[1].HeaderText = "User Name";
                dgvUsers.Columns[1].Width = 150;

                dgvUsers.Columns[2].HeaderText = "Is Active";
                dgvUsers.Columns[2].Width = 150;

                dgvUsers.Columns[3].HeaderText = "Is Admin";
                dgvUsers.Columns[3].Width = 100;

                dgvUsers.Columns[4].HeaderText = "Created Date";
                dgvUsers.Columns[4].Width = 200;

                dgvUsers.Columns[5].HeaderText = "Last Login  Date";
                dgvUsers.Columns[5].Width = 250;





            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cbIsActveAndIsAdmin.Visible = cbFilterName.Text == "Is Admin" || cbFilterName.Text == "Is Active";
            txtFilterValue.Visible = !cbIsActveAndIsAdmin.Visible;
            _ApplyFilterToUserDataGrid();
        }
    
    private void _ApplyFilterToUserDataGrid()
        {
            string ColumnName = "None";
         
           
            switch (cbFilterName.Text)
            {
                case "User ID":
                  
                    ColumnName = "UserID";
                break;

                case "User Name":
                  
                    ColumnName = "UserName";
                break;

                case "Is Active":
                    ColumnName = "IsActive";
                    break;

                case "Is Admin":
                    ColumnName = "IsAdmin";
                    break;

                default:
                    ColumnName="None";
                    break;
            }

            

         
            if((string.IsNullOrWhiteSpace(txtFilterValue.Text) || ColumnName=="None") && txtFilterValue.Visible )
            {
                _dtUsers.DefaultView.RowFilter = "";
                FillUserDataGrid();
                return;
            }

            if(ColumnName=="UserID")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}  ",ColumnName,txtFilterValue.Text.Trim()) ;
            }

            if(ColumnName=="UserName")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}]  like  '%{1}%'  ", ColumnName, txtFilterValue.Text.Trim());

            }

           if(ColumnName== "IsActive" || ColumnName == "IsAdmin")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}]  =  {1}  ", ColumnName, cbIsActveAndIsAdmin.Text=="Yes"?"1":"0");
            }

            


            FillUserDataGrid();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilterToUserDataGrid();
        }

        private void cbIsActveAndIsAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            _ApplyFilterToUserDataGrid();




        }

        private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           int SelectedUserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
           clsUser SelectedUser = await clsUser.FindUserByUserID(SelectedUserID);

            if(SelectedUser.IsActive)
            {
                activeToolStripMenuItem.Text = "Deactive";
                activeToolStripMenuItem.Image = Resources.DeActive;
            }
            else
            {
                activeToolStripMenuItem.Text = "Active";
                activeToolStripMenuItem.Image = Resources.active_user;
            }
        }

        private async void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           int CurrentUserID = (int) dgvUsers.CurrentRow.Cells [0].Value;

           bool ActiveStatus = (activeToolStripMenuItem.Text == "Active");

           await clsUser.UpdateUserActiveStatus(CurrentUserID, ActiveStatus);

           frmManageUsers_Load(null,null);


        }
    }
}
