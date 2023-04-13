using System;
using System.Configuration;
using AutoSalon_HCI.Pages;
using MySql.Data.MySqlClient;

namespace AutoSalon_HCI.Database
{
    public class ProdavacDatabase
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MySqlAutoSalon"].ConnectionString;
        public static int CheckLogin(string username,string password)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id FROM prodavac WHERE username = @username AND password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader = cmd.ExecuteReader();
            object idObject = 0;
            int id = 0;
            if (reader.Read())
            {
                idObject = reader.GetInt32(0);
                id = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return (idObject.Equals(null)) ? 0 : id;
        }
        public static void GetUlogaById(int id)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT uloga FROM prodavac WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            string uloga = "";
            if (reader.Read())
            {
                uloga = reader.GetString(0);
            }
            reader.Close();
            conn.Close();
            App.isAdmin = uloga.Equals("ADMIN", StringComparison.OrdinalIgnoreCase);
        }
        public static void Insert(string ime,string prezime,string uloga,string username,string password)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `prodavac` (`ime`,`prezime`,`uloga`,`username`,`password`) VALUES (@ime,@prezime,@uloga,@username,@password)";
            cmd.Parameters.AddWithValue("@ime",ime);
            cmd.Parameters.AddWithValue("@prezime",prezime);
            cmd.Parameters.AddWithValue("@uloga",uloga);
            cmd.Parameters.AddWithValue("@username",username);
            cmd.Parameters.AddWithValue("@password",password);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}