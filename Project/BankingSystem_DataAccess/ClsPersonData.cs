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
using System.Net;
namespace BankingSystem_DataAccess
{
    public  class ClsPersonData
    {
     
        public async static Task< (int NationalID,  bool Gender,
            DateTime DateOFBirth,  string FirstName,  string LastName,  string PhoneNumber,
            string Email,  string Address,  string  ImageUrl,  int CountryID)>    GetPersonInfoByPersonID( int PersonID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_GetPersonInfo", conn))
                    {
                       await    conn.OpenAsync();
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


                        
                     await   cmd.ExecuteNonQueryAsync();
                       
                    int CountryID = (int)cmd.Parameters["@countryID"].Value;
                    int     NationalID = (int)cmd.Parameters["@NationalID"].Value;
                    bool     Gender = (bool)cmd.Parameters["@Gender"].Value;
                      DateTime  DateOFBirth = (DateTime)cmd.Parameters["@DateOFBirth"].Value;
                  string      FirstName = (string)cmd.Parameters["@FirstName"].Value;
                   string     LastName = (string)cmd.Parameters["@LastName"].Value;
                    string    PhoneNumber = (string)cmd.Parameters["@PhoneNumber"].Value;
                     string   Email = (string)cmd.Parameters["@Email"].Value;
                      string  Address = (string)cmd.Parameters["@Address"].Value;
                        string ImageUrl;
                        if (cmd.Parameters["@image"].Value!=DBNull.Value)
                        {
                            string pathFromDb = (string)cmd.Parameters["@image"].Value; ;
                            string fixedPath = pathFromDb.Replace(@"\\", @"\");
                            ImageUrl = fixedPath;
                        }
                          
                        else
                        {
                            ImageUrl=null;
                        }

                      conn.Close();

                return        ( NationalID,  Gender,
             DateOFBirth,  FirstName,  LastName,  PhoneNumber,
             Email,  Address,  ImageUrl,  CountryID);

                    }

                }
            }
            catch(Exception ex)
            {

               ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return (-1, false,
              DateTime.Now, "", "", "",
              "", "", "",-1);

        }
    }
    }

