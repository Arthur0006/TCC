using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class MecanicasController : Controller
    {
        private readonly ProjetoMVCContext _context;
        private string _filePath;
        public MecanicasController(ProjetoMVCContext context, IWebHostEnvironment env)
        {
            _filePath = env.WebRootPath;
            _context = context;
        }

        // GET: Mecanicas
        public async Task<IActionResult> Index()
        {
            var projetoMVCContext = _context.MecanicaModel.Include(m => m.Usuario).Include(m => m.Fotos);
            return View(await projetoMVCContext.ToListAsync());
        }

        // GET: Mecanicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MecanicaModel == null)
            {
                return NotFound();
            }

            var mecanicaModel = await _context.MecanicaModel
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicaModel == null)
            {
                return NotFound();
            }

            return View(mecanicaModel);
        }

        // GET: Mecanicas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Mecanicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,Cidade,Telefone,Tipo,Cep,Latitude,Longitude,Imagem,Descricao,UsuarioId")] MecanicaModel mecanicaModel, IFormFile imagem)

        {
            if (ModelState.IsValid)
            {
                
              if (!ValidaImagem(imagem))
                    return View(mecanicaModel);

                var nome = SalvarArquivo(imagem);
                mecanicaModel.Fotos = new List<MecanicaFotosModel>();
                mecanicaModel.Fotos.Add(new() { Arquivo = nome, Descricao = "Foto padrão", Padrao = true });

                _context.Add(mecanicaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Name", mecanicaModel.UsuarioId);
            return View(mecanicaModel);
        }

        public bool ValidaImagem(IFormFile imagem)
        {
            switch (imagem.ContentType)
            {
                case "image/avif":
                    return true;
                case "image/webp":
                    return true;
                case "image/jpeg":
                    return true;
                case "image/bmp":
                    return true;
                case "image/gif":
                    return true;
                case "image/png":
                    return true;
                default:
                    return false;

            }
        }

        public string SalvarArquivo(IFormFile imagem)
        {
            var nome = Guid.NewGuid().ToString() + imagem.FileName;

                var filePath = _filePath + "\\fotos";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (var stream = System.IO.File.Create(filePath + "\\" + nome))
            {
                imagem.CopyToAsync(stream);
            }
            return nome;
        }


        // GET: Mecanicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MecanicaModel == null)
            {
                return NotFound();
            }

            var mecanicaModel = await _context.MecanicaModel.FindAsync(id);
            if (mecanicaModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Name", mecanicaModel.UsuarioId);
            return View(mecanicaModel);
        }

        // POST: Mecanicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,Cidade,Telefone,Tipo,Cep,Latitude,Longitude,Imagem,Descricao,UsuarioId")] MecanicaModel mecanicaModel)
        {
            if (id != mecanicaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mecanicaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MecanicaModelExists(mecanicaModel.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Name", mecanicaModel.UsuarioId);
            return View(mecanicaModel);
        }

        // GET: Mecanicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MecanicaModel == null)
            {
                return NotFound();
            }

            var mecanicaModel = await _context.MecanicaModel
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicaModel == null)
            {
                return NotFound();
            }

            return View(mecanicaModel);
        }

        // POST: Mecanicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MecanicaModel == null)
            {
                return Problem("Entity set 'ProjetoMVCContext.MecanicaModel'  is null.");
            }
            var mecanicaModel = await _context.MecanicaModel.FindAsync(id);
            if (mecanicaModel != null)
            {
                _context.MecanicaModel.Remove(mecanicaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MecanicaModelExists(int id)
        {
            return (_context.MecanicaModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
