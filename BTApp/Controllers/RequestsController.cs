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
    public class RequestsController : ControllerBase
    {
        private readonly BusinessTripContext _context;

        public RequestsController(BusinessTripContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public IEnumerable<Request> GetRequest()
        {
            return _context.Request;
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = await _context.Request.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest([FromRoute] int id, [FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        [HttpPost]
        public async Task<IActionResult> PostRequest([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Request.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.RequestId }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.RequestId == id);
        }
    }
}