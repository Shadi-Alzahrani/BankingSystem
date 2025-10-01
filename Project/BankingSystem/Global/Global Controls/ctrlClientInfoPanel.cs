using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem_Business;

namespace BankingSystem.Global.Global_Controls
{
    public partial class ctrlClientInfoPanel : UserControl
    {
        public ctrlClientInfoPanel()
        {
            InitializeComponent();
        }

        private void ctrlClientInfoPanel_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(int ClientID)
        {
            ClsClient Client = ClsClient.findClient(ClientID);

            if (Client == null)
            {
                MessageBox.Show("Failed to Load Client  Info ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _FillData(Client);
        }


        private void _FillData(ClsClient Client)
        {
            lblClientID.Text = Client.ClientID.ToString();
            lblClientName.Text = Client.FullName;
            lblCurrentDate.Text = DateTime.Now.ToString();
            pbClientPic.ImageLocation = Client.ImageUrl;
        }
    }
}
