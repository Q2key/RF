using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RITFinance
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButonAdd_Click(object sender, RoutedEventArgs e)
        {
            ExucuteAddMenu();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
           ExecuteEditMenu();
        }

        private void ExucuteAddMenu()
        {

            var addwindow = new AddEditwindow {Owner = this};
            addwindow.ShowDialog();
            if (addwindow.DialogResult == false) return;

            if (addwindow.RadioButtonCashAsset.IsChecked == true)
            {               
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("MC"));
            }
            if (addwindow.RadioButtonBankAsset.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("MB"));
            }
            if (addwindow.RadioButtonMaterialAsset.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("NM"));
            }
            if (addwindow.RadioButtonEstate.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("EM"));
            }
        }

        private void ExecuteEditMenu() 
        {
            var editwindow = new EditWindow();
            editwindow.Owner = this;
            editwindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var a = (Asset) ListViewMain.SelectedItem;
            if (a == null) return;
           
            if (a.Type == @"Денежный в кассе")
            {                
                var ca = (CashAsset) ListViewMain.SelectedItem;
                editwindow.CanvasCash.Visibility = Visibility.Visible;
                editwindow.TextBoxEditAmountC.Text = ca.Amount;
                editwindow.TextBoxEditNameC.Text = ca.AssetName;
                editwindow.TextBoxEditAdditionalInfoC.Text = ca.OtherInfo;
                editwindow.TextBoxEditValuteC.Text = ca.Valute;
                editwindow.ShowDialog();

                if (editwindow.DialogResult == true)
                {
                    if (UiСontroller.StringCheker(editwindow.TextBoxEditAmountC.Text) == "" || editwindow.TextBoxEditValuteC.Text == "")
                    {
                        MessageBox.Show("Заполните поля со звездочками");
                        ExecuteEditMenu();      
                    }
                    ca.Amount = editwindow.TextBoxEditAmountC.Text;
                    ca.AssetName = editwindow.TextBoxEditNameC.Text;
                    ca.OtherInfo = editwindow.TextBoxEditAdditionalInfoC.Text;
                    ca.Valute = editwindow.TextBoxEditValuteC.Text;
                    ListViewMain.Items.Refresh();
                }
            }
            if (a.Type == @"Денежный в банке")
            {
                var ba = (BankAsset) ListViewMain.SelectedItem;
                editwindow.CanvasBank.Visibility = Visibility.Visible;
                editwindow.TextBoxEditMonetaryNameB.Text = ba.AssetName;
                editwindow.TextBoxEditMonetaryAmountB.Text = ba.Amount;;
                editwindow.TextBoxEditMonetaryBankNameB.Text = ba.BankName;
                editwindow.TextBoxEditMonetaryBankAccountB.Text = ba.BankAccount;
                editwindow.TextBoxEditMonetaryValuteB.Text = ba.Valute;
                editwindow.TextBoxEditMonetaryAdditionalInfoB.Text = ba.OtherInfo;
                editwindow.ShowDialog();

                if (editwindow.DialogResult == true)
                {
                    if (editwindow.TextBoxEditMonetaryBankNameB.Text == "" ||
                        editwindow.TextBoxEditMonetaryBankAccountB.Text == "" ||
                        editwindow.TextBoxEditMonetaryValuteB.Text == "" ||
                        UiСontroller.StringCheker(editwindow.TextBoxEditMonetaryAmountB.Text) == "")
                    {
                        MessageBox.Show("Заполните поля со звездочками");
                        ExecuteEditMenu();
                    }
                    ba.Amount = editwindow.TextBoxEditMonetaryAmountB.Text;
                    ba.AssetName = editwindow.TextBoxEditMonetaryNameB.Text;
                    ba.BankName = editwindow.TextBoxEditMonetaryBankNameB.Text;
                    ba.Amount = editwindow.TextBoxEditMonetaryAmountB.Text;
                    ba.Valute = editwindow.TextBoxEditMonetaryValuteB.Text;
                    ba.OtherInfo = editwindow.TextBoxEditMonetaryValuteB.Text;
                    ListViewMain.Items.Refresh();
                }
            }

            if (a.Type == @"Имущественный")
            {
                var nm = (MaterialAsset) ListViewMain.SelectedItem;
                editwindow.CanvasMaterial.Visibility = Visibility.Visible;
                editwindow.TextBoxEditMeterialNameM.Text = nm.AssetName;
                editwindow.TextBoxEditMeterialInitialBalanceСostM.Text = nm.InitialBalanceCecost;
                editwindow.TextBoxEditMeterialEstimatedCostM.Text = nm.EstimatedCost;
                editwindow.TextBoxEditMeterialFinalBalanceCostM.Text = nm.FinalBalanceCost;
                editwindow.TextBoxEditMeterialAdditionalInfoM.Text = nm.OtherInfo;
                editwindow.ShowDialog();

                if (editwindow.DialogResult == true)
                {
                    if (
                        UiСontroller.StringCheker(editwindow.TextBoxEditMeterialInitialBalanceСostM.Text) == ""
                        || UiСontroller.StringCheker(editwindow.TextBoxEditMeterialEstimatedCostM.Text) == ""
                        || UiСontroller.StringCheker(editwindow.TextBoxEditMeterialFinalBalanceCostM.Text) == "")
                    {
                        MessageBox.Show("Заполните поля со звездочками");
                        ExecuteEditMenu();
                    }
                    nm.AssetName = editwindow.TextBoxEditMeterialNameM.Text;
                    nm.InitialBalanceCecost = editwindow.TextBoxEditMeterialInitialBalanceСostM.Text;
                    nm.FinalBalanceCost = editwindow.TextBoxEditMeterialEstimatedCostM.Text;
                    nm.EstimatedCost = editwindow.TextBoxEditMeterialFinalBalanceCostM.Text;
                    nm.OtherInfo = editwindow.TextBoxEditMeterialAdditionalInfoM.Text;
                    ListViewMain.Items.Refresh();
                }
            }

            if (a.Type == @"Недвижимость")
            {
                var em = (EstateMaterialAsset)ListViewMain.SelectedItem;
                editwindow.CanvasMaterialEstate.Visibility = Visibility.Visible;
                editwindow.TextBoxMeterialEstateNameE.Text = em.AssetName;
                editwindow.TextBoxMeterialInitialEstateBalanceСostE.Text = em.InitialBalanceCecost;
                editwindow.TextBoxMeterialEstimatedEstateCostE.Text = em.EstimatedCost;
                editwindow.TextBoxMeterialFinalEstateBalanceCostE.Text = em.FinalBalanceCost;
                editwindow.TextBoxMeterialEstateBuildingdateE.Text = em.BuildingDate;
                editwindow.TextBoxMeteriaEstatelAdressE.Text = em.Adress;
                editwindow.TextBoxMeterialEstateAdditionalInfoE.Text = em.OtherInfo;
                editwindow.ShowDialog();

                if (editwindow.DialogResult == true)
                {
                    if (
                        UiСontroller.StringCheker(editwindow.TextBoxEditMeterialInitialBalanceСostM.Text) == ""
                        || UiСontroller.StringCheker(editwindow.TextBoxEditMeterialEstimatedCostM.Text) == ""
                        || UiСontroller.StringCheker(editwindow.TextBoxEditMeterialFinalBalanceCostM.Text) == ""
                        )
                    {
                        MessageBox.Show("Заполните поля со звездочками");
                        ExecuteEditMenu();
                    }
                    
                        em.AssetName = editwindow.TextBoxMeterialEstateNameE.Text;
                    em.InitialBalanceCecost = editwindow.TextBoxMeterialInitialEstateBalanceСostE.Text;
                    em.FinalBalanceCost = editwindow.TextBoxMeterialFinalEstateBalanceCostE.Text;
                    em.EstimatedCost = editwindow.TextBoxMeterialEstimatedEstateCostE.Text;
                    em.OtherInfo = editwindow.TextBoxMeterialEstateAdditionalInfoE.Text;
                    em.Adress = editwindow.TextBoxMeteriaEstatelAdressE.Text;
                    em.BuildingDate = editwindow.TextBoxMeterialEstateBuildingdateE.Text;
                    ListViewMain.Items.Refresh();
                }
            }
        }

        private void DeleteAsset()
        {   
            
            var selected = ListViewMain.SelectedItems.Cast<Object>().ToArray();
            foreach (var item in selected) ListViewMain.Items.Remove(item);
            ListViewMain.UpdateLayout();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {   
            ExucuteAddMenu();
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteEditMenu();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
            //переделать обработчик и функцию. в курсе про многократное дублирование кода
        {
            var addwindow = new AddEditwindow {Owner = this};
            addwindow.ComboBox.SelectedIndex = 0;
            addwindow.ShowDialog();
            if (addwindow.DialogResult == false) return;

            if (addwindow.RadioButtonCashAsset.IsChecked == true)
            {   
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("MC"));
            }
            if (addwindow.RadioButtonBankAsset.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("MB"));
            }
            if (addwindow.RadioButtonMaterialAsset.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("NM"));
            }
            if (addwindow.RadioButtonEstate.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("EM"));
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
            //переделать обработчик и функцию. в курсе про многократное дублирование кода
        {
            var addwindow = new AddEditwindow {Owner = this};
            addwindow.ComboBox.SelectedIndex = 1;
            addwindow.ShowDialog();
            if (addwindow.DialogResult == false) return;

            if (addwindow.RadioButtonCashAsset.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("MC"));
            }
            if (addwindow.RadioButtonBankAsset.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("MB"));
            }
            if (addwindow.RadioButtonMaterialAsset.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("NM"));
            }
            if (addwindow.RadioButtonEstate.IsChecked == true)
            {
                ListViewMain.Items.Add(UiСontroller.AddAssetToListView("EM"));
            }

        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteAsset();
        }

        private void TbAssetType_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void ListViewMain_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = (Asset)ListViewMain.SelectedItem;
            if (a==null) return;
            if (a.Id == "K")
            {
                var ac = (CashAsset)ListViewMain.SelectedItem;
                CanvasInfoMaterial.Visibility = Visibility.Hidden;
                CanvasInfoMonetary.Visibility = Visibility.Visible;                
                TbAccetNameM.Text = ac.AssetName;
                TbAssetTypeM.Text = ac.Type;
                TbValuteM.Text = ac.Valute;
                TbAmountM.Text = ac.Amount.ToString(CultureInfo.InvariantCulture);
                TbAddInfoM.Text = ac.OtherInfo;
            }
            if (a.Id == "Б")
            {   
                var ab = (BankAsset)ListViewMain.SelectedItem;
                CanvasInfoMaterial.Visibility = Visibility.Hidden;
                CanvasInfoMonetary.Visibility = Visibility.Visible;                
                TbAccetNameM.Text = ab.AssetName;
                TbAssetTypeM.Text = ab.Type;
                TbValuteM.Text = ab.Valute;
                TbAmountM.Text = ab.Amount.ToString(CultureInfo.InvariantCulture);
                TbAddInfoM.Text = ab.OtherInfo;
                TbBankAccountM.Text = ab.BankAccount.ToString();
                TbBankNameM.Text = ab.BankName;
            }
            if (a.Id == "ИМ")
            {   
                
                var ae = (MaterialAsset) ListViewMain.SelectedItem;
                CanvasInfoMonetary.Visibility = Visibility.Hidden;
                CanvasInfoMaterial.Visibility = Visibility.Visible;                
                TbAccetNameE.Text = ae.AssetName;
                TbAssetTypeE.Text = ae.Type;
                TbInitCostE.Text = ae.InitialBalanceCecost.ToString();
                TbFCostE.Text = ae.FinalBalanceCost.ToString();
                TbECostE.Text = ae.EstimatedCost.ToString();
                TbAddInfoE.Text = ae.OtherInfo;
            }
            if (a.Id == "HM")
            {
                var am = (EstateMaterialAsset)ListViewMain.SelectedItem;
                CanvasInfoMonetary.Visibility = Visibility.Hidden;
                CanvasInfoMaterial.Visibility = Visibility.Visible;                
                TbAccetNameE.Text = am.AssetName;
                TbAssetTypeE.Text = am.Type;
                TbInitCostE.Text = am.InitialBalanceCecost.ToString();
                TbFCostE.Text = am.FinalBalanceCost.ToString();
                TbECostE.Text = am.EstimatedCost.ToString();
                TbAddInfoE.Text = am.OtherInfo;
                TbBuildDate.Text = am.BuildingDate;
                TbAdressE.Text = am.BuildingDate;
            }
        }

        private void ListViewMain_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CanvasInfoMonetary.Visibility = Visibility.Hidden;
            CanvasInfoMaterial.Visibility = Visibility.Hidden;

            TbAccetNameM.Text = "";
            TbAssetTypeM.Text = "";
            TbValuteM.Text = "";
            TbAmountM.Text = "";
            TbAddInfoM.Text = "";
            TbBankAccountM.Text = "";
            TbBankNameM.Text = "";

            TbAccetNameE.Text = "";
            TbAssetTypeM.Text = "";
            TbInitCostE.Text = "";
            TbFCostE.Text = "";
            TbECostE.Text = "";
            TbAddInfoE.Text = "";
            TbBuildDate.Text = "";
            TbAdressE.Text = "";
        }
    }
}
