using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
namespace BankingSystem_DataAccess
{
    public  class ClsConnectionStrings
    {
       public static  string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        
    }
}
