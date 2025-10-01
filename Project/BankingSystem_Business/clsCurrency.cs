using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem_DataAccess;

namespace BankingSystem_Business
{
    public  class clsCurrency
    {
        /*
@CurrencySymbol nvarchar(20)  ,
@ID int out,
@Name nvarchar(50) out ,
@CountryID int out,
@ExchangeRate decimal (18,2) out ,
@status int out */

       public string CurrencySymbol {  get; set; }
        public   int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public int  CountryID { get; set; }
        public decimal ExchangeRate {  get; set; }
        public int Status { get; set; }

      private  clsCurrency(string CurrencySymbol,int CurrencyID,string CurrencyName,
         int CountryID,decimal ExchangeRate,int Status)
        {
            this.CurrencySymbol = CurrencySymbol;
            this.CurrencyID = CurrencyID;
            this.CurrencyName = CurrencyName;
            this.CountryID = CountryID;
            this.ExchangeRate = ExchangeRate;
            this.Status = Status;

        }


        public async static Task< clsCurrency> FindCurrencyByCurrencySymbol(string CurrencySymbol)
        {
            var Ob  = await clsCurrencyData.GetCurrencyInfo(CurrencySymbol);

            if (Ob.CurrencyID != -1)
                return new  clsCurrency(CurrencySymbol,Ob.CurrencyID,Ob.CurrencyName,Ob.CountryID,Ob.ExchangeRate,Ob.status);
            else
                return null;

        }


        public static async Task<DataTable> GetAllCurrency()
        {
            return await clsCurrencyData.GetAllCurrency();
        }
    }
}
