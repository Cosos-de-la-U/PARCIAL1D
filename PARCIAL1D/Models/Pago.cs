using System.ComponentModel.DataAnnotations;

namespace PARCIAL1D.Models;

public class Pago
{
    [Key]
    public int id_pago { get;set; }
    public int id_empresa { get; set; }
    public int id_encabezado_orden { get; set; }
    public string tipo_pago { get; set; }
    public decimal subtotal { get; set; }
    public decimal propina { get; set; }
    public decimal total { get; set; }
    public decimal monto_pagado { get; set; }
    public int id_usuario { get; set; }
    public DateTime fecha_creacion { get; set; }
    public DateTime fecha_mod { get; set; }
    public string numero_tarjeta { get; set; }
    public string nombre_tarjeta { get; set; }
    public char autorizacion { get; set; }
    public char estado { get; set; }
}