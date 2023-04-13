using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using AutoSalon_HCI.Database;
using AutoSalon_HCI.Pages;

namespace AutoSalon_HCI.Windows
{
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordPasswordBox.Password;
            App.prodavacId = ProdavacDatabase.CheckLogin(username, password);
            if (App.prodavacId!=0)
            {
                ProdavacDatabase.GetUlogaById(App.prodavacId);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Pogresni podaci");
            }
        }
    }
}