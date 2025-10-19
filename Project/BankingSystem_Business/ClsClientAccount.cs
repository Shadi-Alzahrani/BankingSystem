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
       public  enum enAccountsStatus { Active = 1, anActive = 2, Suspended = 3, Closed = 4 };
        public enum enTransactionType { Deposit = 1, WithDraw = 2,Transfare=3 }
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

        private  ClsClientAccount(int ClientID,int AccountID,string AccountName,string AccountNumber,
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

            
            this._Mode = enMode.Update;
        }

        public static  async Task<ClsClientAccount> FindClientAccount(int ClientID,int AccountID)
        {


            var Acc = await ClsClientAccountData.GetClientAccountByClientID(ClientID, AccountID);

           

            if (Acc.AccountName!="")
                return new ClsClientAccount(ClientID,AccountID, Acc.AccountName, Acc.AccountNumber,
                   Acc.Balance, Acc.AccountStatusID, Acc.CreatedDate, Acc.CloseDate, Acc.CreatedByUserID);
            else
                return null;

            
        }

        public static async Task<ClsClientAccount> FindClientAccount( int AccountID)
        {


            var Acc = await ClsClientAccountData.GetClientAccountByAccountID( AccountID);



            if (Acc.ClientID != -1)
                return new ClsClientAccount(Acc.ClientID, AccountID, Acc.AccountName, Acc.AccountNumber,
                   Acc.Balance, Acc.AccountStatusID, Acc.CreatedDate, Acc.CloseDate, Acc.CreatedByUserID);
            else
                return null;


        }

        public async Task< int> Deposite( decimal Amount,int CurrencyID,string Description, int TransType)
        {
           
            try
            {
                ClsClientAccount Acc = await ClsClientAccount.FindClientAccount(this.ClientID, AccountID);

               

               int TransID = await ClsClientAccountData.Deposite(this.AccountID, Amount, CurrencyID, Description, TransType);

                return TransID;       

            }
            catch (Exception ex)
            {
                clsUtils.LogSqlExceptionToWinEventLog(ex);
            }

            return -1;




        }

        public async Task<int> Transfare(int AccountToID,decimal Amount, string Description)
        {

            try
            {
                ClsClientAccount Acc = await ClsClientAccount.FindClientAccount(this.ClientID, AccountID);



                int TransID = await ClsClientAccountData.Transfare(this.AccountID,AccountToID, Amount, Description);

                return TransID;

            }
            catch (Exception ex)
            {
                clsUtils.LogSqlExceptionToWinEventLog(ex);
            }

            return -1;




        }
        public static  async Task<(string FullName, string AccountNumber)> GetAccountForTransfer(int AccountID)
        {
            return await ClsClientAccountData.GetAccountForTransfer(AccountID);
        }

        public async static Task<int> GetNumberOfAccounts()
        {
            return await ClsClientAccountData.GetTotalNumberOfAccounts();
        }

        public async static Task<int> GetNumberOfTransactions()
        {
            return await ClsClientAccountData.GetTotalNumberOfTransactions();
        }

        public async static Task<decimal> GetTotalBalnces()
        {
            return await ClsClientAccountData.GetTotalBalnces();
        }

        public async static Task<decimal> GetclientsTotalTransaction(enTransactionType TransactionType)
        {
            return await ClsClientAccountData.GetClientsTotalTransaction((int)TransactionType);
        }

        public  static async  Task<bool> UpdateAccountStatus(int AccountID, enAccountsStatus AccountStatus,string CloseReason)
        {
            return await ClsClientAccountData.UpdateAccountStatus(AccountID,(int)AccountStatus, CloseReason);
        }
    }
}
