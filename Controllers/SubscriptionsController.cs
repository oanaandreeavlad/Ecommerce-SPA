using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LandingSPA.Models;
using LandingSPA.SqlViewModels;
using LandingSPA.ValueObjects;

namespace LandingSPA.Controllers
{
    public class SubscriptionsController : ApiController
    {
        private LandingSPAContext db = new LandingSPAContext();


        // GET: api/Subscriptions/Types
        [Route("api/Subscriptions/Types")]
        [HttpGet]
        public IQueryable<SubscriptionTypeModel> GetTypes()
        {
            return db.SubscriptionTypes
                .OrderBy(x => x.Type)
                .Select(x => new SubscriptionTypeModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            ImageSource = x.ImageSource
                        });
        }

        // GET: api/Subscriptions
        public IQueryable<SubscriptionModel> GetSubscriptions()
        {
            return db.Subscriptions.Select(x =>
            new SubscriptionModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                SubscriptionType = x.SubscriptionType
            });
        }

        // GET: api/Subscriptions?type={0}
        public IQueryable<SubscriptionModel> GetSubscriptionsByType(SubscriptionType type)
        {
            var results =  db.Subscriptions.Where(x => x.SubscriptionType == type)
            .SelectMany(x => x.PricingPlans)
            .Select(x => 
            new SubscriptionModel { 
            Id = x.Subscription.Id,
            Name = x.Subscription.Name,
            Description = x.Subscription.Description,
            SubscriptionType = x.Subscription.SubscriptionType,
            Price = x.Price,
            SubscriptionDuration = x.SubscriptionDuration
            });

            return results;
        }

        #region Unused Endpoints
        // GET: api/Subscriptions/5
        /*
        [ResponseType(typeof(Subscription))]
        public async Task<IHttpActionResult> GetSubscription(Guid id)
        {
            Subscription subscription = await db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        // PUT: api/Subscriptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubscription(Guid id, Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscription.Id)
            {
                return BadRequest();
            }

            db.Entry(subscription).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
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

        // POST: api/Subscriptions
        [ResponseType(typeof(Subscription))]
        public async Task<IHttpActionResult> PostSubscription(Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscriptions.Add(subscription);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscriptionExists(subscription.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subscription.Id }, subscription);
        }

        // DELETE: api/Subscriptions/5
        [ResponseType(typeof(Subscription))]
        public async Task<IHttpActionResult> DeleteSubscription(Guid id)
        {
            Subscription subscription = await db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            db.Subscriptions.Remove(subscription);
            await db.SaveChangesAsync();

            return Ok(subscription);
        }

        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriptionExists(Guid id)
        {
            return db.Subscriptions.Count(e => e.Id == id) > 0;
        }

        #endregion
    }
}