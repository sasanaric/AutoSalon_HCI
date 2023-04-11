using System.Collections.Generic;
using System.Configuration;
using AutoSalon_HCI.Models;
using MySql.Data.MySqlClient;

namespace AutoSalon_HCI.Database
{
    public class ProizvodjacDatabase
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlAutoSalon"].ConnectionString;
        public static List<Proizvodjac> GetAll()
        {
            List<Proizvodjac> result = new List<Proizvodjac>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `proizvodjac`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Proizvodjac()
                {
                    id = reader.GetInt32(0),
                    naziv = reader.GetString(1)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }
    }
}