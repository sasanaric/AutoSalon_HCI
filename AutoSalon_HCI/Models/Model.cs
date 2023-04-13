namespace AutoSalon_HCI.Models
{
    public class Model
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public decimal cijena { get; set; }
        public int proizvodjacId { get; set; }
    }
}