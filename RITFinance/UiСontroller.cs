using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace RITFinance
{
    public delegate void UIdelegate();

    partial class UiСontroller
    {
        private static readonly ObservableCollection<Asset> Assets;

        static UiСontroller()
        {
            Assets = new ObservableCollection<Asset>();
        }

        public void CreateCashAsset(string name, string amount, string valute, string info)
        {            
            Assets.Add(new CashAsset(name, amount, valute, info)); 
        }

        public void CreateBankAsset(string name, string amount, string valute, string bankaccount, string bankname,
            string info)
        {
            Assets.Add(new BankAsset(name, amount, valute, bankaccount, bankname, info));
        }

        public void CreateMaterialAsset(string name, string addinfo, string initcost, string finalcost,
            string estcost)
        {
            
            Assets.Add(new MaterialAsset(name, addinfo, initcost, finalcost, estcost));
        }

        public void CreateMaterialEstaeteAsset(string name, string addinfo, string initcost, string finalcost,
            string estcost, string bdate, string adres)
        {
            Assets.Add(new EstateMaterialAsset(name, addinfo, initcost, finalcost, estcost, bdate, adres));
        }
      
        public static string StringCheker(string s)
        {
            var reg = new Regex(@"\d");
            var result = reg.Matches(s).Cast<Match>().Aggregate(string.Empty, (current, m) => current + m.Value);
            if (reg.IsMatch(s))
            {
                return ConvertToAmount(result);
            }
            return string.Empty;                            
            
        }

        private static string ConvertToAmount(string s)
        {
            var str = string.Format(CultureInfo.InvariantCulture,"{0:C2}", decimal.Parse(s));
            return str;
        }

        public static ObservableCollection<Asset> GetAssetsCollection()
        {
            return Assets;
        } 

    }
}
