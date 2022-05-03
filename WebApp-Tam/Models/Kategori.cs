using System.ComponentModel.DataAnnotations;

namespace WebApp_Tam.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        public string? KategoriAdi { get; set; }

    }
}
