using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem_DataAccess;

namespace BankingSystem_Business
{
    public  class clsUser
    {
        //u.UserID,u.PersonID,u.UserName,u.Password,u.IsAdmin,u.IsActive,u.CreatedDate,u.LastLoginDate 
        enum enMode {Add=0,Update=1 }
        private  enMode _Mode ;

        private int _UserID;
        public int UserID { get { return _UserID; } }

        public int PersonID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }


        private clsUser(int UserID, int PersonID, string UserName, string Password,
            bool IsAdmin, bool IsActive,DateTime? CreatedDate,DateTime? LastLoginDate)
        {
            this._UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.CreatedDate = CreatedDate;
            this.LastLoginDate = LastLoginDate;
            this.IsAdmin = IsAdmin;

            this._Mode = enMode.Update;
        }

        public clsUser()
        {
            this._UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.CreatedDate = DateTime.Now;
            this.LastLoginDate = DateTime.Now;
            this.IsAdmin = false;

            this._Mode = enMode.Update;
        }


        public async static Task<bool> IsUserExists(string UserName,string Password)
        {
              return     await    clsUserData.IsUserExist(UserName, Password);
        }

        public static async Task<clsUser> FindUserByUserName(string UserName)
        {
            var U = await clsUserData.GetUserInfoByUserName(UserName);

            if (U.UserID != -1)
                return new clsUser(U.UserID,U.PersonID,UserName,U.Password,
                    U.IsAdmin,U.IsActive,U.CreatedDate,U.LastLoginDate);

            else
                return null;
        }

        public static async Task<clsUser> FindUserByPersonID(int PersondID)
        {
            var U = await clsUserData.GetUserInfoByPersonID(PersondID);

            if (U.UserID != -1)
                return new clsUser(U.UserID, PersondID, U.UserName, U.Password,
                    U.IsAdmin, U.IsActive, U.CreatedDate, U.LastLoginDate);

            else
                return null;
        }

        public static async Task<clsUser> FindUserByUserID(int UserID)
        {
            var U = await clsUserData.GetUserInfoByUserID(UserID);

            if (U.personid != -1)
                return new clsUser(UserID, U.personid, U.UserName, U.Password,
                    U.IsAdmin, U.IsActive, U.CreatedDate, U.LastLoginDate);

            else
                return null;
        }
        public static async Task<bool> UpdatePassword(int UserID,string NewPassword)
        {
            
            return await clsUserData.UpdateUserPassword(UserID, NewPassword);
        }
    
    public static async Task<bool> UpdateUserLastLoginDate(int UserID)
        {
            return  await clsUserData.UpdateUserLastLoginDate(UserID);
        }
    
        public static async Task<DataTable> GetAllUsers()
        {
            return await clsUserData.GetAllUsers();
        }

      public static async Task<bool > UpdateUserActiveStatus(int UserID,bool ActiveStatus)
        {
         return await   clsUserData.UpdateUserActiveStatus(UserID,ActiveStatus);
        }
    }
}
