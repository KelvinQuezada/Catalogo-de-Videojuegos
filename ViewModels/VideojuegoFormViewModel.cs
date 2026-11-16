using CatalogoVideojuegos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatalogoVideojuegos.ViewModels;

/// <summary>
/// Modelo de vista para los formularios Create/Edit de Videojuego.
/// Agrupa la entidad, las listas de selección de las relaciones 1:N y los
/// identificadores marcados en la relación N:N (Videojuego ↔ Plataforma).
/// </summary>
public class VideojuegoFormViewModel
{
    public Videojuego Videojuego { get; set; } = new();

    public List<int> PlataformasSeleccionadas { get; set; } = new();

    public List<SelectListItem> Generos { get; set; } = new();

    public List<SelectListItem> Desarrolladoras { get; set; } = new();

    public List<SelectListItem> Plataformas { get; set; } = new();
}
