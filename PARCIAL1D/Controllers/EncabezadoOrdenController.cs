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
    public class EncabezadoOrdenController : ControllerBase
    {
                private readonly DataContext _context;
        
                //Inyeccion de dependencias
                public EncabezadoOrdenController(DataContext context)
                {
                    _context = context;
                }
        
                //Get
                [HttpGet]
                public async Task<ActionResult<List<EncabezadoOrden>>> Get()
                {
                    return Ok(await _context.EncabezadoOrden.ToListAsync());
                }
                
                //Get id
                [HttpGet("{id}")]
                public async Task<ActionResult<List<EncabezadoOrden>>> Get(int id)
                {
                    var data= _context.EncabezadoOrden.FindAsync(id);
                    if (data == null) 
                        return BadRequest();
                    return Ok(data);
                }
                
                //Post
                [HttpPost]
                public async Task<ActionResult<List<EncabezadoOrden>>> Post(EncabezadoOrden data)
                {
                    _context.EncabezadoOrden.Add(data);
                    await _context.SaveChangesAsync();
        
                    return Ok(await _context.EncabezadoOrden.ToListAsync());
                }
                
                //Put
                [HttpPut]
                public async Task<ActionResult<List<EncabezadoOrden>>> Put(EncabezadoOrden request)
                {
                    var data = await _context.EncabezadoOrden.FindAsync(request.id_usuario);
                    
                    data!.id_empresa = request.id_empresa;
                    data!.id_usuario = request.id_usuario;
                    data!.tipo_orden = request.tipo_orden;
                    data!.fecha_orden = request.fecha_orden;
                    data!.id_mesa = request.id_mesa;
                    data!.cliente = request.cliente;
                    data!.estado_orden = request.estado_orden;
                    data!.tipo_pago = request.tipo_pago;
                    data!.estado = request.estado;
                    data!.fecha_creacion = request.fecha_creacion;
                    data!.fecha_modificacion = request.fecha_modificacion;
        
                    await _context.SaveChangesAsync();
        
                    return Ok(data);
                }
    }
}