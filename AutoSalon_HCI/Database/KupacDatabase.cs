using System.Collections.Generic;
using System.Configuration;
using AutoSalon_HCI.Models;
using MySql.Data.MySqlClient;

namespace AutoSalon_HCI.Database
{
    public class KupacDatabase
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MySqlAutoSalon"].ConnectionString;
        public static void Insert(string ime,string prezime,string telefon)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `kupac` (`ime`,`prezime`,`telefon`) VALUES (@ime,@prezime,@telefon)";
            cmd.Parameters.AddWithValue("@ime",ime);
            cmd.Parameters.AddWithValue("@prezime",prezime);
            cmd.Parameters.AddWithValue("@telefon",telefon);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Kupac> GetAll()
        {
            List<Kupac> result = new List<Kupac>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `kupac`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Kupac()
                {
                    id = reader.GetInt32(0),
                    ime = reader.GetString(1),
                    prezime = reader.GetString(2),
                    telefon = reader.GetString(3)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }
    }
}