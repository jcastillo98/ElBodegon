using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElBodegon.Data;
using ElBodegon.Models;

namespace ElBodegon.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Menu
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuViewModel.ToListAsync());
        }

        // GET: Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuViewModel = await _context.MenuViewModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (menuViewModel == null)
            {
                return NotFound();
            }

            return View(menuViewModel);
        }

        // GET: Menu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NombreP,Precio,Tipo,Imagen")] MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }

        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuViewModel = await _context.MenuViewModel.FindAsync(id);
            if (menuViewModel == null)
            {
                return NotFound();
            }
            return View(menuViewModel);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NombreP,Precio,Tipo,Imagen")] MenuViewModel menuViewModel)
        {
            if (id != menuViewModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuViewModelExists(menuViewModel.id))
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
            return View(menuViewModel);
        }

        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuViewModel = await _context.MenuViewModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (menuViewModel == null)
            {
                return NotFound();
            }

            return View(menuViewModel);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuViewModel = await _context.MenuViewModel.FindAsync(id);
            _context.MenuViewModel.Remove(menuViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuViewModelExists(int id)
        {
            return _context.MenuViewModel.Any(e => e.id == id);
        }
    }
}
