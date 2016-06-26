namespace RITFinance
{
    class MaterialAsset : Asset,IAssetProvider
    {
        public string InitialBalanceCecost { get; set; }
        public string FinalBalanceCost { get; set; }
        public string EstimatedCost { get; set; }

        public MaterialAsset(string name,string addinfo, string initcost, string finalcost, string estcost)
        {
            AssetName = name;
            OtherInfo = addinfo;
            InitialBalanceCecost = initcost;
            FinalBalanceCost = finalcost;
            EstimatedCost = estcost;
            Id = SetId();
            Type = "Имущественный";
        }
        public MaterialAsset()
        { }

        public override string SetId()
        {
            return "ИМ";
        }
    }
}
