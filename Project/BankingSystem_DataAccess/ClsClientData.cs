using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DataAccess
{
    public  class ClsClientData
    {
        public async static Task<( int PersonID, DateTime CreatedDat)>  GetClientInfo(int ClientID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                   await  conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("Sp_GetClientInfo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ClientID", ClientID);

                        SqlParameter PersonIDParm = new SqlParameter("@PersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(PersonIDParm);


                        SqlParameter CreatedDateParm = new SqlParameter("@CreatedDate", SqlDbType.DateTime)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedDateParm);

                      await  cmd.ExecuteNonQueryAsync();

                      int   PersonID = (int)cmd.Parameters["@PersonID"].Value;
                       DateTime CreatedDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;

                        return (PersonID,CreatedDate);

                    }
                }
            }
            catch (Exception ex)
            {
                ClsUtility.LogSqlExceptionToWinEventLog(ex);
            }

            return(-1,DateTime.Now);
        }


        public async static Task<(int ClientID, DateTime CreatedDat)> GetClientInfoByPersonID(int PersonID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                  

                    using (SqlCommand cmd = new SqlCommand("sp_GetClientInfoByPersonID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PersonID", PersonID);



                        SqlParameter ClientIDParm = new SqlParameter("@ClientID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(ClientIDParm);


                        SqlParameter CreatedDateParm = new SqlParameter("@CreatedDate", SqlDbType.DateTime)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedDateParm);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        bool a = cmd.Parameters["@ClientID"].Value==DBNull.Value;
                        int ClientID = (int)cmd.Parameters["@ClientID"].Value;
                        DateTime CreatedDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;

                        return (ClientID, CreatedDate);

                    }
                }
            }
            catch (Exception ex)
            {
                ClsUtility.LogSqlExceptionToWinEventLog(ex);
            }

            return (-1, DateTime.Now);
        }

        public static async Task<DataTable> GetClientTransaction(int ClientID,int TransType,DateTime FromDate,DateTime ToDate)
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetTransactionReportPerTrans", conn))
                    {
                        await conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);
                        cmd.Parameters.AddWithValue("@TransactionTypeID", TransType);
                        cmd.Parameters.AddWithValue("@FromDate", FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", ToDate);


                        using (SqlDataReader R = await cmd.ExecuteReaderAsync())
                        {
                            if (R != null)
                            {
                                result.Load(R);
                            }
                        }






                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return result;

        }


        public async static Task<bool> UpdateClientInfo(int PersonID,string FirstName,string LastName,
            string Email,string PhoneNumber,string Address,string ImagePath)
        {

            int  AffictedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateClientPersonalInfo", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        cmd.Parameters.AddWithValue("@Address", Address);

                        if(ImagePath!=null)
                        cmd.Parameters.AddWithValue("@Image", ImagePath);
                        else
                        cmd.Parameters.AddWithValue("@Image", DBNull.Value);

                    AffictedRows=    await cmd.ExecuteNonQueryAsync();

                        conn.Close();

                     

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);
                return false;
            }

            return AffictedRows != 0;

        }



        public static async Task<int> GetTotalNumberOfClients()
        {
            int TotalClients = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getTotalNumberOfClients", conn))
                    {

                      
                     
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter NumberOFClientsParm = new SqlParameter("@NumberOFClients", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(NumberOFClientsParm);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        TotalClients =(int) cmd.Parameters["@NumberOFClients"].Value;

                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return TotalClients;

        }


    }
}

