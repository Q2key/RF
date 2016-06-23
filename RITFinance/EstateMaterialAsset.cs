namespace RITFinance
{
    class EstateMaterialAsset : MaterialAsset
    {
       public string BuildingDate { get; set; }
       public string Adress { get; set; }

        EstateMaterialAsset ()
        { }

        public EstateMaterialAsset(string name, string addinfo, string initcost, string finalcost, string estcost, string bdate, string adress) : base (name,addinfo,initcost,finalcost,estcost)
        {   
            BuildingDate = bdate;
            Adress = adress;
            Type = "Недвижимость";
            Id = SetId();
        }

        public override string SetId()
        {
            return "HM";
        }
    }
}
