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
    public class PlatoController : ControllerBase
    {
        private readonly DataContext _context;

        //Inyeccion de dependencias
        public PlatoController(DataContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult<List<Plato>>> Get()
        {
            return Ok(await _context.Plato.ToListAsync());
        }
        
        //Get id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Plato>>> Get(int id)
        {
            var data= _context.Plato.FindAsync(id);
            if (data == null) 
                return BadRequest();
            return Ok(data);
        }
        
        //Post
        [HttpPost]
        public async Task<ActionResult<List<Plato>>> Post(Plato data)
        {
            _context.Plato.Add(data);
            await _context.SaveChangesAsync();

            return Ok(await _context.Plato.ToListAsync());
        }
        
        //Put
        [HttpPut]
        public async Task<ActionResult<List<Plato>>> Put(Plato request)
        {
            var data = await _context.Plato.FindAsync(request.id_plato);
            
            data!.nombre = request.nombre;

            await _context.SaveChangesAsync();

            return Ok(data);
        }
    }
}