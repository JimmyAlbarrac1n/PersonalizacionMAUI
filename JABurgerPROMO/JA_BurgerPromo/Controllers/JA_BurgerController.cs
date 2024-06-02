using JA_BurgerPromo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JA_BurgerPromo.Controllers
{
    public class JA_BurgerController : Controller
    {
        private readonly DataContext _context;

        public JA_BurgerController(DataContext context)
        {
            _context = context;
        }

        // GET: JA_Burger
        public async Task<IActionResult> Index()
        {
            return View(await _context.JA_Burger.ToListAsync());
        }

        // GET: JA_Burger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jA_Burger = await _context.JA_Burger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jA_Burger == null)
            {
                return NotFound();
            }

            return View(jA_Burger);
        }

        // GET: JA_Burger/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JA_Burger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,WithCheese,Precio")] JA_Burger jA_Burger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jA_Burger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jA_Burger);
        }

        // GET: JA_Burger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jA_Burger = await _context.JA_Burger.FindAsync(id);
            if (jA_Burger == null)
            {
                return NotFound();
            }
            return View(jA_Burger);
        }

        // POST: JA_Burger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio")] JA_Burger jA_Burger)
        {
            if (id != jA_Burger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jA_Burger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JA_BurgerExists(jA_Burger.Id))
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
            return View(jA_Burger);
        }

        // GET: JA_Burger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jA_Burger = await _context.JA_Burger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jA_Burger == null)
            {
                return NotFound();
            }

            return View(jA_Burger);
        }

        // POST: JA_Burger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jA_Burger = await _context.JA_Burger.FindAsync(id);
            if (jA_Burger != null)
            {
                _context.JA_Burger.Remove(jA_Burger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JA_BurgerExists(int id)
        {
            return _context.JA_Burger.Any(e => e.Id == id);
        }
    }
}
