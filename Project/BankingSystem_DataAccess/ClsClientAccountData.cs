using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DataAccess
{
    public  class ClsClientAccountData
    {
        /*
@ClientID ,
@AccountID ,
@AccountNumber  ,
@Balance ,
@AccountStatusID ,
@CreatedDate ,
@CloseDate  ,
@CreatedByUserID 
         */

       

        public static async Task<( string AccountName,  string AccountNumber,
          decimal Balance,  int AccountStatusID,  DateTime CreatedDate,
          DateTime? CloseDate,  int CreatedByUserID )>  GetClientAccountByClientID(int ClientID, int AccountID )
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_GetClientAccountInfoByClientID", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);
                        cmd.Parameters.AddWithValue("@AccountID", AccountID);
                       

                        SqlParameter AccountNumberParm = new SqlParameter("@AccountNumber", SqlDbType.NVarChar,20)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(AccountNumberParm);

                        SqlParameter BalanceParm = new SqlParameter("@Balance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };



                        cmd.Parameters.Add(BalanceParm);

                        SqlParameter AccountStatusIDParm = new SqlParameter("@AccountStatusID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(AccountStatusIDParm);

                        SqlParameter CreatedDateParm = new SqlParameter("@CreatedDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedDateParm);

                        
                        SqlParameter CloseDateParm = new SqlParameter("@CloseDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CloseDateParm);

                        SqlParameter CreatedByUserIDParm = new SqlParameter("@CreatedByUserID", SqlDbType.Int)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedByUserIDParm);


                        SqlParameter AccountNameParm = new SqlParameter("@AccountName", SqlDbType.NVarChar,100)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(AccountNameParm);

                        cmd.ExecuteNonQuery();



                        AccountID = (int)cmd.Parameters["@AccountID"].Value;

                       
                    string    AccountName = cmd.Parameters["@AccountName"].Value == DBNull.Value 
                           ? null
                           : (string)cmd.Parameters["@AccountName"].Value;

                    DateTime?    CloseDate = cmd.Parameters["@CloseDate"].Value == DBNull.Value
                      ? (DateTime?)null
                      : (DateTime)cmd.Parameters["@CloseDate"].Value;

                      string  AccountNumber = (string)cmd.Parameters["@AccountNumber"].Value;
                      decimal  Balance = (decimal)cmd.Parameters["@Balance"].Value;
                      int   AccountStatusID = (int)cmd.Parameters["@AccountStatusID"].Value;
                      DateTime  CreatedDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;

                      


                     int    CreatedByUserID = (int)cmd.Parameters["@CreatedByUserID"].Value;
                       
                        
                        conn.Close();

                        return (AccountName, AccountNumber,
             Balance, AccountStatusID, CreatedDate,
            CloseDate, CreatedByUserID);

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return   ("", "",
             0, -1, DateTime.Now,
            null, -1); 

        }

        public static async Task<(int ClientID,string AccountName, string AccountNumber,
         decimal Balance, int AccountStatusID, DateTime CreatedDate,
         DateTime? CloseDate, int CreatedByUserID)> GetClientAccountByAccountID( int AccountID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getAccountByAccountID", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountID", AccountID);


                        SqlParameter AccountNumberParm = new SqlParameter("@AccountNumber", SqlDbType.NVarChar, 20)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(AccountNumberParm);


                        SqlParameter ClientIDParm = new SqlParameter("@ClientID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(ClientIDParm);


                        SqlParameter BalanceParm = new SqlParameter("@Balance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };



                        cmd.Parameters.Add(BalanceParm);

                        SqlParameter AccountStatusIDParm = new SqlParameter("@AccountStatusID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(AccountStatusIDParm);

                        SqlParameter CreatedDateParm = new SqlParameter("@CreatedDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedDateParm);


                        SqlParameter CloseDateParm = new SqlParameter("@CloseDate", SqlDbType.DateTime)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CloseDateParm);

                        SqlParameter CreatedByUserIDParm = new SqlParameter("@CreatedByUserID", SqlDbType.Int)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(CreatedByUserIDParm);


                        SqlParameter AccountNameParm = new SqlParameter("@AccountName", SqlDbType.NVarChar, 100)
                        {

                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(AccountNameParm);

                      await  cmd.ExecuteNonQueryAsync();



                        AccountID = (int)cmd.Parameters["@AccountID"].Value;


                        string AccountName = cmd.Parameters["@AccountName"].Value == DBNull.Value
                               ? null
                               : (string)cmd.Parameters["@AccountName"].Value;

                        DateTime? CloseDate = cmd.Parameters["@CloseDate"].Value == DBNull.Value
                          ? (DateTime?)null
                          : (DateTime)cmd.Parameters["@CloseDate"].Value;

                        string AccountNumber = (string)cmd.Parameters["@AccountNumber"].Value;
                        decimal Balance = (decimal)cmd.Parameters["@Balance"].Value;
                        int AccountStatusID = (int)cmd.Parameters["@AccountStatusID"].Value;
                        DateTime CreatedDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;

                        int ClientID = (int)cmd.Parameters["@ClientID"].Value;


                        int CreatedByUserID = (int)cmd.Parameters["@CreatedByUserID"].Value;


                        conn.Close();

                        return (ClientID, AccountName, AccountNumber,
             Balance, AccountStatusID, CreatedDate,
            CloseDate, CreatedByUserID);

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return (-1,"", "",
             0, -1, DateTime.Now,
            null, -1);

        }



        public static async Task< decimal> GetClientTotalBalance(int ClientID )
        {
            decimal TotalBalance=-1;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetTotalBalance", conn))
                    {
                       await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);
                      


                        SqlParameter TotalBalanceParm = new SqlParameter("@TotalBalance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        TotalBalanceParm.Precision = 18;  // عدد الأرقام الكلي
                        TotalBalanceParm.Scale = 2;
                        cmd.Parameters.Add(TotalBalanceParm);

                        

                     await    cmd.ExecuteNonQueryAsync();

                        TotalBalance = (decimal)cmd.Parameters["@TotalBalance"].Value;




                        conn.Close();

                      

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

           return TotalBalance;

        }

        public static async Task<int>  GetClientTotalAccounts(int ClientID)
        {
            int TotalAccount = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_GetTotalAccountNumber", conn))
                    {
                       await  conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);



                        SqlParameter TotalAccParm = new SqlParameter("@TotalAccounts", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(TotalAccParm);



                      await  cmd.ExecuteNonQueryAsync();

                      TotalAccount = (int)cmd.Parameters["@TotalAccounts"].Value;




                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

             return TotalAccount;

        }

        public static  async Task< DataTable> GetAllClientAccounts(int ClientID)
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllClientAccounts", conn))
                    {
                     await   conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);

                        using (SqlDataReader R = await  cmd.ExecuteReaderAsync())
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
        public static async Task<decimal> GetTotalAmountPerTransaction(int ClientID,int TransactionType)
        {
            decimal TotalAmount = 0;
            try
            {
               
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetTotalAmountPerTransaction", conn))
                    {
                      await  conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TransactionType", TransactionType);
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);

                        SqlParameter AmountParm = new SqlParameter("@TotalAmount", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,

                        };
                        AmountParm.Precision = 18;
                        AmountParm.Scale = 2;

                        cmd.Parameters.Add(AmountParm);

                        await cmd.ExecuteNonQueryAsync();

                        TotalAmount = (decimal)cmd.Parameters["@TotalAmount"].Value;

                        conn.Close();

                       

                    }
                    
                }
            
            }
            catch(Exception ex)
            {
                ClsUtility.LogSqlExceptionToWinEventLog(ex);
            }

            return TotalAmount;
        }

        public static async Task<DataTable> GetAllAccountsTransActions(int ClientID,int PageNumber)
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getAllTransactions", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);
                        cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
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

        public static async Task<int > Deposite(int AccountID,decimal Amount , int CurencyID,string Descripation,int TransType)
        {
            int TransactionID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Deposit", conn))
                    {
                      await  conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountID", AccountID);
                        cmd.Parameters.AddWithValue("@Amount", Amount);
                        cmd.Parameters.AddWithValue("@CurrencyID",  CurencyID);
                        cmd.Parameters.AddWithValue("@Description", Descripation);
                        cmd.Parameters.AddWithValue("@TransactionType", TransType);

                        SqlParameter TransactionIDParm = new SqlParameter("@TransactionID", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        TransactionIDParm.Precision = 18;
                        TransactionIDParm.Scale = 2;

                        cmd.Parameters.Add(TransactionIDParm);

                           await  cmd.ExecuteNonQueryAsync();

                       TransactionID = Convert.ToInt32( cmd.Parameters["@TransactionID"].Value);

                        conn.Close();

                       

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

           return TransactionID;

        }

        public static async Task<int> Transfare(int AccountFromID,int AccountToID, decimal Amount,  string Descripation)
        {
            int TransactionID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Transfare", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountFromID", AccountFromID);
                        cmd.Parameters.AddWithValue("@AccountToID", AccountToID);
                        cmd.Parameters.AddWithValue("@Amount", Amount);
                        cmd.Parameters.AddWithValue("@Description", Descripation);
                       

                        SqlParameter TransactionIDParm = new SqlParameter("@TransactionID", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        TransactionIDParm.Precision = 18;
                        TransactionIDParm.Scale = 2;

                        cmd.Parameters.Add(TransactionIDParm);

                        await cmd.ExecuteNonQueryAsync();

                        TransactionID = Convert.ToInt32(cmd.Parameters["@TransactionID"].Value);

                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return TransactionID;

        }
        public async static Task<(string FullName,string AccountNumber)> GetAccountForTransfer(int AccountID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetAccountForTransfer", conn))
                    {
                       await conn.OpenAsync();

                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        cmd.Parameters.AddWithValue("@AccountID", AccountID);


                        SqlParameter AccountNumberParm = new SqlParameter("@AccountNumber", SqlDbType.NVarChar, 20)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(AccountNumberParm);

                        SqlParameter FullNameParm = new SqlParameter("@FullName", SqlDbType.NVarChar, 50)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(FullNameParm);





                     await   cmd.ExecuteNonQueryAsync();

                        string FullName = (string)cmd.Parameters["@FullName"].Value;
                        string AccountNumber = (string)cmd.Parameters["@AccountNumber"].Value;








                        conn.Close();

                     return   (FullName, AccountNumber);

                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return ("","");

        }

        public static async Task<int > GetTotalClientTransactions(int ClientID)
        {
            int TotalTrans = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetTotalClientTransaction", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);

                        SqlParameter TotalParm = new SqlParameter("@TotalTransactions", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };

                        cmd.Parameters.Add(TotalParm);


                        await cmd.ExecuteNonQueryAsync();



                        TotalTrans = (int)cmd.Parameters["@TotalTransactions"].Value;
                        

                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return TotalTrans;

        }


        public static async Task<int> GetTotalNumberOfAccounts()
        {
            int TotalAccounts = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getTotalNumberOfAccounts", conn))
                    {



                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter NumberOFClientsParm = new SqlParameter("@NumberOFAccounts", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(NumberOFClientsParm);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        TotalAccounts = (int)cmd.Parameters["@NumberOFAccounts"].Value;

                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return TotalAccounts;

        }

        public static async Task<int> GetTotalNumberOfTransactions()
        {
            int TotalTrans = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getTotalNumberOfTransactions", conn))
                    {



                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter NumberOFClientsParm = new SqlParameter("@NumberOFTransactions", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(NumberOFClientsParm);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        TotalTrans = (int)cmd.Parameters["@NumberOFTransactions"].Value;

                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return TotalTrans;

        }

        public static async Task<decimal> GetTotalBalnces()
        {
            decimal TotalBalances = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetTotalBalances", conn))
                    {



                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter TotalBalnacesParm = new SqlParameter("@TotalBalance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        TotalBalnacesParm.Precision = 18;
                        TotalBalnacesParm.Scale = 2;

                        cmd.Parameters.Add(TotalBalnacesParm);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        TotalBalances = (decimal)cmd.Parameters["@TotalBalance"].Value;

                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return TotalBalances;

        }


        public static async Task<decimal> GetClientsTotalTransaction(int TransactionType)
        {
            decimal TotalTrans = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetClientsTotalPerTransaction", conn))
                    {



                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TransActionType", TransactionType);

                        SqlParameter TotalTransParm = new SqlParameter("@TransActionTotal", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        TotalTransParm.Precision = 18;
                        TotalTransParm.Scale = 2;

                        cmd.Parameters.Add(TotalTransParm);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        TotalTrans = (decimal)cmd.Parameters["@TransActionTotal"].Value;

                        conn.Close();



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return TotalTrans;

        }

        public static async Task<DataTable> GetAllClientsAccounts()
        {
            DataTable result = new DataTable();


            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetFullAccountsInfo", conn))
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


        public static async Task<bool> UpdateAccountStatus(int AccountID,int AccountStatus,string CloseReason=null)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnectionStrings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateAccountStatus", conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountID", AccountID);
                        cmd.Parameters.AddWithValue("@AccountStatusType", AccountStatus);

                        if(CloseReason!=null)
                        cmd.Parameters.AddWithValue("@CloseReason", CloseReason);
                        else
                         cmd.Parameters.AddWithValue("@CloseReason", DBNull.Value);



                        RowAffected = await cmd.ExecuteNonQueryAsync();

                         

                       



                    }

                }
            }
            catch (Exception ex)
            {

                ClsUtility.LogSqlExceptionToWinEventLog(ex);

            }

            return RowAffected>0;

        }

    }
}
    

