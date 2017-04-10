using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAspNetCore.Models;

namespace WebApiAspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Perfil")]
    public class PerfilController : Controller
    {
        private readonly DatabaseContext _context;

        public PerfilController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Perfil
        [HttpGet]
        public IEnumerable<Perfil> GetPerfil()
        {
            return _context.Perfil;
        }

        // GET: api/Perfil/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = await _context.Perfil.SingleOrDefaultAsync(m => m.ID == id);

            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfil/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil([FromRoute] int id, [FromBody] Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.ID)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return CreatedAtAction("GetPerfil", new { id = perfil.ID }, perfil);
        }

        // POST: api/Perfil
        [HttpPost]
        public async Task<IActionResult> PostPerfil([FromBody] Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Perfil.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.ID }, perfil);
        }

        // DELETE: api/Perfil/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = await _context.Perfil.SingleOrDefaultAsync(m => m.ID == id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfil.Remove(perfil);
            await _context.SaveChangesAsync();

            return Ok(perfil);
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfil.Any(e => e.ID == id);
        }
    }
}