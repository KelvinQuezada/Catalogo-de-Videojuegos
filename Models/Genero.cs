using System.ComponentModel.DataAnnotations;

namespace CatalogoVideojuegos.Models;

/// <summary>
/// Catálogo de géneros. Es la entidad principal de la relación 1:N
/// con Videojuego (un género agrupa muchos videojuegos).
/// </summary>
public class Genero
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del género es obligatorio.")]
    [StringLength(60, ErrorMessage = "El nombre no puede superar los {1} caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(300, ErrorMessage = "La descripción no puede superar los {1} caracteres.")]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [Display(Name = "Popular")]
    public bool Popular { get; set; }

    public ICollection<Videojuego> Videojuegos { get; set; } = new List<Videojuego>();
}
