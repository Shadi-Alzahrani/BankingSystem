using System;
using System.Collections.Generic;
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

        public static ClsClient findClient(int ClientID)
        {
            int PersonID = -1, NationalID = -1, CountryID = -1;
            DateTime CreatedDate = DateTime.Now, DateOfBirth = DateTime.Now;
            bool Gender = false;
            string FirstName = "", LastName = "", PhoneNumber = "", Email = ""
                , Address = "", image = "";

            bool IsFound = ClsClientData.GetClientInfo(ClientID, ref PersonID, ref CreatedDate);

            if(IsFound)
            {
                ClsPerson Person = ClsPerson.Find(PersonID);
                return new ClsClient(ClientID, PersonID, CreatedDate, Person.NationalID, Person.Gender, Person.DateOFBirth
                    , Person.FirstName, Person.LastName, Person.PhoneNumber, Person.Email, Person.Address,Person.ImageUrl, Person.CountryID);
            }

            else
                return null;

        }
    }
}
