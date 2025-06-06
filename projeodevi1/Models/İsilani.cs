namespace projeodevi1.Models
{
    public class İsilani
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;

        public int EkleyenId { get; set; }
        public Kullanici Ekleyen { get; set; }
    }
}
