using System.Windows;
using AutoSalon_HCI.Database;

namespace AutoSalon_HCI.Windows
{
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void DodajKupca(object sender, RoutedEventArgs e)
        {
            string ime = ImeTextBox.Text;
            string prezime = PrezimeTextBox.Text;
            string telefon = TelefonTextBox.Text;
            if ("".Equals(ime) || "".Equals(prezime) || "".Equals(telefon))
            {
                MessageBox.Show("Potrebno je popuniti sva polja");
            }
            else
            {
                KupacDatabase.Insert(ime,prezime,telefon);
                Close();
            }
        }
    }
}