namespace AutoSalon_HCI.Models
{
    public class Kupac
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }

        public string ImePrezime => $"{ime} {prezime}";
    }
}