using System.Windows;


namespace RITFinance
{
    /// <summary>
    /// Логика взаимодействия для AddEditwindow.xaml
    /// </summary>
    public partial class AddEditwindow : Window
    {
        private UiСontroller _controller;

        public AddEditwindow()
        {
            InitializeComponent();
            _controller = new UiСontroller();   
                    
        }

        private void SelectedComboMonetary_OnSelected(object sender, RoutedEventArgs e)
        {
            RadioButtonMaterialAsset.Visibility = Visibility.Hidden;
            RadioButtonBankAsset.Visibility = Visibility.Visible;
            RadioButtonCashAsset.Visibility = Visibility.Visible;
            RadioButtonEstate.Visibility = Visibility.Hidden;
        }

        private void SelectedComboMaterial_OnSelected(object sender, RoutedEventArgs e)
        {          
            RadioButtonBankAsset.Visibility = Visibility.Hidden;
            RadioButtonMaterialAsset.Visibility = Visibility.Visible;
            RadioButtonCashAsset.Visibility = Visibility.Hidden;
            RadioButtonEstate.Visibility = Visibility.Visible;
        }

        private void RdioButtonBankAsset_OnChecked(object sender, RoutedEventArgs e)
        {
            CanvasBank.Visibility = Visibility.Visible;
            CanvasCash.Visibility = Visibility.Hidden;
            CanvasMaterial.Visibility = Visibility.Hidden;
            CanvasMaterialEstate.Visibility = Visibility.Hidden;
        }

        private void RadioButtonCashAsset_OnChecked(object sender, RoutedEventArgs e)
        {
            CanvasCash.Visibility = Visibility.Visible;
            CanvasBank.Visibility = Visibility.Hidden;
            CanvasMaterial.Visibility = Visibility.Hidden;
            CanvasMaterialEstate.Visibility = Visibility.Hidden;
        }

        private void RadioButtonMaterialAsset_OnChecked(object sender, RoutedEventArgs e)
        {
            CanvasCash.Visibility = Visibility.Hidden;
            CanvasBank.Visibility = Visibility.Hidden;
            CanvasMaterial.Visibility = Visibility.Visible;
            CanvasMaterialEstate.Visibility = Visibility.Hidden;
        }

        private void RadioButtonEstate_OnChecked(object sender, RoutedEventArgs e)
        {
            CanvasCash.Visibility = Visibility.Hidden;
            CanvasBank.Visibility = Visibility.Hidden;
            CanvasMaterial.Visibility = Visibility.Hidden;
            CanvasMaterialEstate.Visibility = Visibility.Visible;
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            while (!AddAssert())
            {   
                return;
            }
            DialogResult = true;
            this.Close(); ;            
        }

        private bool AddAssert()
        {   
            if (RadioButtonCashAsset.IsChecked == true)
            {     
                _controller.CreateCashAsset(TextBoxNameC.Text, UiСontroller.StringCheker(TextBoxAmountC.Text), TextBoxValuteC.Text, TextBoxAdditionalInfoC.Text);
                if (TextBoxAmountC.Text == "" || TextBoxValuteC.Text == "")
                {
                    MessageBox.Show("Заполните поля со звездочками!");
                    return false;
                }
                return true;
            }
            if (RadioButtonBankAsset.IsChecked == true)
            {
                if (UiСontroller.StringCheker(TextBoxMonetaryAmountB.Text) == "" || TextBoxMonetaryValuteB.Text == "" ||
                    TextBoxMonetaryBankAccountB.Text == "" || TextBoxMonetaryBankNameB.Text == "")
                {
                    MessageBox.Show("Заполните поля со звездочками!");
                    return false;
                }
                _controller.CreateBankAsset(TextBoxMonetaryNameB.Text,
                    UiСontroller.StringCheker(TextBoxMonetaryAmountB.Text), TextBoxMonetaryValuteB.Text,
                    TextBoxMonetaryBankAccountB.Text, TextBoxMonetaryBankNameB.Text, TextBoxMonetaryAdditionalInfoB.Text);
                return true;
            }
            if (RadioButtonMaterialAsset.IsChecked == true)
            {
                if (UiСontroller.StringCheker(TextBoxMeterialInitialBalanceСostM.Text) == "" ||
                    UiСontroller.StringCheker(TextBoxMeterialFinalBalanceCostM.Text) == "" ||
                    UiСontroller.StringCheker(TextBoxMeterialEstimatedCostM.Text) == "")
                {
                    MessageBox.Show("Заполните поля со звездочками!");
                    return false;
                }
                _controller.CreateMaterialAsset(TextBoxMeterialNameM.Text, TextBoxMonetaryAdditionalInfoB.Text,
                    TextBoxMeterialInitialBalanceСostM.Text,
                    TextBoxMeterialFinalBalanceCostM.Text, TextBoxMeterialEstimatedCostM.Text);
                return true;
            }
            if (RadioButtonEstate.IsChecked == true)
            {
                if (UiСontroller.StringCheker(TextBoxMeterialInitialEstateBalanceСostE.Text) == "" ||
                    UiСontroller.StringCheker(TextBoxMeterialEstimatedEstateCostE.Text) == "" ||
                    UiСontroller.StringCheker(TextBoxMeterialFinalEstateBalanceCostE.Text) == "")
                {
                    MessageBox.Show("Заполните поля со звездочками!");
                    return false;
                }
                _controller.CreateMaterialEstaeteAsset(TextBoxMeterialEstateNameE.Text,
                    TextBoxMeterialEstateAdditionalInfoE.Text, TextBoxMeterialInitialEstateBalanceСostE.Text,
                    TextBoxMeterialFinalEstateBalanceCostE.Text, TextBoxMeterialEstimatedEstateCostE.Text,
                    TextBoxMeterialEstateBuildingdateE.Text, TextBoxMeteriaEstatelAdressE.Text);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CencelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
