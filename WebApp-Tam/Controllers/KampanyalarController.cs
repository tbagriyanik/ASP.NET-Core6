#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_Tam.Data;
using WebApp_Tam.Models;

namespace WebApp_Tam.Controllers
{
    
    public class KampanyalarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KampanyalarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kampanyalar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kampanya.ToListAsync());
        }

        // GET: Kampanyalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kampanya = await _context.Kampanya
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kampanya == null)
            {
                return NotFound();
            }

            return View(kampanya);
        }

        [Authorize(Roles="admin")]
        // GET: Kampanyalar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kampanyalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles="admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KampanyaAdi,Resmi,EklenmeTarihi,Aktif")] Kampanya kampanya)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kampanya);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kampanya);
        }

        [Authorize(Roles="admin")]
        // GET: Kampanyalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kampanya = await _context.Kampanya.FindAsync(id);
            if (kampanya == null)
            {
                return NotFound();
            }
            return View(kampanya);
        }

        // POST: Kampanyalar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles="admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KampanyaAdi,Resmi,EklenmeTarihi,Aktif")] Kampanya kampanya)
        {
            if (id != kampanya.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kampanya);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KampanyaExists(kampanya.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kampanya);
        }

        [Authorize(Roles="admin")]
        // GET: Kampanyalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kampanya = await _context.Kampanya
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kampanya == null)
            {
                return NotFound();
            }

            return View(kampanya);
        }

        // POST: Kampanyalar/Delete/5

        [Authorize(Roles="admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kampanya = await _context.Kampanya.FindAsync(id);
            _context.Kampanya.Remove(kampanya);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KampanyaExists(int id)
        {
            return _context.Kampanya.Any(e => e.Id == id);
        }
    }
}
