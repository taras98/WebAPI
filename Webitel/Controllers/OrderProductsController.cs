﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Webitel;

namespace Webitel.Controllers
{
    public class OrderProductsController : ApiController
    {
        private my_Entities db = new my_Entities();

        // GET: api/OrderProducts
        public IQueryable<OrderProduct> GetOrderProducts()
        {
            return db.OrderProducts;
        }

        // GET: api/OrderProducts/5
        [ResponseType(typeof(OrderProduct))]
        public IHttpActionResult GetOrderProduct(Guid id)
        {
            OrderProduct orderProduct = db.OrderProducts.Find(id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            return Ok(orderProduct);
        }

        // PUT: api/OrderProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderProduct(Guid id, OrderProduct orderProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(orderProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderProducts
        [ResponseType(typeof(OrderProduct))]
        public IHttpActionResult PostOrderProduct(OrderProduct orderProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderProducts.Add(orderProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderProductExists(orderProduct.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderProduct.Id }, orderProduct);
        }

        // DELETE: api/OrderProducts/5
        [ResponseType(typeof(OrderProduct))]
        public IHttpActionResult DeleteOrderProduct(Guid id)
        {
            OrderProduct orderProduct = db.OrderProducts.Find(id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            db.OrderProducts.Remove(orderProduct);
            db.SaveChanges();

            return Ok(orderProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderProductExists(Guid id)
        {
            return db.OrderProducts.Count(e => e.Id == id) > 0;
        }
    }
}