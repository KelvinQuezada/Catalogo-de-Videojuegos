using CatalogoVideojuegos.Data;
using CatalogoVideojuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVideojuegos.Controllers;

/// <summary>
/// CRUD de Desarrolladora, entidad principal de una relación 1:N con
/// Videojuego. El borrado se bloquea si la desarrolladora tiene juegos.
/// </summary>
public class DesarrolladorasController : Controller
{
    private readonly ApplicationDbContext _context;

    public DesarrolladorasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Desarrolladoras
    public async Task<IActionResult> Index()
    {
        var desarrolladoras = await _context.Desarrolladoras
            .Include(d => d.Videojuegos)
            .OrderBy(d => d.Nombre)
            .ToListAsync();

        return View(desarrolladoras);
    }

    // GET: /Desarrolladoras/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var desarrolladora = await _context.Desarrolladoras
            .Include(d => d.Videojuegos)
                .ThenInclude(v => v.Genero)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (desarrolladora == null)
        {
            return NotFound();
        }

        return View(desarrolladora);
    }

    // GET: /Desarrolladoras/Create
    public IActionResult Create()
    {
        return View(new Desarrolladora());
    }

    // POST: /Desarrolladoras/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Pais,Fundacion,SitioWeb,Empleados,Activa")] Desarrolladora desarrolladora)
    {
        if (!ModelState.IsValid)
        {
            return View(desarrolladora);
        }

        _context.Desarrolladoras.Add(desarrolladora);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Desarrolladora \"{desarrolladora.Nombre}\" registrada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Desarrolladoras/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var desarrolladora = await _context.Desarrolladoras.FindAsync(id);
        if (desarrolladora == null)
        {
            return NotFound();
        }

        return View(desarrolladora);
    }

    // POST: /Desarrolladoras/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Pais,Fundacion,SitioWeb,Empleados,Activa")] Desarrolladora desarrolladora)
    {
        if (id != desarrolladora.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(desarrolladora);
        }

        _context.Update(desarrolladora);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Desarrolladora \"{desarrolladora.Nombre}\" actualizada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Desarrolladoras/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var desarrolladora = await _context.Desarrolladoras
            .Include(d => d.Videojuegos)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (desarrolladora == null)
        {
            return NotFound();
        }

        return View(desarrolladora);
    }

    // POST: /Desarrolladoras/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var desarrolladora = await _context.Desarrolladoras
            .Include(d => d.Videojuegos)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (desarrolladora == null)
        {
            return RedirectToAction(nameof(Index));
        }

        // La relación 1:N usa ON DELETE RESTRICT: no se puede eliminar una
        // desarrolladora que todavía tenga videojuegos asociados.
        if (desarrolladora.Videojuegos.Count > 0)
        {
            TempData["Error"] = $"No se puede eliminar \"{desarrolladora.Nombre}\": tiene {desarrolladora.Videojuegos.Count} videojuego(s) asociado(s).";
            return RedirectToAction(nameof(Delete), new { id });
        }

        _context.Desarrolladoras.Remove(desarrolladora);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Desarrolladora \"{desarrolladora.Nombre}\" eliminada.";
        return RedirectToAction(nameof(Index));
    }
}
