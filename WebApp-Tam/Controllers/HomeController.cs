using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp_Tam.Data;
using WebApp_Tam.Models;
using WebApp_Tam.ViewModel; //(3) class ekleyip 

namespace WebApp_Tam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _vt; //(1) ekledik          

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _vt = context; //(2) ekledik
        }

        public IActionResult Index()
        {
            //https://www.youtube.com/watch?v=zs27PoITpiI
            var cokTablo = new CokTablo();        //artık tüm tablolara erişebiliriz     
            cokTablo.Urunler = _vt.Urun.OrderByDescending(x => x.GuncellenmeTarihi).ToList().Take(3);
            cokTablo.Kampanyalar = _vt.Kampanya.Where(x => x.Aktif == true).OrderByDescending(x => x.EklenmeTarihi).ToList();

            ViewData["mesajUyari"] = "İletişim için mesaj formunu doldurabilirsiniz.";

            return View(cokTablo);
        }

        public async Task<IActionResult> Ara(string? arama)
        {
            ViewData["arama"] = arama;
            var icerik = _vt.Urun.Where(x => x.UrunAdi.Contains(arama) || x.Detay.Contains(arama));
            return View(await icerik.ToListAsync());
        }

        public IActionResult Yonetim()
        {
            //sadece yönetim için gereken linkler var
            var icerik = _vt.Mesaj.Where(x => x.okunduMu != true).ToList();
            return View(icerik);
        }

        public IActionResult MesajYolla()
        {
            if (Request.Form["mesaj"] != "" && Request.Form["email"] != "" && Request.Form["onay"] != "")
            {
                Mesaj mesaj = new Mesaj();
                mesaj.yollayanMaili = Request.Form["email"];
                mesaj.Mesaji = Request.Form["mesaj"];
                mesaj.yollanmaTarihi = DateTime.Now;
                mesaj.okunduMu = false;

                _vt.Mesaj.Add(mesaj);
                _vt.SaveChanges();

                ViewData["mesajUyari"] = "Mesajınız yollandı.";
            }
            else
                ViewData["mesajUyari"] = "İletişim formunda eksikler vardır, tekrar doldurunuz.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}