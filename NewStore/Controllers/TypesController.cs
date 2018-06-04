using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewStore.Models;

namespace NewStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Types")]
    public class TypesController : Controller
    {
        private readonly StoreHouseContext _context;

        public TypesController(StoreHouseContext context)
        {
            _context = context;
        }

        // GET: api/Types
        [HttpGet]
        public new IEnumerable<Models.Type> GetType()
        {
            return _context.Type;
        }

        // GET: api/Types/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @type = await _context.Type.SingleOrDefaultAsync(m => m.TypeId == id);

            if (@type == null)
            {
                return NotFound();
            }

            return Ok(@type);
        }

        // PUT: api/Types/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType([FromRoute] int id, [FromBody] Models.Type @type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @type.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(@type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        // POST: api/Types
        [HttpPost]
        public async Task<IActionResult> PostType([FromBody] Models.Type @type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Type.Add(@type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = @type.TypeId }, @type);
        }

        // DELETE: api/Types/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @type = await _context.Type.SingleOrDefaultAsync(m => m.TypeId == id);
            if (@type == null)
            {
                return NotFound();
            }

            _context.Type.Remove(@type);
            await _context.SaveChangesAsync();

            return Ok(@type);
        }

        private bool TypeExists(int id)
        {
            return _context.Type.Any(e => e.TypeId == id);
        }
    }
}