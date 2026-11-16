using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoVideojuegos.Models;

/// <summary>
/// Catálogo de plataformas (consolas, PC, portátiles y servicios de nube).
/// Participa en la relación muchos a muchos con Videojuego.
/// </summary>
public class Plataforma
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la plataforma es obligatorio.")]
    [StringLength(60, ErrorMessage = "El nombre no puede superar los {1} caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El fabricante es obligatorio.")]
    [StringLength(80, ErrorMessage = "El fabricante no puede superar los {1} caracteres.")]
    [Display(Name = "Fabricante")]
    public string Fabricante { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de lanzamiento")]
    public DateOnly? FechaLanzamiento { get; set; }

    [Range(1, 10, ErrorMessage = "La generación debe estar entre {1} y {2}.")]
    [Display(Name = "Generación")]
    public int? Generacion { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    [Range(0, 9999.99, ErrorMessage = "El precio base debe estar entre {1} y {2}.")]
    [DataType(DataType.Currency)]
    [Display(Name = "Precio base")]
    public decimal? PrecioBase { get; set; }

    [Display(Name = "Activa")]
    public bool Activa { get; set; } = true;

    /// <summary>
    /// Lado inverso de la relación muchos a muchos: una plataforma tiene
    /// muchos videojuegos y un videojuego puede aparecer en varias plataformas.
    /// </summary>
    public ICollection<Videojuego> Videojuegos { get; set; } = new List<Videojuego>();
}
