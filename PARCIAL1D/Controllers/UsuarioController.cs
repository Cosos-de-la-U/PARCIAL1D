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
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        //Inyeccion de dependencias
        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return Ok(await _context.Usuario.ToListAsync());
        }
        
        //Get id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuario>>> Get(int id)
        {
            var data= _context.Usuario.FindAsync(id);
            if (data == null) 
                return BadRequest();
            return Ok(data);
        }
        
        //Post
        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> Post(Usuario data)
        {
            _context.Usuario.Add(data);
            await _context.SaveChangesAsync();

            return Ok(await _context.Usuario.ToListAsync());
        }
        
        //Put
        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> Put(Usuario request)
        {
            var data = await _context.Usuario.FindAsync(request.id_usuario);
            
            data!.nombre = request.nombre;
            data!.apellido = request.apellido;

            await _context.SaveChangesAsync();

            return Ok(data);
        }
    }
}