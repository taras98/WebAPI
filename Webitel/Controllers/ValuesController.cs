using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webitel.Controllers
{
    public class ValuesController : ApiController
    {
        my_Entities db =new my_Entities();
        // GET api/values
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders;
        }

        // GET api/values/5
        public Order Get(Guid id)
        {
            Order order = db.Orders.Find(id);
            return order;
        }

        // POST api/values
        public void Post([FromBody]Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(Guid id, [FromBody]Order order)
        {
            if (id == order.Id)
            {
                db.Entry(order).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(Guid id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
