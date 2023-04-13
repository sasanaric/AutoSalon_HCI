
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoSalon_HCI.Database;
using AutoSalon_HCI.Models;
using AutoSalon_HCI.Pages;

namespace AutoSalon_HCI.Windows
{
    public partial class Configuration
    {
        private List<Proizvodjac> proizvodjaci;
        private List<string> uloge = new List<string>{"USER","ADMIN"};
        private int selectedProizvodjacId;
        private string uloga;
        public Configuration()
        {
            InitializeComponent();
            proizvodjaci = AutomobilDatabase.ProizvodjacGetAll();
            ProizvodjaciComboBox.ItemsSource = proizvodjaci;
            UlogeComboBox.ItemsSource = uloge;
        }

        private void SetProizvodjac(object sender, RoutedEventArgs e)
        {
            selectedProizvodjacId = (int)ProizvodjaciComboBox.SelectedValue;
        }

        private void AddModel(object sender, RoutedEventArgs e)
        {
            try
            {
                string naziv = ModelTextBox.Text;
                decimal cijena = decimal.Parse(CijenaTextBox.Text);
                int proizvodjacId = selectedProizvodjacId;
                if("".Equals(naziv)||"".Equals(CijenaTextBox.Text)||proizvodjacId.Equals(null))
                {
                    MessageBox.Show("Popunite sva polja");
                }
                else
                {
                    AutomobilDatabase.ModelInsert(naziv,cijena,proizvodjacId);
                    MessageBox.Show($"Novi model: {naziv}");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cijena nije korektna!");
            }
        }

        private void AddProizvodjac(object sender, RoutedEventArgs e)
        {
            string naziv = ProizvodjacTextBox.Text;
            if ("".Equals(naziv))
            {
                MessageBox.Show("Unesite naziv proizvodjaca");
            }
            else
            {
                AutomobilDatabase.ProizvodjacInsert(naziv);
                MessageBox.Show($"Novi proizvodjac: {naziv}");
            }
        }

        private void AddBoja(object sender, RoutedEventArgs e)
        {
            string naziv = BojaTextBox.Text;
            if ("".Equals(naziv))
            {
                MessageBox.Show("Unesite naziv boje");
            }
            else
            {
                AutomobilDatabase.BojaInsert(naziv);
                MessageBox.Show($"Nova boja: {naziv}");
            }
        }
        private void AddProdavac(object sender, RoutedEventArgs e)
        {
            try
            {
                string ime = ImeTextBox.Text;
                string prezime = PrezimeTextBox.Text;
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                
                if("".Equals(ime)||"".Equals(prezime)||"".Equals(uloga)||"".Equals(username)||"".Equals(password))
                {
                    MessageBox.Show("Popunite sva polja");
                }
                else
                {
                    ProdavacDatabase.Insert(ime,prezime,uloga,username,password);
                    MessageBox.Show($"Novi prodavac: {ime} {prezime}");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cijena nije korektna!");
            }
        }

        private void SetUloga(object sender, SelectionChangedEventArgs e)
        {
            uloga = UlogeComboBox.SelectedItem.ToString();
        }
    }
}