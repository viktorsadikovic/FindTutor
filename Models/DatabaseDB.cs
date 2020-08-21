using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FindTutor.Models
{
    public class DatabaseDB : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        public DatabaseDB()
        {

        }

        public static DatabaseDB Create()
        {
            return new DatabaseDB();
        }
    }
}