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
        public static bool  GetClientInfo(int ClientID, ref int PersonID, ref DateTime CreatedDate )
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    conn.Open();
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

                        cmd.ExecuteReader();

                        PersonID = (int)cmd.Parameters["@PersonID"].Value;
                        CreatedDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;

                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                ClsUtility.LogSqlExceptionToWinEventLog(ex);
            }
          
            return false;
        }
    }
}
