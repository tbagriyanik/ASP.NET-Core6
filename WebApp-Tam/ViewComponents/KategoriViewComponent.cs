using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Tam.Data;
using System.Threading.Tasks;

namespace WebApp_Tam.ViewComponents
{
    public class KategoriViewComponent : ViewComponent
    {
        //https://www.youtube.com/watch?v=djDPIpI-J4w
        
        private readonly ApplicationDbContext _vt;

        public KategoriViewComponent(ApplicationDbContext vt)
        {
            _vt = vt;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await _vt.Kategori.ToListAsync();
            return View(item);
        }
    }
}
