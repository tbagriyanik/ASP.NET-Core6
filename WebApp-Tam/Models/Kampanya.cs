using System.ComponentModel.DataAnnotations;

namespace WebApp_Tam.Models
{
    public class Kampanya
    {
        [Key]
        public int Id { get; set; }
        public string? KampanyaAdi { get; set; }
        public string? Resmi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
