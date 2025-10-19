using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem_DataAccess;

namespace BankingSystem_Business
{
    public  class ClsClient : ClsPerson
    {

      public   enum enMode {Addnew=0,Update=1 }
        private enMode _Mode = enMode.Addnew;

        public   enum enTransactionType {Deposit=1, Withdrawal = 2, Transfer = 3 }
        



        private int _ClientID;
        public int ClientID { get { return _ClientID; }  }

        public DateTime CreatedDate { get; set; }
       
   
      
        private ClsClient(int ClientID, int PersonID, DateTime CreatedDate,
        int NationalNumber, bool Gender, DateTime DateOfBirth, string FirstName,
        string LastName,string PhoneNumber,string Email,string Address,string Image,
        int CountryID) 
        { 
        this._ClientID = ClientID;
        base._PersonID = PersonID;
        this.CreatedDate = CreatedDate;
        base.NationalID = NationalNumber;
        base.Gender = Gender;
        base.DateOFBirth = DateOfBirth;
        base.FirstName = FirstName;
        base.LastName = LastName;
        base.PhoneNumber = PhoneNumber;
        base.Email = Email;
        base.Address = Address;
        base.CountryID = CountryID;
        base.ImageUrl = Image;
        this._Mode = enMode.Update;
            



       
        }

        public async Task< decimal> GetAccountTotalBalance()
        {
            return await  ClsClientAccountData.GetClientTotalBalance(this.ClientID);
        }
        public static async Task<ClsClient> findClient(int ClientID)
        {
           

            var ClientData = await ClsClientData.GetClientInfo(ClientID);

            if(ClientData.PersonID!=-1)
            {
                ClsPerson Person = await  ClsPerson.Find(ClientData.PersonID);
                return new ClsClient(ClientID, ClientData.PersonID, ClientData.CreatedDat, Person.NationalID, Person.Gender, Person.DateOFBirth
                    , Person.FirstName, Person.LastName, Person.PhoneNumber, Person.Email, Person.Address,Person.ImageUrl, Person.CountryID);
            }

            else
                return null;

        }

        public static async Task<ClsClient> findClientBYPersonID(int PersonID)
        {


            var ClientData = await ClsClientData.GetClientInfoByPersonID(PersonID);

            if (ClientData.ClientID != -1)
            {
                ClsPerson Person = await ClsPerson.Find(PersonID);
                return new ClsClient(ClientData.ClientID, PersonID , ClientData.CreatedDat, Person.NationalID, Person.Gender, Person.DateOFBirth
                    , Person.FirstName, Person.LastName, Person.PhoneNumber, Person.Email, Person.Address, Person.ImageUrl, Person.CountryID);
            }

            else
                return null;

        }


        public  async Task<int > _GetNumberOFAccounts()
        {
            return await ClsClientAccountData.GetClientTotalAccounts(this.ClientID);
              
        }
    
    public async    Task<DataTable> GetAllAccounts()
        {
            return await ClsClientAccountData.GetAllClientAccounts(this.ClientID);
        }

        public static  async Task<DataTable> GetFullAccountsInfo()
        {
            return await ClsClientAccountData.GetAllClientsAccounts();
        }
        public  async Task<decimal>GetTotalAmountPerTransAction(enTransactionType TransActionType)
        {
            decimal TotalAmount = await ClsClientAccountData.GetTotalAmountPerTransaction(this.ClientID,(int)TransActionType);
            return TotalAmount;
        }

        public async Task<DataTable> GetAllAccountsTransActions(int PageNumber)
        {
            return await ClsClientAccountData.GetAllAccountsTransActions(this.ClientID,PageNumber);
        }

        public async Task<int > GetTotalTransactions()
        {
            int TotalTrans = await ClsClientAccountData.GetTotalClientTransactions(this.ClientID);

            return TotalTrans;
        }

        public async Task<DataTable> GetClientTrans(enTransactionType TransType,DateTime From,DateTime To)
        {
            return await ClsClientData.GetClientTransaction(this.ClientID, (int)TransType,From,To);
        }


        private async Task<bool>_UpdateClientInfo()
        {
      return   await      ClsClientData.UpdateClientInfo(this.PersonID,this.FirstName,this.LastName
                ,this.Email,this.PhoneNumber,this.Address,this.ImageUrl);
        }

        public async static Task<int > GetNumberOfClients()
        {
            return await ClsClientData.GetTotalNumberOfClients();
        }
        public async Task<bool> Save()
        {
            switch(_Mode)
            {
                case enMode.Update:
                    if( await _UpdateClientInfo())
                    {
                      return true;
                    }
                    else
                        return false;  
                    break;

                default:
                    return false;
            }
        }
    }


}
