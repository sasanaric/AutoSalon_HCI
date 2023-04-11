using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace AutoSalon_HCI.Database
{
    public class ProdavacDatabase
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MySqlAutoSalon"].ConnectionString;
        public static Boolean CheckLogin(string username,string password)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM prodavac WHERE username = @username AND password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            if (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return count > 0;
        }
    }
}