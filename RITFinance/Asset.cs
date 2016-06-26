using System.ComponentModel;
using System.Runtime.CompilerServices;
using RITFinance.Annotations;

namespace RITFinance
{
    enum AssetTypes
    {
        MoneyCashAsset,
        MoneyBankAsset,
        ItemEstateAsset,
        ItemOthetAsset

    }

    internal class Asset : IAssetProvider, INotifyPropertyChanged
    {
        public string AssetName { get; set; }
        public string OtherInfo { get; set; }
        public string Type { get; set; }
        public string Id { get;  set; }
 

        public Asset()
        {
            AssetName = "Deffault asset";
        }
        public Asset(string name, string info, string type)
        {
            this.AssetName = name;
            this.OtherInfo = info;
            this.Type = type;
            Id = SetId();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual string SetId()
        {
            return "A";
        }
    }
}
