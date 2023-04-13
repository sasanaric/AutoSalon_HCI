using System.Collections.Generic;
using System.Windows;
using AutoSalon_HCI.Database;
using AutoSalon_HCI.Models;

namespace AutoSalon_HCI.Windows
{
    public partial class Order : Window
    {
        private List<Proizvodjac> proizvodjaci;
        private List<Model> modeli;
        private List<Motor> motori;
        private List<Boja> boje;
        private List<Kupac> kupci;
        private int selectedProizvodjacId;
        private int selectedModelId;
        private int selectedMotorId;
        private int selectedBojaId;
        private int selectedKupacId;
        Model selectedModel = new Model();
        public Order()
        {
            InitializeComponent();
            proizvodjaci = AutomobilDatabase.ProizvodjacGetAll();
            motori = AutomobilDatabase.MotorGetAll();
            boje = AutomobilDatabase.BojaGetAll();
            kupci = KupacDatabase.GetAll();
            ProizvodjaciComboBox.ItemsSource = proizvodjaci;
            MotoriComboBox.ItemsSource = motori;
            BojeComboBox.ItemsSource = boje;
            KupciComboBox.ItemsSource = kupci;
        }

        private void SetProizvodjac(object sender, RoutedEventArgs e)
        {
            selectedProizvodjacId = (int)ProizvodjaciComboBox.SelectedValue;
            modeli = AutomobilDatabase.ModelGetByProizvodjacId(selectedProizvodjacId);
            ModeliComboBox.ItemsSource = modeli;
        }
        private void SetModel(object sender, RoutedEventArgs e)
        {
            selectedModelId = (int)ModeliComboBox.SelectedValue;
            selectedModel = AutomobilDatabase.ModelGetById(selectedModelId);
            CijenaTextBox.Text = selectedModel.cijena.ToString();
        }
        private void SetMotor(object sender, RoutedEventArgs e)
        {
            selectedMotorId = (int)MotoriComboBox.SelectedValue;
        }
        private void SetBoja(object sender, RoutedEventArgs e)
        {
            selectedBojaId = (int)BojeComboBox.SelectedValue;
        }
        private void SetKupac(object sender, RoutedEventArgs e)
        {
            selectedKupacId = (int)KupciComboBox.SelectedValue;
        }

        private void NaruciButton(object sender, RoutedEventArgs e)
        {
            if (!checkValues())
            {
                MessageBox.Show("Potrebno je popuniti sva polja!");
            }
            else
            {
                AutomobilDatabase.AutomobilInsert(selectedModelId,selectedMotorId,selectedBojaId,OpremaTextBox.Text);
                AutomobilDatabase.RegistracijaInsert();
                int automobilId = AutomobilDatabase.AutomobilGetLastId();
                int registracijaId = AutomobilDatabase.RegistracijaGetLastId();
                decimal cijena = decimal.Parse(CijenaTextBox.Text);
                AutomobilDatabase.NarudzbaInsert(automobilId,selectedKupacId,registracijaId,cijena);
                MessageBox.Show("Automobil je narucen.");
            }
        }

        private bool checkValues()
        {
            if (selectedProizvodjacId == 0) return false;
            if (selectedModelId == 0) return false;
            if (selectedMotorId == 0) return false;
            if (selectedBojaId == 0) return false;
            if (OpremaTextBox.Text == "") return false;
            if (selectedKupacId == 0) return false;
            return true;
        }
    }
}