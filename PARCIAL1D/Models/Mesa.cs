using System.ComponentModel.DataAnnotations;

namespace PARCIAL1D.Models;

public class Mesa
{
    [Key]
    public int id_mesa { get;set; }
    public string descripcion { get; set; }
    public int empresa_id { get; set; }
    public int id_pago { get; set; }
    public char zona_mesa { get; set; }
    public int cantidad_sillas { get; set; }
    public char estado { get; set; }
    public DateTime fecha_creacion { get; set; }
    public DateTime fecha_mod { get; set; }
}