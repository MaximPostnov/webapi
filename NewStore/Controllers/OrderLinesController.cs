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
    [Route("api/OrderLines")]
    public class OrderLinesController : Controller
    {
        private readonly StoreHouseContext _context;

        public OrderLinesController(StoreHouseContext context)
        {
            _context = context;
        }

        // GET: api/OrderLines
        [HttpGet]
        public IEnumerable<OrderLine> GetOrderLine()
        {
            return _context.OrderLine;
        }

        // GET: api/OrderLines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderLine = await _context.OrderLine.SingleOrDefaultAsync(m => m.LineId == id);

            if (orderLine == null)
            {
                return NotFound();
            }

            return Ok(orderLine);
        }

        // PUT: api/OrderLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderLine([FromRoute] int id, [FromBody] OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderLine.LineId)
            {
                return BadRequest();
            }

            _context.Entry(orderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
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

        // POST: api/OrderLines
        [HttpPost]
        public async Task<IActionResult> PostOrderLine([FromBody] OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderLine.Add(orderLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderLine", new { id = orderLine.LineId }, orderLine);
        }

        // DELETE: api/OrderLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderLine = await _context.OrderLine.SingleOrDefaultAsync(m => m.LineId == id);
            if (orderLine == null)
            {
                return NotFound();
            }

            _context.OrderLine.Remove(orderLine);
            await _context.SaveChangesAsync();

            return Ok(orderLine);
        }

        private bool OrderLineExists(int id)
        {
            return _context.OrderLine.Any(e => e.LineId == id);
        }
    }
}