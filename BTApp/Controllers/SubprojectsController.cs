using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessTripsBackend.Models;

namespace BusinessTripsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubprojectsController : ControllerBase
    {
        private readonly BusinessTripContext _context;

        public SubprojectsController(BusinessTripContext context)
        {
            _context = context;
        }

        // GET: api/Subprojects
        [HttpGet]
        public IEnumerable<Subproject> GetSubproject()
        {
            return _context.Subproject;
        }

        // GET: api/Subprojects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubproject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subproject = await _context.Subproject.FindAsync(id);

            if (subproject == null)
            {
                return NotFound();
            }

            return Ok(subproject);
        }

        // PUT: api/Subprojects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubproject([FromRoute] int id, [FromBody] Subproject subproject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subproject.Id)
            {
                return BadRequest();
            }

            _context.Entry(subproject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubprojectExists(id))
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

        // POST: api/Subprojects
        [HttpPost]
        public async Task<IActionResult> PostSubproject([FromBody] Subproject subproject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Subproject.Add(subproject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubproject", new { id = subproject.Id }, subproject);
        }

        // DELETE: api/Subprojects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubproject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subproject = await _context.Subproject.FindAsync(id);
            if (subproject == null)
            {
                return NotFound();
            }

            _context.Subproject.Remove(subproject);
            await _context.SaveChangesAsync();

            return Ok(subproject);
        }

        private bool SubprojectExists(int id)
        {
            return _context.Subproject.Any(e => e.Id == id);
        }
    }
}