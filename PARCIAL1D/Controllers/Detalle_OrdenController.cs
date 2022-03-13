using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1D.Data;
using PARCIAL1D.Models;

namespace PARCIAL1D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_OrdenController : ControllerBase
    {
         private readonly DataContext _context;
        
                //Inyeccion de dependencias
                public Detalle_OrdenController(DataContext context)
                {
                    _context = context;
                }
        
                //Get
                [HttpGet]
                public async Task<ActionResult<List<Detalle_Orden>>> Get()
                {
                    var data = (from deo in _context.Detalle_Orden
                        join eo in _context.EncabezadoOrden on deo.id_encabezado_orden equals eo.id_encabezado_orden
                        join e in _context.Empresa on deo.id_empresa equals e.id_empresa
                        join p in _context.Plato on deo.id_plato equals p.id_plato
                        join u in _context.Usuario on eo.id_usuario equals u.id_usuario
                        select new
                        {
                            deo.id_detalle_orden, nombre_empresa = e.nombre, e.representante, usuario_nombre = u.nombre, plato_nombre = p.nombre,
                            deo.cantidad, deo.comentarios, deo.descuento_especial, deo.recargo_orden,
                            deo.estado, deo.fecha_creacion, deo.fecha_mod
                        }).ToListAsync();
                            
                    if (data == null) 
                        return BadRequest();
                    
                    return Ok(await data);
                }
                
                //Get id
                [HttpGet("{id}")]
                public async Task<ActionResult<List<Detalle_Orden>>> Get(int id)
                {
                    var data = (from deo in _context.Detalle_Orden
                        join eo in _context.EncabezadoOrden on deo.id_encabezado_orden equals eo.id_encabezado_orden
                        join e in _context.Empresa on deo.id_empresa equals e.id_empresa
                        join p in _context.Plato on deo.id_plato equals p.id_plato
                        join u in _context.Usuario on eo.id_usuario equals u.id_usuario
                        select new
                        {
                            deo.id_detalle_orden, nombre_empresa = e.nombre, e.representante, usuario_nombre = u.nombre, plato_nombre = p.nombre,
                            deo.cantidad, deo.comentarios, deo.descuento_especial, deo.recargo_orden,
                            deo.estado, deo.fecha_creacion, deo.fecha_mod
                        }).FirstOrDefaultAsync();
                            
                    return Ok(await data);
                }
                
                //Post
                [HttpPost]
                public async Task<ActionResult<List<Detalle_Orden>>> Post(Detalle_Orden data)
                {
                    _context.Detalle_Orden.Add(data);
                    await _context.SaveChangesAsync();
        
                    return Ok(await _context.Detalle_Orden.ToListAsync());
                }
                
                //Put
                [HttpPut]
                public async Task<ActionResult<List<Detalle_Orden>>> Put(Detalle_Orden request)
                {
                    var data = await _context.Detalle_Orden.FindAsync(request.id_encabezado_orden);
                    
                    data!.id_encabezado_orden = request.id_encabezado_orden;
                    data!.id_empresa = request.id_empresa;
                    data!.id_plato = request.id_plato;
                    data!.cantidad = request.cantidad;
                    data!.comentarios = request.comentarios;
                    data!.descuento_especial = request.id_detalle_orden;
                    data!.recargo_orden = request.recargo_orden;
                    data!.estado = request.estado;
                    data!.fecha_creacion = request.fecha_creacion;
                    data!.fecha_mod = request.fecha_mod;
                    
        
                    await _context.SaveChangesAsync();
        
                    return Ok(data);
                }
    }
}