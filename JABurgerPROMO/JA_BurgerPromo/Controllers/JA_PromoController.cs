using JA_BurgerPromo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JA_BurgerPromo.Controllers
{
    public class JA_PromoController : Controller
    {
        private readonly DataContext _context;

        public JA_PromoController(DataContext context)
        {
            _context = context;
        }

        // GET: JA_Promo
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.JA_Promo.Include(j => j.Burger);
            return View(await dataContext.ToListAsync());
        }

        // GET: JA_Promo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jA_Promo = await _context.JA_Promo
                .Include(j => j.Burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (jA_Promo == null)
            {
                return NotFound();
            }

            return View(jA_Promo);
        }

        // GET: JA_Promo/Create
        public IActionResult Create()
        {
            ViewData["BurgerID"] = new SelectList(_context.JA_Burger, "Id", "Name");
            return View();
        }

        // POST: JA_Promo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoID,Descripcion,FechaPromo,BurgerID")] JA_Promo jA_Promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jA_Promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurgerID"] = new SelectList(_context.JA_Burger, "Id", "Name", jA_Promo.BurgerID);
            return View(jA_Promo);
        }

        // GET: JA_Promo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jA_Promo = await _context.JA_Promo.FindAsync(id);
            if (jA_Promo == null)
            {
                return NotFound();
            }
            ViewData["BurgerID"] = new SelectList(_context.JA_Burger, "Id", "Name", jA_Promo.BurgerID);
            return View(jA_Promo);
        }

        // POST: JA_Promo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoID,Descripcion,FechaPromo,BurgerID")] JA_Promo jA_Promo)
        {
            if (id != jA_Promo.PromoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jA_Promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JA_PromoExists(jA_Promo.PromoID))
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
            ViewData["BurgerID"] = new SelectList(_context.JA_Burger, "Id", "Name", jA_Promo.BurgerID);
            return View(jA_Promo);
        }

        // GET: JA_Promo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jA_Promo = await _context.JA_Promo
                .Include(j => j.Burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (jA_Promo == null)
            {
                return NotFound();
            }

            return View(jA_Promo);
        }

        // POST: JA_Promo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jA_Promo = await _context.JA_Promo.FindAsync(id);
            if (jA_Promo != null)
            {
                _context.JA_Promo.Remove(jA_Promo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JA_PromoExists(int id)
        {
            return _context.JA_Promo.Any(e => e.PromoID == id);
        }
    }
}
