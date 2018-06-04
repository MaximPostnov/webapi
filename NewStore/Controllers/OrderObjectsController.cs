using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewStore.Models;

namespace NewStore.Controllers
{
    [Produces("application/json")]
    [Route("api/OrderObjects")]
    public class OrderObjectsController : Controller
    {
        private readonly StoreHouseContext _context;

        public OrderObjectsController(StoreHouseContext context)
        {
            _context = context;
        }

        // GET: api/OrderObjects
        [HttpGet]
        public IEnumerable<OrderObject> GetOrderObject()
        {
            return _context.OrderObject
                .Include(obj => obj.Manufacturer)
                .Include(obj => obj.Type)
                ;
        }

        //// GET: api/OrderObjects/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOrderObject([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var orderObject = await _context.OrderObject.SingleOrDefaultAsync(m => m.ObjectId == id);

        //    if (orderObject == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(orderObject);
        //}


        [HttpGet("{id}", Name = "GetObj")]
        public IActionResult GetById(int id)
        {

            var item = _context.OrderObject.FirstOrDefault(t => t.ObjectId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        #region snippet_Create
        [HttpPost]
        public IActionResult Create([FromBody] OrderObject item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.OrderObject.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetObj", new { id = item.ObjectId }, item);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderObject item)
        {
            if (item == null || item.ObjectId != id)
            {
                return BadRequest();
            }

            var todo = _context.OrderObject.FirstOrDefault(t => t.ObjectId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.ObjectId = item.ObjectId;
            todo.Name = item.Name;
            todo.Price = item.Price;
            todo.Availability = item.Availability;
            todo.ManufacturerId = item.ManufacturerId;
            todo.TypeId = item.TypeId;
            todo.Image = item.Image;
            //todo.Pengine = item.Pengine;
            //todo.Punishments = item.Punishments;

            _context.OrderObject.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var todo = _context.OrderObject.FirstOrDefault(t => t.ObjectId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.OrderObject.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion


        //// PUT: api/OrderObjects/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrderObject([FromRoute] int id, [FromBody] OrderObject orderObject)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != orderObject.ObjectId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(orderObject).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderObjectExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/OrderObjects
        //[HttpPost]
        //public async Task<IActionResult> PostOrderObject([FromBody] OrderObject orderObject)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.OrderObject.Add(orderObject);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrderObject", new { id = orderObject.ObjectId }, orderObject);
        //}

        //// DELETE: api/OrderObjects/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrderObject([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var orderObject = await _context.OrderObject.SingleOrDefaultAsync(m => m.ObjectId == id);
        //    if (orderObject == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.OrderObject.Remove(orderObject);
        //    await _context.SaveChangesAsync();

        //    return Ok(orderObject);
        //}

        //private bool OrderObjectExists(int id)
        //{
        //    return _context.OrderObject.Any(e => e.ObjectId == id);
        //}
    }
}