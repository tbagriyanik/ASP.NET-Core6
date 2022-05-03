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
    [Authorize(Roles="admin")]
    public class MesajlarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MesajlarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mesajlar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mesaj.ToListAsync());
        }

        // GET: Mesajlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesaj
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mesaj == null)
            {
                return NotFound();
            }

            return View(mesaj);
        }

        // GET: Mesajlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesajlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,yollayanMaili,Mesaji,yollanmaTarihi,okunduMu")] Mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesaj);
        }

        // GET: Mesajlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesaj.FindAsync(id);
            if (mesaj == null)
            {
                return NotFound();
            }
            return View(mesaj);
        }

        // POST: Mesajlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,yollayanMaili,Mesaji,yollanmaTarihi,okunduMu")] Mesaj mesaj)
        {
            if (id != mesaj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesajExists(mesaj.Id))
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
            return View(mesaj);
        }

        // GET: Mesajlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesaj
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mesaj == null)
            {
                return NotFound();
            }

            return View(mesaj);
        }

        // POST: Mesajlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesaj = await _context.Mesaj.FindAsync(id);
            _context.Mesaj.Remove(mesaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesajExists(int id)
        {
            return _context.Mesaj.Any(e => e.Id == id);
        }
    }
}
