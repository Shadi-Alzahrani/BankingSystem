using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
namespace BankingSystem_DataAccess
{
    public  class ClsPersonData
    {
     
        public static  bool GetPersonInfoByPersonID( int PersonID, ref int NationalID,ref bool Gender,
           ref DateTime DateOFBirth ,ref string FirstName,ref string LastName,ref string PhoneNumber,
           ref string Email,ref string Address,ref  string  ImageUrl,ref int CountryID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_GetPersonInfo", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        SqlParameter NationalIDParm = new SqlParameter("@NationalID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(NationalIDParm);

                        SqlParameter GenderParm = new SqlParameter("@Gender", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(GenderParm);

                        SqlParameter DateOFBirthParm = new SqlParameter("@DateOfBirth", SqlDbType.Date)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(DateOFBirthParm);

                        SqlParameter FirstnameParm = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(FirstnameParm);

                        SqlParameter LastnameParm = new SqlParameter("@LastName", SqlDbType.NVarChar,50)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(LastnameParm);


                        SqlParameter PhoneNumberParm = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,20)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(PhoneNumberParm);

                        SqlParameter EmailParm = new SqlParameter("@Email", SqlDbType.NVarChar,50)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(EmailParm);


                        SqlParameter AddressParm = new SqlParameter("@Address", SqlDbType.NVarChar, 250  )
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(AddressParm);



                        SqlParameter @ImageParm = new SqlParameter("@Image", SqlDbType.NVarChar,100)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(@ImageParm);


                        SqlParameter CountryIDParm = new SqlParameter("@countryID", SqlDbType.Int)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CountryIDParm);


                        
                        cmd.ExecuteReader();
                       

                        NationalID = (int)cmd.Parameters["@PersonID"].Value;
                        Gender = (bool)cmd.Parameters["@Gender"].Value;
                        DateOFBirth = (DateTime)cmd.Parameters["@DateOFBirth"].Value;
                        FirstName = (string)cmd.Parameters["@FirstName"].Value;
                        LastName = (string)cmd.Parameters["@LastName"].Value;
                        PhoneNumber = (string)cmd.Parameters["@PhoneNumber"].Value;
                        Email = (string)cmd.Parameters["@Email"].Value;
                        Address = (string)cmd.Parameters["@Address"].Value;  
                        if(cmd.Parameters["@image"].Value!=DBNull.Value)
                        ImageUrl = (string)cmd.Parameters["@image"].Value;
                        else
                        {
                            ImageUrl=null;
                        }

                      conn.Close();

                        return true;

                    }

                }
            }
            catch(Exception ex)
            {

               ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return false;

        }
    }
}
