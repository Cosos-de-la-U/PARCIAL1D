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
                    var data = (from m in _context.Mesa
                        join e in _context.Empresa on m.id_empresa equals e.id_empresa
                        join p in _context.Pago on m.id_pago equals p.id_pago
                        select new
                        {
                            m.id_mesa, m.descripcion, e.nombre, e.representante, p.tipo_pago, p.subtotal, p.total,
                            m.zona_mesa, m.cantidad_sillas, m.estado, m.fecha_creacion , m.fecha_mod
                        }).ToListAsync();
                            
                    if (data == null) 
                        return BadRequest();
                    
                    return Ok(await data);
                }
                
                //Get id
                [HttpGet("{id}")]
                public async Task<ActionResult<List<Mesa>>> Get(int id)
                {
                    var data = (from m in _context.Mesa
                        join e in _context.Empresa on m.id_empresa equals e.id_empresa
                        join p in _context.Pago on m.id_pago equals p.id_pago
                        select new
                        {
                            m.id_mesa, m.descripcion, e.nombre ,p.tipo_pago, p.subtotal, p.total,
                            m.zona_mesa, m.cantidad_sillas, m.estado, m.fecha_creacion , m.fecha_mod
                        }).FirstOrDefaultAsync();
                            
                    if (data == null) 
                        return BadRequest();
                    
                    return Ok(await data);
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
                    data!.id_empresa = request.id_empresa;
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