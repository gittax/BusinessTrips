using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTApp.Models;

namespace BTApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBasesController : ControllerBase
    {
        private readonly BusinessTripContext _context;

        public EmployeeBasesController(BusinessTripContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeBases
        [HttpGet]
        public IEnumerable<EmployeeBase> GetEmployeeBase()
        {
            return _context.EmployeeBase;
        }

        // GET: api/EmployeeBases/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeBase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeBase = await _context.EmployeeBase.FindAsync(id);

            if (employeeBase == null)
            {
                return NotFound();
            }

            return Ok(employeeBase);
        }

        // PUT: api/EmployeeBases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeBase([FromRoute] int id, [FromBody] EmployeeBase employeeBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeBase.EmployeeBaseId)
            {
                return BadRequest();
            }

            _context.Entry(employeeBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeBaseExists(id))
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

        // POST: api/EmployeeBases
        [HttpPost]
        public async Task<IActionResult> PostEmployeeBase([FromBody] EmployeeBase employeeBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeBase.Add(employeeBase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeBase", new { id = employeeBase.EmployeeBaseId }, employeeBase);
        }

        // DELETE: api/EmployeeBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeBase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeBase = await _context.EmployeeBase.FindAsync(id);
            if (employeeBase == null)
            {
                return NotFound();
            }

            _context.EmployeeBase.Remove(employeeBase);
            await _context.SaveChangesAsync();

            return Ok(employeeBase);
        }

        private bool EmployeeBaseExists(int id)
        {
            return _context.EmployeeBase.Any(e => e.EmployeeBaseId == id);
        }
    }
}