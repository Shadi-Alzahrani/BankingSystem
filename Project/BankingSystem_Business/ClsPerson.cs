using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem_DataAccess;

namespace BankingSystem_Business
{
    public  class ClsPerson
    {
        /* p.PersonID,p.NationalID,p.Gender,p.DateOFBirth,p.FirstName,p.LastName,p.PhoneNumber
   ,p.Email,p.Address,p.image,p.CountryID */

      public   enum enMode {AddNew=0,Update=1 }
      private enMode _Mode = enMode.AddNew;

        protected int _PersonID;
        public int PersonID { get { return _PersonID; } }  

        public int NationalID { get; set; }

        public bool Gender {  get; set; }   

        public DateTime DateOFBirth { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }

        public string ImageUrl {  get; set; }

        public int CountryID {  get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public ClsPerson()
        {
            this._PersonID = -1;
            this.NationalID = -1;
            this.Gender = false;
            this.DateOFBirth = DateTime.Now;
            this.FirstName = "";
            this.LastName = "";
            this.PhoneNumber = "";
            this.Email = "";
            this.Address = "";
            this.ImageUrl = "";
            this.CountryID = -1;

            this._Mode = enMode.AddNew;
        }

        private ClsPerson(int PersonID,int NationalID,bool Gender,DateTime DateOfBirth,
            string FirstName,string LastName,string PhoneNumber,string Email,string Address,
            string imageUrl,int  CountryID)
        {
            this._PersonID = PersonID;
            this.NationalID = NationalID;
            this.Gender = Gender;
            this.DateOFBirth= DateOfBirth;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Address = Address;
            this.ImageUrl = imageUrl;
            this.CountryID = CountryID;

            this._Mode = enMode.Update;

        }



        public   static async Task <ClsPerson> Find(int PersonID)
        {
           

            var P = await ClsPersonData.GetPersonInfoByPersonID(PersonID);

            if (P.NationalID!=-1)
                return new ClsPerson(PersonID,P.NationalID, P.Gender,P.DateOFBirth,P.FirstName,
                    P.LastName, P.PhoneNumber,P.Email,P.Address,P.ImageUrl,P.CountryID);

            else
                return null;

        }
        
    }
}
