using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace RITFinance
{
    public delegate void UIdelegate();

    partial class UiСontroller 
    {

        private static CashAsset _cAsset;
        private static BankAsset _bAsset;
        private static MaterialAsset _mAsset;
        private static EstateMaterialAsset _eAsset;

        public void CreateCashAsset(string name, string amount, string valute, string info)   
        {
            _cAsset = new CashAsset(name, amount, valute, info);
        }

        public void CreateBankAsset(string assetname, string amount, string valute, string bankaccount, string bankname,
            string info)
        {
            _bAsset = new BankAsset(assetname, amount, valute, bankaccount, bankname, info);
        }

        public void CreateMaterialAsset(string name, string addinfo, string initcost, string finalcost,
            string estcost)
        {
            _mAsset = new MaterialAsset(name, addinfo, initcost, finalcost, estcost);
        }

        public void CreateMaterialEstaeteAsset(string name, string addinfo, string initcost, string finalcost,
            string estcost, string bdate, string adres)
        {
            _eAsset = new EstateMaterialAsset(name, addinfo, initcost, finalcost, estcost, bdate, adres);
        }
        public static Asset AddAssetToListView(string type)
        {
            if (type == "MC")//MC = Money cash deposite
            {
                return _cAsset;
            }
            if (type == "MB")//MB = Money banc deposite
            {
                return _bAsset;
            }
            if (type == "NM")//NM = Material deposite
            {
                return _mAsset;
            }
            if (type == "EM")//EM = Material estate
            {
                return _eAsset;
            }
            else
            {
                return new Asset();
            }          
        }

        public static string StringCheker(string s)
        {   
            var reg = new Regex(@"\d");
            var result = reg.Matches(s).Cast<Match>().Aggregate(string.Empty, (current, m) => current + m.Value);
            return result;
        }

    }
}
