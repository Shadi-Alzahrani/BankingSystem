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

namespace BankingSystem
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            clsCurrency C =  await  clsCurrency.FindCurrencyByCurrencySymbol("SR");
            if(C!=null)
            {
                MessageBox.Show($"Currency Exchange is : {C.ExchangeRate}");
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
          
        }
    }
}
