using System.Collections.Generic;
using System.Windows;
using AutoSalon_HCI.Database;
using AutoSalon_HCI.Models;
using AutoSalon_HCI.Pages;

namespace AutoSalon_HCI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!App.isAdmin)
            {
                KonfiguracijaButton.Visibility = Visibility.Hidden;
            }
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            Window orderWindow = new Order();
            orderWindow.Show();
        }

        private void OrderList(object sender, RoutedEventArgs e)
        {
            Window orderListWindow = new OrderList();
            orderListWindow.Show();
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            Window addCustomer = new AddCustomer();
            addCustomer.Show();
        }

        private void Configuration(object sender, RoutedEventArgs e)
        {
            Window configuration = new Configuration();
            configuration.Show();
        }
    }
}
