namespace RITFinance
{
    internal class BankAsset : MonetaryAsset, IAssetProvider
    {
        public string BankAccount { get; set; }
        public string BankName { get; set; }

        public BankAsset()//default ctor.
        {
        }

        public BankAsset(string assetname, string amount, string valute, string bankaccount, string bankname, string info)
        {
            AssetName = assetname;
            Amount = amount;
            BankAccount = bankaccount;
            BankName = bankname;
            OtherInfo = info;
            Valute = valute;
            Type = "Денежный в банке";
            Id = SetId();
        }

        public override string SetId()
        {
            return "Б";
        }
    }
}
