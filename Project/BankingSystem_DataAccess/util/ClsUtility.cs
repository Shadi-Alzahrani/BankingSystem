using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DataAccess
{
    public  class ClsUtility
    {
        public static void LogSqlExceptionToWinEventLog(Exception ex)
        {
            string SourceName = "BankingSystem.DbLayer";

            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
                
            }
            EventLog.WriteEntry(SourceName, $"an Error Occurd Becase :{ex.Message} ", EventLogEntryType.Error);
           
        }
    }
}
