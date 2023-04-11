using System;
using System.Linq;
using System.Windows;
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
            string password = PasswordBox.Password;
            if (ProdavacDatabase.CheckLogin(username, password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }
}