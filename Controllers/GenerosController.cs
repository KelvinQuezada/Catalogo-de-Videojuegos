using CatalogoVideojuegos.Data;
using CatalogoVideojuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVideojuegos.Controllers;

/// <summary>
/// CRUD de Genero, entidad principal de una relación 1:N con Videojuego.
/// </summary>
public class GenerosController : Controller
{
    private readonly ApplicationDbContext _context;

    public GenerosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Generos
    public async Task<IActionResult> Index()
    {
        var generos = await _context.Generos
            .Include(g => g.Videojuegos)
            .OrderBy(g => g.Nombre)
            .ToListAsync();

        return View(generos);
    }

    // GET: /Generos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genero = await _context.Generos
            .Include(g => g.Videojuegos)
                .ThenInclude(v => v.Desarrolladora)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (genero == null)
        {
            return NotFound();
        }

        return View(genero);
    }

    // GET: /Generos/Create
    public IActionResult Create()
    {
        return View(new Genero());
    }

    // POST: /Generos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Popular")] Genero genero)
    {
        if (!ModelState.IsValid)
        {
            return View(genero);
        }

        _context.Generos.Add(genero);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Género \"{genero.Nombre}\" registrado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Generos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genero = await _context.Generos.FindAsync(id);
        if (genero == null)
        {
            return NotFound();
        }

        return View(genero);
    }

    // POST: /Generos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Popular")] Genero genero)
    {
        if (id != genero.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(genero);
        }

        _context.Update(genero);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Género \"{genero.Nombre}\" actualizado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Generos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genero = await _context.Generos
            .Include(g => g.Videojuegos)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (genero == null)
        {
            return NotFound();
        }

        return View(genero);
    }

    // POST: /Generos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var genero = await _context.Generos
            .Include(g => g.Videojuegos)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (genero == null)
        {
            return RedirectToAction(nameof(Index));
        }

        if (genero.Videojuegos.Count > 0)
        {
            TempData["Error"] = $"No se puede eliminar \"{genero.Nombre}\": tiene {genero.Videojuegos.Count} videojuego(s) asociado(s).";
            return RedirectToAction(nameof(Delete), new { id });
        }

        _context.Generos.Remove(genero);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Género \"{genero.Nombre}\" eliminado.";
        return RedirectToAction(nameof(Index));
    }
}
