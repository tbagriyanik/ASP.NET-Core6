using System.ComponentModel.DataAnnotations;

namespace WebApp_Tam.Models
{
    public class Mesaj
    {
        [Key]
        public int Id { get; set; }
        public string? yollayanMaili { get; set; }
        public string? Mesaji { get; set; }
        public DateTime yollanmaTarihi { get; set; }
        public bool okunduMu { get; set; }
    }
}
