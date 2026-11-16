using CatalogoVideojuegos.Data;
using CatalogoVideojuegos.Models;
using CatalogoVideojuegos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVideojuegos.Controllers;

/// <summary>
/// CRUD de la entidad principal Videojuego. El controlador recibe
/// ApplicationDbContext por inyección de dependencias y lo utiliza para
/// consultar y persistir la información en PostgreSQL.
/// </summary>
public class VideojuegosController : Controller
{
    private readonly ApplicationDbContext _context;

    public VideojuegosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Videojuegos?buscar=zelda
    public async Task<IActionResult> Index(string? buscar)
    {
        var consulta = _context.Videojuegos
            .Include(v => v.Genero)
            .Include(v => v.Desarrolladora)
            .Include(v => v.Plataformas)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            var texto = buscar.Trim().ToLower();
            consulta = consulta.Where(v => v.Titulo.ToLower().Contains(texto));
        }

        ViewData["Buscar"] = buscar;

        var videojuegos = await consulta
            .OrderBy(v => v.Titulo)
            .ToListAsync();

        return View(videojuegos);
    }

    // GET: /Videojuegos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var videojuego = await _context.Videojuegos
            .Include(v => v.Genero)
            .Include(v => v.Desarrolladora)
            .Include(v => v.Plataformas)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (videojuego == null)
        {
            return NotFound();
        }

        return View(videojuego);
    }

    // GET: /Videojuegos/Create
    public async Task<IActionResult> Create()
    {
        var modelo = new VideojuegoFormViewModel
        {
            Videojuego = new Videojuego { FechaLanzamiento = DateOnly.FromDateTime(DateTime.Today) }
        };
        await CargarListasAsync(modelo);
        return View(modelo);
    }

    // POST: /Videojuegos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VideojuegoFormViewModel modelo)
    {
        if (!ModelState.IsValid)
        {
            await CargarListasAsync(modelo);
            return View(modelo);
        }

        modelo.Videojuego.FechaRegistro = DateTime.UtcNow;
        modelo.Videojuego.Plataformas = await ObtenerPlataformasAsync(modelo.PlataformasSeleccionadas);

        _context.Videojuegos.Add(modelo.Videojuego);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Videojuego \"{modelo.Videojuego.Titulo}\" registrado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Videojuegos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var videojuego = await _context.Videojuegos
            .Include(v => v.Plataformas)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (videojuego == null)
        {
            return NotFound();
        }

        var modelo = new VideojuegoFormViewModel
        {
            Videojuego = videojuego,
            PlataformasSeleccionadas = videojuego.Plataformas.Select(p => p.Id).ToList()
        };
        await CargarListasAsync(modelo);
        return View(modelo);
    }

    // POST: /Videojuegos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VideojuegoFormViewModel modelo)
    {
        if (id != modelo.Videojuego.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            await CargarListasAsync(modelo);
            return View(modelo);
        }

        var videojuego = await _context.Videojuegos
            .Include(v => v.Plataformas)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (videojuego == null)
        {
            return NotFound();
        }

        // Se copian campo por campo; FechaRegistro no se modifica porque
        // representa el momento en que se dio de alta el registro original.
        videojuego.Titulo = modelo.Videojuego.Titulo;
        videojuego.Descripcion = modelo.Videojuego.Descripcion;
        videojuego.Precio = modelo.Videojuego.Precio;
        videojuego.FechaLanzamiento = modelo.Videojuego.FechaLanzamiento;
        videojuego.Disponible = modelo.Videojuego.Disponible;
        videojuego.CantidadJugadores = modelo.Videojuego.CantidadJugadores;
        videojuego.ClasificacionPorEdad = modelo.Videojuego.ClasificacionPorEdad;
        videojuego.GeneroId = modelo.Videojuego.GeneroId;
        videojuego.DesarrolladoraId = modelo.Videojuego.DesarrolladoraId;
        videojuego.Multijugador = modelo.Videojuego.Multijugador;
        videojuego.Observacion = modelo.Videojuego.Observacion;

        // Actualización de la relación N:N: se reemplaza el conjunto de
        // plataformas asociadas. EF Core sincroniza la tabla intermedia.
        videojuego.Plataformas.Clear();
        foreach (var plataforma in await ObtenerPlataformasAsync(modelo.PlataformasSeleccionadas))
        {
            videojuego.Plataformas.Add(plataforma);
        }

        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Videojuego \"{videojuego.Titulo}\" actualizado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Videojuegos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var videojuego = await _context.Videojuegos
            .Include(v => v.Genero)
            .Include(v => v.Desarrolladora)
            .Include(v => v.Plataformas)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (videojuego == null)
        {
            return NotFound();
        }

        return View(videojuego);
    }

    // POST: /Videojuegos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var videojuego = await _context.Videojuegos
            .Include(v => v.Plataformas)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (videojuego != null)
        {
            _context.Videojuegos.Remove(videojuego);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = $"Videojuego \"{videojuego.Titulo}\" eliminado.";
        }

        return RedirectToAction(nameof(Index));
    }

    /// <summary>Carga las listas de los formularios (géneros, desarrolladoras y plataformas).</summary>
    private async Task CargarListasAsync(VideojuegoFormViewModel modelo)
    {
        var generos = await _context.Generos.OrderBy(g => g.Nombre).ToListAsync();
        var desarrolladoras = await _context.Desarrolladoras.OrderBy(d => d.Nombre).ToListAsync();
        var plataformas = await _context.Plataformas.OrderBy(p => p.Nombre).ToListAsync();

        modelo.Generos = generos.Select(g => new SelectListItem(g.Nombre, g.Id.ToString())).ToList();
        modelo.Desarrolladoras = desarrolladoras.Select(d => new SelectListItem(d.Nombre, d.Id.ToString())).ToList();
        modelo.Plataformas = plataformas.Select(p => new SelectListItem($"{p.Nombre} ({p.Fabricante})", p.Id.ToString())).ToList();
    }

    /// <summary>
    /// Traduce los identificadores marcados en el formulario a entidades
    /// Plataforma administradas por el contexto.
    /// </summary>
    private async Task<List<Plataforma>> ObtenerPlataformasAsync(List<int>? ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return new List<Plataforma>();
        }

        return await _context.Plataformas
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }
}
