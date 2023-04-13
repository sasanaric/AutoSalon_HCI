using System;
using System.Windows.Controls;

namespace AutoSalon_HCI.Models
{
    public class NarudzbaAutomobil
    {
        public DateTime datumNarudzbe { get; set; }
        public DateTime datumIsporuke { get; set; }
        public string proizvodjac { get; set; }
        public string model { get; set; }
        public string tipMotora { get; set; }
        public string oprema { get; set; }
        public string boja { get; set; }
        public decimal cijena { get; set; }
        public string prodavac { get; set; }
        public string kupac { get; set; }
        public string registracijskaOznaka { get; set; }
    }
}