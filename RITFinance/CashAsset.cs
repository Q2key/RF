using System.Windows;

namespace RITFinance
{
    internal class CashAsset : MonetaryAsset, IAssetProvider
    {   
        public CashAsset()
        { }

        public CashAsset(string name, string amount, string valute, string info)
        {
            AssetName =  name;
            Amount = amount;
            OtherInfo = info;
            Valute = valute;
            Id = SetId();
            Type = "Денежный в кассе";
        }

        public override string SetId()
        {
            return "K";
        }
    }
}
