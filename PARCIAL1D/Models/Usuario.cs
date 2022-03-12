using System.ComponentModel.DataAnnotations;

namespace PARCIAL1D.Models;

public class Usuario
{
    [Key]
    public int id_usuario { get;set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
}