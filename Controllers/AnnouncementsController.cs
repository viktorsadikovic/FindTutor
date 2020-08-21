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
using System.Web.Mvc;
using FindTutor.Models;
using Microsoft.Ajax.Utilities;

namespace FindTutor.Controllers
{
    public class AnnouncementsController : ApiController
    {
        private DatabaseDB db = new DatabaseDB();

        // GET: api/Announcements
        public IQueryable<Announcement> GetAnnouncements()
        {
            return db.Announcements;
        }

        // GET: api/Announcements/5
        [ResponseType(typeof(Announcement))]
        public IHttpActionResult GetAnnouncement(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        // PUT: api/Announcements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnnouncement(int id, Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != announcement.Id)
            {
                return BadRequest();
            }

            db.Entry(announcement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                
                Announcement updatedAnnouncement = db.Announcements.Find(id);

                updatedAnnouncement.Tutor.PrivateLessons.ForEach(lesson =>
                {
                    if (lesson.Id == id)
                    {
                        lesson = updatedAnnouncement;
                    }
                });

                db.Customers.ToList().ForEach(customer =>
                {
                    customer.FavoriteAnnouncements.ForEach(a =>
                    {
                        if (a.Id == id)
                        {
                            a = updatedAnnouncement;
                        }
                    });
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnouncementExists(id))
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

        // POST: api/Announcements
        [ResponseType(typeof(Announcement))]
        public IHttpActionResult PostAnnouncement(Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            announcement.Tutor.PrivateLessons.Add(announcement);
            db.Announcements.Add(announcement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = announcement.Id }, announcement);
        }

        // DELETE: api/Announcements/5
        [ResponseType(typeof(Announcement))]
        public IHttpActionResult DeleteAnnouncement(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return NotFound();
            }

            announcement.Tutor.PrivateLessons.Remove(announcement);

            db.Customers.ToList().ForEach(customer =>
            {
                customer.FavoriteAnnouncements.ForEach(a =>
                {
                    if (a.Id == id)
                    {
                        customer.FavoriteAnnouncements.Remove(a);
                    }
                });
            });

            var controller = new ReviewsController();

            db.Reviews.ToList().ForEach(review =>
            {
                if (review.PrivateLesson.Id == id)
                {
                    controller.DeleteReview(review.Id);
                }
            });

            db.Announcements.Remove(announcement);
            db.SaveChanges();

            return Ok(announcement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnouncementExists(int id)
        {
            return db.Announcements.Count(e => e.Id == id) > 0;
        }
    }
}