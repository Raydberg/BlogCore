using System.ComponentModel.DataAnnotations;

namespace BlogCore.Models;

public class Categoria
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Ingrese un nombre para la categoria")]
    [Display(Name = "Nombre de Categoria")]
    public string Nombre { get; set; }
    [Display(Name = "Orden de visualizacion")]
    public int? Orden { get; set; }


}
