using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using calculadorabe.Models;

namespace calculadorabe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        private readonly calculadoradbContext _context;

        public CalculadoraController(calculadoradbContext context)
        {
            _context = context;
        }

        // GET: api/Calculadora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculadora>>> GetCalculadora()
        {
            return await _context.Calculadora.ToListAsync();
        }

        // GET: api/Calculadora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calculadora>> GetCalculadora(int id)
        {
            var calculadora = await _context.Calculadora.FindAsync(id);

            if (calculadora == null)
            {
                return NotFound();
            }

            return calculadora;
        }

        [HttpGet("{operacion}")]
        public async Task<ActionResult<IEnumerable<Calculadora>>> GetCalculadoraPorOperacion(string operacion)
        {
            var eperaciones = await _context.Calculadora.Where(x => x.Nombre == operacion).ToListAsync();

            if (eperaciones == null)
            {
                return NotFound();
            }

            return eperaciones;
        }


        // PUT: api/Calculadora/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculadora(int id, Calculadora calculadora)
        {
            if (id != calculadora.IdOperacion)
            {
                return BadRequest();
            }

            _context.Entry(calculadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculadoraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Calculadora
        [HttpPost]
        public async Task<ActionResult<Calculadora>> PostCalculadora(Calculadora calculadora)
        {
            _context.Calculadora.Add(calculadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculadora", new { id = calculadora.IdOperacion }, calculadora);
        }

        // DELETE: api/Calculadora/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calculadora>> DeleteCalculadora(int id)
        {
            var calculadora = await _context.Calculadora.FindAsync(id);
            if (calculadora == null)
            {
                return NotFound();
            }

            _context.Calculadora.Remove(calculadora);
            await _context.SaveChangesAsync();

            return calculadora;
        }

        private bool CalculadoraExists(int id)
        {
            return _context.Calculadora.Any(e => e.IdOperacion == id);
        }
    }
}
