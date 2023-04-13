using System.Collections.Generic;
using System.Configuration;
using AutoSalon_HCI.Models;
using MySql.Data.MySqlClient;

namespace AutoSalon_HCI.Database
{
    public class ProizvodjacDatabase
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MySqlAutoSalon"].ConnectionString;
        
    }
}