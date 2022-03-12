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
    public class MesaController : ControllerBase
    {
        private readonly DataContext _context;
        
                //Inyeccion de dependencias
                public MesaController(DataContext context)
                {
                    _context = context;
                }
        
                //Get
                [HttpGet]
                public async Task<ActionResult<List<Mesa>>> Get()
                {
                    return Ok(await _context.Mesa.ToListAsync());
                }
                
                //Get id
                [HttpGet("{id}")]
                public async Task<ActionResult<List<Mesa>>> Get(int id)
                {
                    var data= _context.Mesa.FindAsync(id);
                    if (data == null) 
                        return BadRequest();
                    return Ok(data);
                }
                
                //Post
                [HttpPost]
                public async Task<ActionResult<List<Mesa>>> Post(Mesa data)
                {
                    _context.Mesa.Add(data);
                    await _context.SaveChangesAsync();
        
                    return Ok(await _context.Mesa.ToListAsync());
                }
                
                //Put
                [HttpPut]
                public async Task<ActionResult<List<Mesa>>> Put(Mesa request)
                {
                    var data = await _context.Mesa.FindAsync(request.id_mesa);
                    
                    data!.descripcion = request.descripcion;
                    data!.empresa_id = request.empresa_id;
                    data!.id_pago = request.id_pago;
                    data!.zona_mesa = request.zona_mesa;
                    data!.cantidad_sillas = request.cantidad_sillas;
                    data!.estado = request.estado;
                    data!.fecha_creacion = request.fecha_creacion;
                    data!.fecha_creacion = request.fecha_creacion;
                    data!.fecha_mod = request.fecha_mod;
        
                    await _context.SaveChangesAsync();
        
                    return Ok(data);
                }
    }
}