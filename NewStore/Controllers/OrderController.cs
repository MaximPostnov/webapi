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
    [Route("api/Order")]
    public class OrderController : Controller
    {
        //// GET: api/Order
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        private readonly StoreHouseContext _context;

        public OrderController(StoreHouseContext context)
        {
            _context = context;
        }

        // GET: api/OrderObjects
        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            return _context.Order
                .Include(obj => obj.OrderLine)
                ;
                //.Include(obj => obj.Manufacturer)
                //.Include(obj => obj.Type)
                //;
        }

        //GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetById(string id)
        {
            List<Order> item = new List<Order>();
            _context.Order.Load();
            foreach(Order od in _context.Order.Include(obj => obj.OrderLine))
            {
                if (od.UserId == id)
                {
                    item.Add(od);
                }
            }
            if (item.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        //b4bd6f72-4954-4a61-a0c8-f1da820f9c1d 23
        //ee723a5c-4f3d-4c96-8fc9-19961257d1af
        #region snippet_Create
        [HttpPost("{id}", Name = "CreateOrder")]
        public IActionResult Create(string id)
        {
            string s = "ee723a5c-4f3d-4c96-8fc9-19961257d1af";
            int co = s.Length;
            char[] UsIdCH = new char[co];
            for (int i = 0; i < co; i++)
                UsIdCH[i] = id[i];
            string UsId = new string(UsIdCH);

            char[] GoodIdStrCH = new char[id.Length - co]; ;

            for (int i = co; i < id.Length; i++)
                GoodIdStrCH[i - co] = id[i];

            string GoodIdStr = new string(GoodIdStrCH);

            int GoodId = Int32.Parse(GoodIdStr);

            //Order Norder = new Order();
            //Norder.Date = DateTime.Today;
            //Norder.SoldOut = false;
            //Norder.UserId = UsId;
            //_context.Order.Add(Norder);

            //_context.SaveChanges();
            //return new NoContentResult();




            _context.Order.Load();
            foreach (Order od in _context.Order.Include(obj => obj.OrderLine))
            {
                if (od.UserId == UsId)
                {
                    if (!od.SoldOut)
                    {
                        foreach (OrderLine line in od.OrderLine)
                            if (line.ObjectId == GoodId)
                            {
                                var NLiine = _context.OrderLine.FirstOrDefault(t => t.LineId == line.LineId);
                                double price = NLiine.Price / NLiine.Amount;
                                NLiine.Amount++;
                                NLiine.Price += price;
                                _context.OrderLine.Update(NLiine);
                                _context.SaveChanges();
                                return new NoContentResult();
                            }


                        var good = _context.OrderObject.FirstOrDefault(t => t.ObjectId == GoodId);

                        OrderLine Nline = new OrderLine();
                        Nline.Amount = 1;
                        Nline.ObjectId = GoodId;
                        Nline.OrderId = od.OrderId;
                        Nline.Price = good.Price;

                        _context.OrderLine.Add(Nline);
                        _context.SaveChanges();
                        return new NoContentResult();
                    }
                }
            }

            Order Norder = new Order();
            Norder.Date = DateTime.Today;
            Norder.SoldOut = false;
            Norder.UserId = UsId;
            _context.Order.Add(Norder);
            _context.SaveChanges();


            _context.Order.Load();
            foreach (Order od in _context.Order.Include(obj => obj.OrderLine))
            {
                if (od.UserId == UsId)
                {
                    if (!od.SoldOut)
                    {
                        foreach (OrderLine line in od.OrderLine)
                            if (line.ObjectId == GoodId)
                            {
                                var NLiine = _context.OrderLine.FirstOrDefault(t => t.LineId == line.LineId);
                                double price = NLiine.Price / NLiine.Amount;
                                NLiine.Amount++;
                                NLiine.Price += price;
                                _context.OrderLine.Update(NLiine);
                                _context.SaveChanges();
                                return new NoContentResult();
                            }
                        var good = _context.OrderObject.FirstOrDefault(t => t.ObjectId == GoodId);

                        OrderLine Nline = new OrderLine();
                        Nline.Amount = 1;
                        Nline.ObjectId = GoodId;
                        Nline.OrderId = od.OrderId;
                        Nline.Price = good.Price;

                        _context.OrderLine.Add(Nline);
                        _context.SaveChanges();
                        return new NoContentResult();
                    }
                }
            }
            return new NoContentResult();
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order item)
        {
            if (item == null || item.OrderId != id)
            {
                return BadRequest();
            }

            var todo = _context.Order.FirstOrDefault(t => t.OrderId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.OrderId = item.OrderId;
            todo.OrderLine = item.OrderLine;
            todo.SoldOut = item.SoldOut;
            todo.Date = item.Date;
            todo.User = item.User;
            todo.UserId = item.UserId;

            _context.Order.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var todo = _context.Order.FirstOrDefault(t => t.OrderId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Order.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion
    }
}