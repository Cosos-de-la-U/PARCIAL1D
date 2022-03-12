using System.ComponentModel.DataAnnotations;

namespace PARCIAL1D.Models;

public class EncabezadoOrden
{
    [Key]
    public int id_encabezado_orden { get;set; }
    public int id_empresa { get; set; }
    public int id_usuario { get; set; }
    public char tipo_orden { get; set; }
    public DateTime fecha_orden{ get; set; }
    public int id_mesa { get; set; }
    public string cliente { get; set; }
    public char  estado_orden { get; set; }
    public string tipo_pago { get; set; }
    public char estado { get; set; }
    public DateTime fecha_creacion { get; set; }
    public DateTime fecha_modificacion { get; set; }
}