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
using FindTutor.Models;

namespace FindTutor.Controllers
{
    public class TutorsController : ApiController
    {
        private DatabaseDB db = new DatabaseDB();

        // GET: api/Tutors
        public IQueryable<Tutor> GetTutors()
        {
            return db.Tutors;
        }

        // GET: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult GetTutor(int id)
        {
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/Tutors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTutor(int id, Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.Id)
            {
                return BadRequest();
            }

            db.Entry(tutor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/Tutors
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tutors.Add(tutor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tutor.Id }, tutor);
        }

        // DELETE: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult DeleteTutor(int id)
        {
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            var controllerA = new AnnouncementsController();

            db.Announcements.ToList().ForEach(announcement =>
            {
                if (announcement.Tutor == tutor)
                {
                    controllerA.DeleteAnnouncement(announcement.Id);
                }
            });

            db.Tutors.Remove(tutor);
            db.SaveChanges();

            return Ok(tutor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorExists(int id)
        {
            return db.Tutors.Count(e => e.Id == id) > 0;
        }
    }
}