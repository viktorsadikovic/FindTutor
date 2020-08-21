using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindTutor.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Display(Name = "Prezime")]
        public string Surname { get; set; }

        [Display(Name = "Telefonski broj")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email adresa")]
        public string Email { get; set; }

        // [Display(Name = "Slika na profil")]
        // public virtual Image ProfilePicture { get; set; }

        [Display(Name = "Omileni oglasi")]
        public virtual List<Announcement> FavoriteAnnouncements { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}