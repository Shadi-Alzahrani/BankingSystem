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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClsPerson person = ClsPerson.Find(1000);
            if (person != null)
            {
                MessageBox.Show($"Name is : {person.PersonID}");
            }
            else
            {
                MessageBox.Show("Failed ");
            }
        }
    }
}
