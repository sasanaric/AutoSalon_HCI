using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using AutoSalon_HCI.Database;

namespace AutoSalon_HCI.Models
{
    public class Proizvodjac
    {
        public int id { get; set; }
        public string naziv { get; set; }
        
    }
}