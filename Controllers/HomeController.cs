using CatalogoVideojuegos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVideojuegos.Controllers;

/// <summary>
/// Página de inicio con un panel de resumen del catálogo. Consulta la base
/// mediante ApplicationDbContext para mostrar los conteos por tabla.
/// </summary>
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.TotalVideojuegos = await _context.Videojuegos.CountAsync();
        ViewBag.TotalPlataformas = await _context.Plataformas.CountAsync();
        ViewBag.TotalDesarrolladoras = await _context.Desarrolladoras.CountAsync();
        ViewBag.TotalGeneros = await _context.Generos.CountAsync();

        ViewBag.TotalAsociaciones = await _context.Videojuegos
            .SelectMany(v => v.Plataformas)
            .CountAsync();

        ViewBag.UltimosVideojuegos = await _context.Videojuegos
            .Include(v => v.Genero)
            .Include(v => v.Desarrolladora)
            .Include(v => v.Plataformas)
            .OrderByDescending(v => v.Id)
            .Take(5)
            .ToListAsync();

        ViewBag.TopPlataformas = await _context.Plataformas
            .Select(p => new { p.Nombre, Cantidad = p.Videojuegos.Count })
            .OrderByDescending(p => p.Cantidad)
            .ThenBy(p => p.Nombre)
            .Take(5)
            .ToListAsync();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
