﻿#nullable disable
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
    public class UrunlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UrunlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Urunler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Urun.Include(u => u.Kategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Urunler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _context.Urun
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        [Authorize(Roles="admin")]
        // GET: Urunler/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdi");
            return View();
        }

        // POST: Urunler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles="admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunAdi,Resmi,Detay,Fiyat,GuncellenmeTarihi,KategoriId")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

        [Authorize(Roles="admin")]
        // GET: Urunler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _context.Urun.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

        // POST: Urunler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles="admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunAdi,Resmi,Detay,Fiyat,GuncellenmeTarihi,KategoriId")] Urun urun)
        {
            if (id != urun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunExists(urun.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

        [Authorize(Roles="admin")]
        // GET: Urunler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _context.Urun
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        [Authorize(Roles="admin")]
        // POST: Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urun = await _context.Urun.FindAsync(id);
            _context.Urun.Remove(urun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunExists(int id)
        {
            return _context.Urun.Any(e => e.Id == id);
        }
    }
}
