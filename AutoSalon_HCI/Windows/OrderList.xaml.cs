using System.Collections.Generic;
using System.Windows;
using AutoSalon_HCI.Database;
using AutoSalon_HCI.Models;

namespace AutoSalon_HCI.Windows
{
    public partial class OrderList : Window
    {
        public OrderList()
        {
            InitializeComponent();
            NarudzbeListView.ItemsSource = AutomobilDatabase.NarudzbaAutomobilGetAll();
        }
    }
}