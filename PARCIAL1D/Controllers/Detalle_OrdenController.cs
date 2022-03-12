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
                    return Ok(await _context.Detalle_Orden.ToListAsync());
                }
                
                //Get id
                [HttpGet("{id}")]
                public async Task<ActionResult<List<Detalle_Orden>>> Get(int id)
                {
                    var data= _context.Detalle_Orden.FindAsync(id);
                    if (data == null) 
                        return BadRequest();
                    return Ok(data);
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
                    data!.id_empresa = request.id_empresa;
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