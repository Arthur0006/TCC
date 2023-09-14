using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class MecanicaFotosController : Controller
    {
        private readonly ProjetoMVCContext _context;

        public MecanicaFotosController(ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: MecanicaFotos
        public async Task<IActionResult> Index()
        {
            var projetoMVCContext = _context.MecanicaFotosModel.Include(m => m.Mecanica);
            return View(await projetoMVCContext.ToListAsync());
        }

        // GET: MecanicaFotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MecanicaFotosModel == null)
            {
                return NotFound();
            }

            var mecanicaFotosModel = await _context.MecanicaFotosModel
                .Include(m => m.Mecanica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicaFotosModel == null)
            {
                return NotFound();
            }

            return View(mecanicaFotosModel);
        }

        // GET: MecanicaFotos/Create
        public IActionResult Create()
        {
            ViewData["MecanicaId"] = new SelectList(_context.MecanicaModel, "Id", "Id");
            return View();
        }

        // POST: MecanicaFotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Arquivo,Padrao,MecanicaId")] MecanicaFotosModel mecanicaFotosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mecanicaFotosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MecanicaId"] = new SelectList(_context.MecanicaModel, "Id", "Id", mecanicaFotosModel.MecanicaId);
            return View(mecanicaFotosModel);
        }

        // GET: MecanicaFotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MecanicaFotosModel == null)
            {
                return NotFound();
            }

            var mecanicaFotosModel = await _context.MecanicaFotosModel.FindAsync(id);
            if (mecanicaFotosModel == null)
            {
                return NotFound();
            }
            ViewData["MecanicaId"] = new SelectList(_context.MecanicaModel, "Id", "Id", mecanicaFotosModel.MecanicaId);
            return View(mecanicaFotosModel);
        }

        // POST: MecanicaFotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Arquivo,Padrao,MecanicaId")] MecanicaFotosModel mecanicaFotosModel)
        {
            if (id != mecanicaFotosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mecanicaFotosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MecanicaFotosModelExists(mecanicaFotosModel.Id))
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
            ViewData["MecanicaId"] = new SelectList(_context.MecanicaModel, "Id", "Id", mecanicaFotosModel.MecanicaId);
            return View(mecanicaFotosModel);
        }

        // GET: MecanicaFotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MecanicaFotosModel == null)
            {
                return NotFound();
            }

            var mecanicaFotosModel = await _context.MecanicaFotosModel
                .Include(m => m.Mecanica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicaFotosModel == null)
            {
                return NotFound();
            }

            return View(mecanicaFotosModel);
        }

        // POST: MecanicaFotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MecanicaFotosModel == null)
            {
                return Problem("Entity set 'ProjetoMVCContext.MecanicaFotosModel'  is null.");
            }
            var mecanicaFotosModel = await _context.MecanicaFotosModel.FindAsync(id);
            if (mecanicaFotosModel != null)
            {
                _context.MecanicaFotosModel.Remove(mecanicaFotosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MecanicaFotosModelExists(int id)
        {
          return (_context.MecanicaFotosModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
