using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp79
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            cmbLocation.Items.Add("Kuznetsk (Penza Oblast)");
            cmbLocation.Items.Add("Penza (Penza Oblast)");
            cmbLocation.Items.Add("Other cities (Penza Oblast)");
            cmbLocation.Items.Add("Syzran (Samara Oblast)");
            cmbLocation.Items.Add("Samara (Samara Oblast)");
            cmbLocation.Items.Add("Tolyatti (Samara Oblast)");
            cmbLocation.Items.Add("Other cities (Samara Oblast)");
            cmbLocation.Items.Add("Ulyanovsk (Ulyanovsk Oblast)");
            cmbLocation.Items.Add("Dimitrovgrad (Ulyanovsk Oblast)");
            cmbLocation.Items.Add("Other cities (Ulyanovsk Oblast)");

            cmbVehicleCategory.Items.Add("Motorcycles, mopeds (Category A)");
            cmbVehicleCategory.Items.Add("Passenger cars");
            cmbVehicleCategory.Items.Add("Trucks");
        }
        private void CalculateInsurance(object sender, RoutedEventArgs e)
        {
            int yearOfBirth = int.Parse(txtYearOfBirth.Text);
            int yearOfLicense = int.Parse(txtYearOfLicense.Text);
            string location = (string)cmbLocation.SelectedItem;
            string vehicleCategory = (string)cmbVehicleCategory.SelectedItem;

            double territoryCoefficient = GetTerritoryCoefficient(location);
            double ageAndExperienceCoefficient = GetAgeAndExperienceCoefficient(yearOfBirth, yearOfLicense);
            double bonusCoefficient = GetBonusCoefficient(yearOfLicense);
            double powerCoefficient = GetPowerCoefficient(vehicleCategory);

            double basePremium = GetBasePremium(vehicleCategory);
            double totalInsuranceCost = basePremium * territoryCoefficient * ageAndExperienceCoefficient * bonusCoefficient * powerCoefficient;

            lblTerritoryCoefficient.Text = $"Territory Coefficient: {territoryCoefficient}";
            lblAgeAndExperienceCoefficient.Text = $"Age and Experience Coefficient: {ageAndExperienceCoefficient}";
            lblBonusCoefficient.Text = $"Bonus Coefficient: {bonusCoefficient}";
            lblPowerCoefficient.Text = $"Power Coefficient: {powerCoefficient}";
            lblTotalInsuranceCost.Text = $"Total Insurance Cost: {totalInsuranceCost:C}";
        }

        private double GetTerritoryCoefficient(string location)
        {
            switch (location)
            {
                case "Kuznetsk (Penza Oblast)":
                    return 1.0;
                case "Penza (Penza Oblast)":
                    return 1.4;
                case "Other cities (Penza Oblast)":
                    return 0.7;
                case "Syzran (Samara Oblast)":
                    return 1.1;
                case "Samara (Samara Oblast)":
                    return 1.6;
                case "Tolyatti (Samara Oblast)":
                    return 1.5;
                case "Other cities (Samara Oblast)":
                    return 0.9;
                case "Ulyanovsk (Ulyanovsk Oblast)":
                    return 1.4;
                case "Dimitrovgrad (Ulyanovsk Oblast)":
                    return 1.1;
                case "Other cities (Ulyanovsk Oblast)":
                    return 0.8;
                default:
                    return 1.0;
            }
        }

        private double GetAgeAndExperienceCoefficient(int yearOfBirth, int yearOfLicense)
        {
            int age = DateTime.Now.Year - yearOfBirth;
            int experience = DateTime.Now.Year - yearOfLicense;

            if (age <= 22 && experience <= 3)
            {
                return 1.8;
            }
            else if (age <= 22 && experience > 3)
            {
                return 1.6;
            }
            else if (age > 22 && experience <= 3)
            {
                return 1.7;
            }
            else
            {
                return 1.0;
            }
        }

        private double GetBonusCoefficient(int yearOfLicense)
        {
            int experience = DateTime.Now.Year - yearOfLicense;
            if (experience == 0)
            {
                return 3.92;
            }
            else
            {
                return 3.92 - (0.173 * experience);
            }
        }

        private double GetPowerCoefficient(string vehicleCategory)
        {
            switch (vehicleCategory)
            {
                case "Motorcycles, mopeds (Category A)":
                    return 0.6;
                case "Passenger cars":
                    return 1.1;
                case "Trucks": return 1.2;
                default:
                    return 1.0;
            }
        }

        private double GetBasePremium(string vehicleCategory)
        {
            switch (vehicleCategory)
            {
                case "Motorcycles, mopeds (Category A)":
                    return 1215;
                case "Passenger cars":
                    return 1980;
                case "Trucks":
                    return 2025;
                default:
                    return 1980;
            }
        }
    }
}