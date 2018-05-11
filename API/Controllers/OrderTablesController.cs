using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class OrderTablesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/OrderTables
        public IQueryable<OrderTable> GetOrderTables()
        {
            return db.OrderTables;
        }

        // GET: api/OrderTables/5
        [ResponseType(typeof(OrderTable))]
        public IHttpActionResult GetOrderTable(string id)
        {
            OrderTable orderTable = db.OrderTables.Find(id);
            if (orderTable == null)
            {
                return NotFound();
            }

            return Ok(orderTable);
        }

        // PUT: api/OrderTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderTable(string id, OrderTable orderTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderTable.OrderDate)
            {
                return BadRequest();
            }

            db.Entry(orderTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTableExists(id))
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

        // POST: api/OrderTables
        [ResponseType(typeof(OrderTable))]
        public IHttpActionResult PostOrderTable(OrderTable orderTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderTables.Add(orderTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderTableExists(orderTable.OrderDate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderTable.OrderDate }, orderTable);
        }

        // DELETE: api/OrderTables/5
        [ResponseType(typeof(OrderTable))]
        public IHttpActionResult DeleteOrderTable(string id)
        {
            OrderTable orderTable = db.OrderTables.Find(id);
            if (orderTable == null)
            {
                return NotFound();
            }

            db.OrderTables.Remove(orderTable);
            db.SaveChanges();

            return Ok(orderTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderTableExists(string id)
        {
            return db.OrderTables.Count(e => e.OrderDate == id) > 0;
        }
    }
}