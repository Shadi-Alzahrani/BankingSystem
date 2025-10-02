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
    }
}
