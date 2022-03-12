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
    public class PagoController : ControllerBase
    {
                private readonly DataContext _context;
        
                //Inyeccion de dependencias
                public PagoController(DataContext context)
                {
                    _context = context;
                }
        
                //Get
                [HttpGet]
                public async Task<ActionResult<List<Pago>>> Get()
                {
                    return Ok(await _context.Pago.ToListAsync());
                }
                
                //Get id
                [HttpGet("{id}")]
                public async Task<ActionResult<List<Pago>>> Get(int id)
                {
                    var data= _context.Pago.FindAsync(id);
                    if (data == null) 
                        return BadRequest();
                    return Ok(data);
                }
                
                //Post
                [HttpPost]
                public async Task<ActionResult<List<Pago>>> Post(Pago data)
                {
                    _context.Pago.Add(data);
                    await _context.SaveChangesAsync();
        
                    return Ok(await _context.Pago.ToListAsync());
                }
                
                //Put
                [HttpPut]
                public async Task<ActionResult<List<Pago>>> Put(Pago request)
                {
                    var data = await _context.Pago.FindAsync(request.id_pago);
                    
                    data!.id_empresa = request.id_empresa;
                    data!.id_pago = request.id_pago;
                    data!.id_encabezado_orden = request.id_encabezado_orden;
                    data!.tipo_pago = request.tipo_pago;
                    data!.subtotal = request.subtotal;
                    data!.propina = request.propina;
                    data!.total = request.total;
                    data!.monto_pagado = request.monto_pagado;
        
                    await _context.SaveChangesAsync();
        
                    return Ok(data);
                }
    }
}