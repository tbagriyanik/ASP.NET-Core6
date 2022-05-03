using System.ComponentModel.DataAnnotations;

namespace WebApp_Tam.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        public string? UrunAdi { get; set; }
        public string? Resmi { get; set; }
        public string? Detay { get; set; }
        public float Fiyat { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }

        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }

    }
}
