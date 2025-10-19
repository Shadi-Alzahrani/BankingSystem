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
using BankingSystem_Business.Utils;

namespace BankingSystem.Reports
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        ClsClientAccount.enTransactionType TransactionType { get; set; }
        DateTime FromDate;
        DateTime ToDate;
        private async void frmReports_Load(object sender, EventArgs e)
        {
            _SetdefaultValues();
         await   ctrlClientInfoPanel1.LoadData(clsGlobal.GlobalClient.ClientID);
        }

        private void _SetdefaultValues()
        {

            //set the default value of data time picker :

            dtpFrom.Value = DateTime.Now.AddDays(-1);
            dtpTo.Value = DateTime.Now;

            dtpFrom.MinDate = DateTime.Now.AddYears(-5);
            dtpFrom.MaxDate = DateTime.Now.AddDays(-1);

            dtpTo.MinDate = DateTime.Now.AddYears(-5);
            dtpTo.MaxDate = DateTime.Now;


            CbReportTypes.SelectedIndex = 0;
            
        }

        private void CbReportTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
         
           switch (CbReportTypes.Text)
            {
                case "Account Deposit Summary":
                    TransactionType = ClsClientAccount.enTransactionType.Deposit; 
                    break;

                case "Account Withdrawal Summary":
                    TransactionType = ClsClientAccount.enTransactionType.WithDraw;
                    break;

                case "Account Transfer Summary":
                    TransactionType = ClsClientAccount.enTransactionType.Transfare;
                    break;
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FromDate = dtpFrom.Value;
            ToDate = dtpTo.Value;
            string Title = $"{TransactionType.ToString()} Transaction From : {FromDate} To : {ToDate}";
            string FileName = $"{CbReportTypes.Text}.PDF";
            DataTable dt = await clsGlobal.GlobalClient.GetClientTrans((ClsClient.enTransactionType)TransactionType,FromDate,ToDate);

            if(dt!=null)
            {
                dt.Columns[0].ColumnName = "Transaction Name";
                dt.Columns[3].ColumnName = "Transaction Date";
            }

           await  clsUtil.ExportDataTableToPdf(dt, Title, FileName);
        }
    }
}
