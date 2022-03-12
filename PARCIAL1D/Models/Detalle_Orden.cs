using System.ComponentModel.DataAnnotations;

namespace PARCIAL1D.Models;

public class Detalle_Orden
{
    [Key]
    public int id_detalle_orden { get;set; }
    public int id_encabezado_orden { get;set; }
    public int id_empresa { get; set; }
    public int id_plato { get; set; }
    public int cantidad { get; set; }
    public string comentarios { get; set; }
    public decimal descuento_especial { get; set; }
    public decimal recargo_orden { get; set; }
    public char estado { get; set; }
    public DateTime fecha_creacion;
    public DateTime fecha_mod;
}