using CatalogoVideojuegos.Data;
using CatalogoVideojuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVideojuegos.Controllers;

/// <summary>
/// CRUD de Plataforma. En la vista Details se recorre el lado inverso de la
/// relación N:N para mostrar todos los videojuegos disponibles en la consola.
/// </summary>
public class PlataformasController : Controller
{
    private readonly ApplicationDbContext _context;

    public PlataformasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Plataformas
    public async Task<IActionResult> Index()
    {
        var plataformas = await _context.Plataformas
            .Include(p => p.Videojuegos)
            .OrderBy(p => p.Nombre)
            .ToListAsync();

        return View(plataformas);
    }

    // GET: /Plataformas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var plataforma = await _context.Plataformas
            .Include(p => p.Videojuegos)
                .ThenInclude(v => v.Genero)
            .Include(p => p.Videojuegos)
                .ThenInclude(v => v.Desarrolladora)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (plataforma == null)
        {
            return NotFound();
        }

        return View(plataforma);
    }

    // GET: /Plataformas/Create
    public IActionResult Create()
    {
        return View(new Plataforma());
    }

    // POST: /Plataformas/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Fabricante,FechaLanzamiento,Generacion,PrecioBase,Activa")] Plataforma plataforma)
    {
        if (!ModelState.IsValid)
        {
            return View(plataforma);
        }

        _context.Plataformas.Add(plataforma);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Plataforma \"{plataforma.Nombre}\" registrada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Plataformas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var plataforma = await _context.Plataformas.FindAsync(id);
        if (plataforma == null)
        {
            return NotFound();
        }

        return View(plataforma);
    }

    // POST: /Plataformas/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fabricante,FechaLanzamiento,Generacion,PrecioBase,Activa")] Plataforma plataforma)
    {
        if (id != plataforma.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(plataforma);
        }

        try
        {
            _context.Update(plataforma);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = $"Plataforma \"{plataforma.Nombre}\" actualizada correctamente.";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await PlataformaExisteAsync(plataforma.Id))
            {
                return NotFound();
            }
            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /Plataformas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var plataforma = await _context.Plataformas
            .Include(p => p.Videojuegos)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (plataforma == null)
        {
            return NotFound();
        }

        return View(plataforma);
    }

    // POST: /Plataformas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var plataforma = await _context.Plataformas.FindAsync(id);
        if (plataforma != null)
        {
            // La llave foránea de la tabla intermedia está configurada con
            // ON DELETE CASCADE: se eliminan las asociaciones, no los juegos.
            _context.Plataformas.Remove(plataforma);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = $"Plataforma \"{plataforma.Nombre}\" eliminada.";
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> PlataformaExisteAsync(int id)
    {
        return await _context.Plataformas.AnyAsync(p => p.Id == id);
    }
}
