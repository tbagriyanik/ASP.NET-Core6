using WebApp_Tam.Models;

namespace WebApp_Tam.ViewModel
{
    public class CokTablo
    {
        public IEnumerable<Kategori> Kategoriler { get; set; }
        public IEnumerable<Urun> Urunler { get; set; }
        public IEnumerable<Kampanya> Kampanyalar { get; set; }
    }
}
