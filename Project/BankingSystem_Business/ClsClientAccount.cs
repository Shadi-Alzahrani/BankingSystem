using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BankingSystem_Business.Utils;
using BankingSystem_DataAccess;

namespace BankingSystem_Business
{
    /*
@ClientID ,
@AccountID ,
@AccountNumber  ,
@Balance ,
@AccountStatusID ,
@CreatedDate ,
@CloseDate  ,
@CreatedByUserID 
 */
    public class ClsClientAccount
    {
        enum enMode {AddNew=0,Update=1 }
        private enMode _Mode;
        public int ClientID { get; set; }
        public int AccountID { get; set; }
        public string AccountName {  get; set; }    
        public string AccountNumber { get; set; }
        public decimal Balance {  get; set; }   
        public int AccountStatusID { get; set; }    
        public DateTime CreatedDate {  get; set; }  
        public DateTime? CloseDate {  get; set; }
        public int CreatedByUserID {  get; set; }   
        public ClsClient ClientInfo { get; set; }
        public ClsClientAccount()
        {
            this.ClientID = -1;
            this.AccountID = -1;
            this.AccountNumber = "";
            this.AccountName = "";
            this.Balance = 0;
            this.AccountStatusID = 0;
            this.CreatedDate = DateTime.Now;
            this.CloseDate = DateTime.Now;
            this.CreatedByUserID = -1;
            _Mode = enMode.AddNew;
        }

        private ClsClientAccount(int ClientID,int AccountID,string AccountName,string AccountNumber,
            decimal Balance,int AccountStatusID,DateTime CreatedDate,DateTime? CloseDate,
            int CreatedByUserID)
        {
            this.ClientID= ClientID;
            this.AccountID= AccountID;
            this.AccountName= AccountName;
            this.AccountNumber= AccountNumber;
            this.Balance = Balance;
            this.AccountStatusID = AccountStatusID;
            this.CreatedDate = CreatedDate;
            this.CloseDate= CloseDate;
            this.CreatedByUserID= CreatedByUserID;

            this.ClientInfo = ClsClient.findClient(this.ClientID);
            this._Mode = enMode.Update;
        }


        public static  ClsClientAccount FindClientAccount(int ClientID,int AccountID)
        {
            int AccountStatusID = -1,CreatedByUserID=-1;
            string AccountNumber = "",AccountName="";
            decimal Balance = 0;
            DateTime CreatedDate = DateTime.Now;
           DateTime? CloseDate=DateTime.Now ;

            bool IsFound = ClsClientAccountData.GetClientAccountByClientID(ClientID, AccountID,
               ref  AccountName, ref AccountNumber, ref Balance, ref AccountStatusID,
               ref CreatedDate,   ref CloseDate, ref CreatedByUserID);

            string name  = AccountNumber;
            int accountid= AccountID;
            DateTime t  = CreatedDate;

            if (IsFound)
                return new ClsClientAccount(ClientID,AccountID,AccountName,AccountNumber,
                    Balance,AccountStatusID,CreatedDate,CloseDate,CreatedByUserID);
            else
                return null;

            
        }


        public async Task< int> Deposite( decimal Amount,int CurrencyID,string Description)
        {
           
            try
            {
                ClsClientAccount Acc = ClsClientAccount.FindClientAccount(this.ClientID, AccountID);

                if (Acc == null || Amount <= 0)
                {
                    return -1;
                }

               int TransID = await ClsClientAccountData.Deposite(this.AccountID, Amount, CurrencyID, Description);

                return TransID;       

            }
            catch (Exception ex)
            {
                clsUtils.LogSqlExceptionToWinEventLog(ex);
            }

            return -1;




        }

    }
}
