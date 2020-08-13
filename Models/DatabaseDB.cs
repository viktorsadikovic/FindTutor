using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FindTutor.Models
{
    public class DatabaseDB : DbContext
    {
        public DbSet<Customer> Customers;
        public DbSet<Announcement> Announcements;
        public DbSet<Review> Reviews;
        public DbSet<Tutor> Tutors;


        public DatabaseDB()
        {
        }

        public static DatabaseDB Create()
        {
            return new DatabaseDB();
        }

    }
}