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
using Labb1.Models;

namespace Labb1.Controllers
{
    public class CartItemsController : ApiController
    {
        private CartItemDbContext db = new CartItemDbContext();

        // GET: api/CartItems
        public IQueryable<CartItem> GetCartItems()
        {
            return db.CartItems;
        }

        // GET: api/CartItems/5
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult GetCartItem(int id)
        {

            List<CartItem> cartItems = this.GetListOfItems(id);

            if (cartItems == null)
            {
                return NotFound();
            }

            return Ok(cartItems);
        }

        // PUT: api/CartItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartItem(int id, CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartItem.CartId)
            {
                return BadRequest();
            }

            db.Entry(cartItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
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

        // POST: api/CartItems
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult PostCartItem(CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartItems.Add(cartItem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CartItemExists(cartItem.CartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cartItem.CartId }, cartItem);
        }

        // DELETE: api/CartItems/5
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult DeleteCartItem(int id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            db.CartItems.Remove(cartItem);
            db.SaveChanges();

            return Ok(cartItem);
        }

        public List<CartItem> GetListOfItems(int cartId)
        {
            return
                (from item in db.CartItems
                 where item.CartId == cartId
                 select item).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartItemExists(int id)
        {
            return db.CartItems.Count(e => e.CartId == id) > 0;
        }
    }
}