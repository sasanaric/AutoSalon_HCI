using System;
using System.Collections.Generic;
using System.Configuration;
using AutoSalon_HCI.Models;
using AutoSalon_HCI.Pages;
using MySql.Data.MySqlClient;

namespace AutoSalon_HCI.Database
{
    public class AutomobilDatabase
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MySqlAutoSalon"].ConnectionString;
        public static void BojaInsert(string naziv)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `boja` (`naziv`) VALUES (@naziv)";
            cmd.Parameters.AddWithValue("@naziv",naziv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void ProizvodjacInsert(string naziv)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `proizvodjac` (`naziv`) VALUES (@naziv)";
            cmd.Parameters.AddWithValue("@naziv",naziv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void ModelInsert(string naziv,decimal cijena,int proizvodjacId)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `model` (`naziv`,`cijena`,`proizvodjac_id`) VALUES (@naziv,@cijena,@proizvodjac_id)";
            cmd.Parameters.AddWithValue("@naziv",naziv);
            cmd.Parameters.AddWithValue("@cijena",cijena);
            cmd.Parameters.AddWithValue("@proizvodjac_id",proizvodjacId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void AutomobilInsert(int modelId,int motorId,int bojaId,string oprema)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `automobil` (`model_id`,`motor_id`,`boja_id`,`oprema`) VALUES (@modelId,@motorId,@bojaId,@oprema)";
            cmd.Parameters.AddWithValue("@modelId",modelId);
            cmd.Parameters.AddWithValue("@motorId",motorId);
            cmd.Parameters.AddWithValue("@bojaId",bojaId);
            cmd.Parameters.AddWithValue("@oprema",oprema);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void NarudzbaInsert( int automobilId,int kupacId,int registracijaId,decimal cijena)
        {
            DateTime datumNarudzbe = DateTime.Now;
            Random random = new Random();
            int months = random.Next(4);
            DateTime datumIsporuke = datumNarudzbe.AddMonths(months);
            int prodavacId = App.prodavacId;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `narudzba` " + 
                              "(`datum_narudzbe`,`datum_isporuke`,`cijena`,`automobil_id`," +
                              "`prodavac_id`,`kupac_id`,`registracija_id`)" +
                              " VALUES (@datumNarudzbe,@datumIsporuke,@cijena,@automobilId," +
                              "@prodavacId,@kupacId,@registracijaId)";
            cmd.Parameters.AddWithValue("@datumNarudzbe",datumNarudzbe);
            cmd.Parameters.AddWithValue("@datumIsporuke",datumIsporuke);
            cmd.Parameters.AddWithValue("@cijena",cijena);
            cmd.Parameters.AddWithValue("@automobilId",automobilId);
            cmd.Parameters.AddWithValue("@prodavacId",prodavacId);
            cmd.Parameters.AddWithValue("@kupacId",kupacId);
            cmd.Parameters.AddWithValue("@registracijaId",registracijaId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Proizvodjac> ProizvodjacGetAll()
        {
            List<Proizvodjac> result = new List<Proizvodjac>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
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
        public static List<NarudzbaAutomobil> NarudzbaAutomobilGetAll()
        {
            List<NarudzbaAutomobil> result = new List<NarudzbaAutomobil>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `narudzba_automobil`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new NarudzbaAutomobil()
                {
                    datumNarudzbe = reader.GetDateTime(0),
                    datumIsporuke = reader.GetDateTime(1),
                    proizvodjac = reader.GetString(2),
                    model = reader.GetString(3),
                    tipMotora = reader.GetString(4),
                    oprema = reader.GetString(5),
                    boja = reader.GetString(6),
                    cijena = reader.GetDecimal(7),
                    prodavac = reader.GetString(8),
                    kupac = reader.GetString(9),
                    registracijskaOznaka = reader.GetString(10)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }
        public static List<Motor> MotorGetAll()
        {
            List<Motor> result = new List<Motor>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `motor`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Motor()
                {
                    id = reader.GetInt32(0),
                    tip = reader.GetString(1)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }
        public static List<Boja> BojaGetAll()
        {
            List<Boja> result = new List<Boja>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `boja`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Boja()
                {
                    id = reader.GetInt32(0),
                    naziv = reader.GetString(1)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static List<Model> ModelGetByProizvodjacId(int proizvodjacId)
        {
            List<Model> result = new List<Model>();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `model` WHERE proizvodjac_id=@proizvodjacId";
            cmd.Parameters.AddWithValue("@proizvodjacId", proizvodjacId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Model()
                {
                    id = reader.GetInt32(0),
                    naziv = reader.GetString(1),
                    cijena = reader.GetDecimal(2),
                    proizvodjacId = reader.GetInt32(3)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }
        public static Model ModelGetById(int modelId)
        {
            Model result = new Model();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `model` WHERE id=@modelId";
            cmd.Parameters.AddWithValue("@modelId", modelId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result = new Model()
                {
                    id = reader.GetInt32(0),
                    naziv = reader.GetString(1),
                    cijena = reader.GetDecimal(2),
                    proizvodjacId = reader.GetInt32(3)
                };
            }
            reader.Close();
            conn.Close();
            return result;
        }
        public static int AutomobilGetLastId()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT MAX(id) FROM automobil";
            MySqlDataReader reader = cmd.ExecuteReader();
            int maxId = 0;
            if (reader.Read())
            {
                maxId = reader.GetInt32(0);
            }
            reader.Close();
            return maxId;
        }
        public static int RegistracijaGetLastId()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT MAX(id) FROM registracija";
            MySqlDataReader reader = cmd.ExecuteReader();
            int maxId = 0;
            if (reader.Read())
            {
                maxId = reader.GetInt32(0);
            }
            reader.Close();
            return maxId;
        }
        public static void RegistracijaInsert()
        {
            int count = RegistracijaGetLastId() + 1;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            string oznaka = "REGISTRACIJA" + count;
            cmd.CommandText = "INSERT INTO `registracija` (`oznaka`) VALUES (@oznaka)";
            cmd.Parameters.AddWithValue("@oznaka", oznaka);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}