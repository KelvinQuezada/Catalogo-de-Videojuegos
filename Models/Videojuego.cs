using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoVideojuegos.Models;

/// <summary>
/// Entidad principal del catálogo. Cada videojuego pertenece a un género
/// y fue producido por una desarrolladora (relaciones 1:N).
/// </summary>
public class Videojuego
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(120, ErrorMessage = "El título no puede superar los {1} caracteres.")]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(600, ErrorMessage = "La descripción no puede superar los {1} caracteres.")]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    [Range(0, 999.99, ErrorMessage = "El precio debe estar entre {1} y {2}.")]
    [DataType(DataType.Currency)]
    [Display(Name = "Precio")]
    public decimal Precio { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de lanzamiento")]
    public DateOnly FechaLanzamiento { get; set; }

    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

    [Display(Name = "Disponible")]
    public bool Disponible { get; set; } = true;

    [Range(1, 8, ErrorMessage = "La cantidad de jugadores debe estar entre {1} y {2}.")]
    [Display(Name = "Cantidad de jugadores")]
    public int CantidadJugadores { get; set; } = 1;

    [StringLength(10)]
    [Display(Name = "Clasificación por edad")]
    public string? ClasificacionPorEdad { get; set; }

    // --- Evolución del modelo (migración ActualizarVideojuego) ---
    // Ambos campos son opcionales o tienen valor por omisión para que las
    // filas ya existentes se conserven sin intervención manual.

    [Display(Name = "Multijugador")]
    public bool Multijugador { get; set; }

    [StringLength(300, ErrorMessage = "La observación no puede superar los {1} caracteres.")]
    [Display(Name = "Observación")]
    public string? Observacion { get; set; }

    [Display(Name = "Género")]
    public int GeneroId { get; set; }

    public Genero? Genero { get; set; }

    [Display(Name = "Desarrolladora")]
    public int DesarrolladoraId { get; set; }

    public Desarrolladora? Desarrolladora { get; set; }

    /// <summary>
    /// Relación muchos a muchos con Plataforma. Un videojuego puede estar
    /// disponible en varias plataformas y una plataforma aloja muchos
    /// videojuegos. EF Core genera la tabla intermedia automáticamente.
    /// </summary>
    public ICollection<Plataforma> Plataformas { get; set; } = new List<Plataforma>();
}
