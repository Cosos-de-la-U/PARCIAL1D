using System.ComponentModel.DataAnnotations;

namespace PARCIAL1D.Models;

public class Empresa
{
    [Key]
    public int id_empresa { get;set; }
    public string nombre { get; set; }
    public string representante { get; set; }
    public string nit { get; set; }
    public string nrc { get; set; }
    public string direccion { get; set; }
    public string correo { get; set; }
    public string telefono { get; set; }
    public char estado { get; set; }
    public DateTime fecha_creacion { get; set; }
    public DateTime fecha_mod { get; set; }
}