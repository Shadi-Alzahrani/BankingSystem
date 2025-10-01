using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DataAccess
{
    public  class clsCurrencyData
    {
        /*
@CurrencySymbol nvarchar(20)  ,
@ID int out,
@Name nvarchar(50) out ,
@CountryID int out,
@ExchangeRate decimal (18,2) out ,
@status int out */
        public static async Task<(int  CurrencyID, string CurrencyName,
            int CountryID,decimal ExchangeRate,int status)> GetCurrencyInfo(string CurrencySymbol)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                  await  conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GetCurrencyInfo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CurrencySymbol", CurrencySymbol);


                        SqlParameter ParmCurrencyID = new SqlParameter("@ID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(ParmCurrencyID);



                        SqlParameter CurrencyNameParm = new SqlParameter("@Name", SqlDbType.NVarChar,50)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CurrencyNameParm);

                        SqlParameter CountryIDParm = new SqlParameter("@CountryID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CountryIDParm);


                        SqlParameter ExchangeRateParm = new SqlParameter("@ExchangeRate", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        ExchangeRateParm.Precision = 18;
                        ExchangeRateParm.Scale = 2;
                        cmd.Parameters.Add(ExchangeRateParm);

                        SqlParameter statusParm = new SqlParameter("@status", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(statusParm);

                        await   cmd.ExecuteNonQueryAsync();

                       int CurrencyID  = (int ) cmd.Parameters["@ID"].Value;
                        string CurrencyName = (string) cmd.Parameters["@Name"].Value;
                        int CountryID  = (int)cmd.Parameters["@CountryID"].Value;
                        decimal ExchangeRate = (decimal)cmd.Parameters["@ExchangeRate"].Value;
                        int status = (int)cmd.Parameters["@status"].Value;

                        return (CurrencyID, CurrencyName, CountryID, ExchangeRate, status);


                    }
                }
            }
            catch (Exception ex)
            {
                ClsUtility.LogSqlExceptionToWinEventLog(ex);
            }

            return (-1,"",-1,0,-1);
        }






        public static async Task<DataTable> GetAllCurrency()
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getAllCurrency", conn))
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
        

    }
}
