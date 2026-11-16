using System.ComponentModel.DataAnnotations;

namespace CatalogoVideojuegos.Models;

/// <summary>
/// Estudio que produce videojuegos. Es la entidad principal de la
/// relación 1:N con Videojuego (una desarrolladora tiene muchos videojuegos).
/// </summary>
public class Desarrolladora
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la desarrolladora es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los {1} caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El país es obligatorio.")]
    [StringLength(60, ErrorMessage = "El país no puede superar los {1} caracteres.")]
    [Display(Name = "País")]
    public string Pais { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de fundación")]
    public DateOnly? Fundacion { get; set; }

    [Url(ErrorMessage = "El sitio web debe ser una URL válida.")]
    [StringLength(200)]
    [Display(Name = "Sitio web")]
    public string? SitioWeb { get; set; }

    [Range(1, 50000, ErrorMessage = "El número de empleados debe estar entre {1} y {2}.")]
    [Display(Name = "Número de empleados")]
    public int? Empleados { get; set; }

    [Display(Name = "Activa")]
    public bool Activa { get; set; } = true;

    public ICollection<Videojuego> Videojuegos { get; set; } = new List<Videojuego>();
}
