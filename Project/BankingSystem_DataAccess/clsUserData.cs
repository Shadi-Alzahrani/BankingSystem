using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DataAccess
{
    public  class clsUserData
    {
        //u.UserID,u.PersonID,u.UserName,u.Password,u.IsAdmin,
        //u.IsActive,u.CreatedDate,u.LastLoginDate 
        public static async Task<bool> IsUserExist(string UserName,string Password)
        {
            bool IsExists = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_IsUserNameAndPasswordExists", conn))
                    {
                        await conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        cmd.Parameters.Add(returnParameter);


                        await cmd.ExecuteNonQueryAsync();


                        IsExists = (int)returnParameter.Value==1;






                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return IsExists;

        }

        public async static Task<(int UserID,int PersonID,string Password,bool IsAdmin,
            bool IsActive,DateTime? CreatedDate,DateTime? LastLoginDate)> GetUserInfoByUserName(string UserName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetUserInfoByUserName", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", UserName);

                        SqlParameter PersonIDParm = new SqlParameter("@PersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(PersonIDParm);


                        SqlParameter UserIDParm = new SqlParameter("@UserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(UserIDParm);



                        SqlParameter PasswordParm = new SqlParameter("@Password", SqlDbType.NVarChar,256)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(PasswordParm);


                        SqlParameter IsAdminParm = new SqlParameter("@IsAdmin", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(IsAdminParm);


                        SqlParameter IsActiveParm = new SqlParameter("@IsActive", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(IsActiveParm);



                        SqlParameter CreatedDateParm = new SqlParameter("@CreateDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedDateParm);


                        SqlParameter LastLoginDateParm = new SqlParameter("@LastLoginDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(LastLoginDateParm);


                        await cmd.ExecuteNonQueryAsync();

                        int UserID = (int)cmd.Parameters["@UserID"].Value;
                        int PersonID = (int)cmd.Parameters["@PersonID"].Value;
                        string  Password = (string)cmd.Parameters["@Password"].Value;
                        bool IsAdmin = (bool)cmd.Parameters["@IsAdmin"].Value;
                        bool IsActive = (bool)cmd.Parameters["@IsActive"].Value;
                        DateTime? CreatedDate = (DateTime)cmd.Parameters["@CreateDate"].Value;
                        DateTime? LastLoginDate = (DateTime)cmd.Parameters["@LastLoginDate"].Value;

                        conn.Close();

                        return (UserID,PersonID,Password,IsAdmin,IsActive,CreatedDate,LastLoginDate);

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

              return (-1, -1,"", false, false, null, null);

        }
    
      public async static Task<(int UserID, string UserName, string Password, bool IsAdmin,
            bool IsActive, DateTime? CreatedDate, DateTime? LastLoginDate)> GetUserInfoByPersonID(int PersonID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetUserInfoByPersonID", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID",PersonID);

                        SqlParameter UserNameParm = new SqlParameter("@UserName", SqlDbType.NVarChar,100)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(UserNameParm);


                        SqlParameter UserIDParm = new SqlParameter("@UserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(UserIDParm);



                        SqlParameter PasswordParm = new SqlParameter("@Password", SqlDbType.NVarChar, 256)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(PasswordParm);


                        SqlParameter IsAdminParm = new SqlParameter("@IsAdmin", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(IsAdminParm);


                        SqlParameter IsActiveParm = new SqlParameter("@IsActive", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(IsActiveParm);



                        SqlParameter CreatedDateParm = new SqlParameter("@CreateDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedDateParm);


                        SqlParameter LastLoginDateParm = new SqlParameter("@LastLoginDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(LastLoginDateParm);


                        await cmd.ExecuteNonQueryAsync();
                        
                        int UserID = (int)cmd.Parameters["@UserID"].Value;
                        string UserName = (string)cmd.Parameters["@UserName"].Value;
                        string Password = (string)cmd.Parameters["@Password"].Value;
                        bool IsAdmin = (bool)cmd.Parameters["@IsAdmin"].Value;
                        bool IsActive = (bool)cmd.Parameters["@IsActive"].Value;
                        DateTime? CreatedDate = (DateTime)cmd.Parameters["@CreateDate"].Value;
                        DateTime? LastLoginDate = (DateTime)cmd.Parameters["@LastLoginDate"].Value;

                        conn.Close();

                        return (UserID, UserName, Password, IsAdmin, IsActive, CreatedDate, LastLoginDate);

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return (-1, "", "", false, false, null, null);

        }


        public static async Task<bool> UpdateUserPassword(int  UserID, string NewPassword)
        {
            int  AffectRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateUserPassword", conn))
                    {
                        await conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@NewPassword", NewPassword);


                         AffectRows = await cmd.ExecuteNonQueryAsync();


                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return AffectRows>0;

        }


        public static async Task<bool> UpdateUserLastLoginDate(int UserID)
        {
            int  affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateUserLastLoginDate", conn))
                    {
                        await conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                       
                        affectedRows  = await cmd.ExecuteNonQueryAsync();

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return (affectedRows>0);

        }


        public static async Task<DataTable> GetAllUsers()
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllUsers", conn))
                    {
                        await conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        using (SqlDataReader R = await cmd.ExecuteReaderAsync())
                        {
                            if (R != null)
                            {
                                result.Load(R);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return result;

        }


        public async static Task<(int personid, string UserName, string Password, bool IsAdmin,
                bool IsActive, DateTime? CreatedDate, DateTime? LastLoginDate)> GetUserInfoByUserID(int UserID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getUserInfoByUserID", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);

                        SqlParameter UserNameParm = new SqlParameter("@UserName", SqlDbType.NVarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(UserNameParm);


                        SqlParameter PersonIDParm = new SqlParameter("@PersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(PersonIDParm);



                        SqlParameter PasswordParm = new SqlParameter("@Password", SqlDbType.NVarChar, 256)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(PasswordParm);


                        SqlParameter IsAdminParm = new SqlParameter("@IsAdmin", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(IsAdminParm);


                        SqlParameter IsActiveParm = new SqlParameter("@IsActive", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(IsActiveParm);



                        SqlParameter CreatedDateParm = new SqlParameter("@CreateDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedDateParm);


                        SqlParameter LastLoginDateParm = new SqlParameter("@LastLoginDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(LastLoginDateParm);


                        await cmd.ExecuteNonQueryAsync();

                        int PersonID = (int)cmd.Parameters["@PersonID"].Value;
                        string UserName = (string)cmd.Parameters["@UserName"].Value;
                        string Password = (string)cmd.Parameters["@Password"].Value;
                        bool IsAdmin = (bool)cmd.Parameters["@IsAdmin"].Value;
                        bool IsActive = (bool)cmd.Parameters["@IsActive"].Value;
                        DateTime? CreatedDate = (DateTime)cmd.Parameters["@CreateDate"].Value;
                        DateTime? LastLoginDate = (DateTime)cmd.Parameters["@LastLoginDate"].Value;

                        conn.Close();

                        return (PersonID, UserName, Password, IsAdmin, IsActive, CreatedDate, LastLoginDate);

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return (-1, "", "", false, false, null, null);

        }


        public static async Task<bool >UpdateUserActiveStatus(int UserID,bool ActiveStatus)
        {
            int  AffectedRows = 0;

            try
            {
               
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SetUserActiveStatus", conn))
                    {
                        await conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@ActiveStatus", ActiveStatus);

                        AffectedRows =  await cmd.ExecuteNonQueryAsync();
                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return AffectedRows>0;

        }
    }
}

