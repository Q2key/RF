using System.Windows;

namespace RITFinance
{
    internal class MonetaryAsset : Asset, IAssetProvider
    {   
        public string Amount { get; set; }
        public string Valute { get; set; }

        public MonetaryAsset(string name, string amount, string valute) 
        {
            Amount = amount;
            AssetName = name;
            Valute = valute;
            Type = @"Денежный актив";

        }
        public MonetaryAsset()
        {
        }
     
    }
}
