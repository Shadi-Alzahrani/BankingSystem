using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BankingSystem_Business;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BankingSystem.Utils;
using BankingSystem.Global;
using System.Windows.Forms.DataVisualization.Charting;
using Font = System.Drawing.Font;

namespace BankingSystem
{
    public partial class Test : Form
    {
        int total = 10;
        public Test()
        {
            InitializeComponent();
        }

 
        private async void Test_Load(object sender, EventArgs e)
        {
         string Password =    clsUtil.EncryptPasswordUsingHashing("1");

        }

       

        public void btn_click(object sender, EventArgs e)
        {
            Button btn  = (Button)sender;
            MessageBox.Show($"{btn.Tag.ToString()}");
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string a = "12345";
        string Hash =    clsUtil.EncryptPasswordUsingHashing(a);
            MessageBox.Show(Hash);

        }
    }
}
