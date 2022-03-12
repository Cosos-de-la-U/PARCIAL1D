using System.ComponentModel.DataAnnotations;

namespace PARCIAL1D.Models;

public class Plato
{
    [Key]
    public int id_plato { get;set; }
    public string nombre { get; set; }
}