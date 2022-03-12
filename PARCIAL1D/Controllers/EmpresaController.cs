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
    public class EmpresaController : ControllerBase
    {
        private readonly DataContext _context;
        
                //Inyeccion de dependencias
                public EmpresaController(DataContext context)
                {
                    _context = context;
                }
        
                //Get
                [HttpGet]
                public async Task<ActionResult<List<Empresa>>> Get()
                {
                    return Ok(await _context.Empresa.ToListAsync());
                }
                
                //Get id
                [HttpGet("{id}")]
                public async Task<ActionResult<List<Empresa>>> Get(int id)
                {
                    var data= _context.Empresa.FindAsync(id);
                    if (data == null) 
                        return BadRequest();
                    return Ok(data);
                }
                
                //Post
                [HttpPost]
                public async Task<ActionResult<List<Empresa>>> Post(Empresa data)
                {
                    _context.Empresa.Add(data);
                    await _context.SaveChangesAsync();
        
                    return Ok(await _context.Empresa.ToListAsync());
                }
                
                //Put
                [HttpPut]
                public async Task<ActionResult<List<Empresa>>> Put(Empresa request)
                {
                    var data = await _context.Empresa.FindAsync(request.id_empresa);
                    
                    data!.id_empresa = request.id_empresa;
                    data!.nombre = request.nombre;
                    data!.representante = request.representante;
                    data!.nit = request.nit;
                    data!.nrc = request.nrc;
                    data!.direccion = request.direccion;
                    data!.correo = request.correo;
                    data!.telefono = request.telefono;
                    data!.estado = request.estado;
                    data!.fecha_creacion = request.fecha_creacion;
                    data!.fecha_mod = request.fecha_mod;
        
                    await _context.SaveChangesAsync();
        
                    return Ok(data);
                }
    }
}