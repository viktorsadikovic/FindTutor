using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindTutor.Models
{
    public class Tutor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Display(Name = "Prezime")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Telefonski broj")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email adresa")]
        public string Email { get; set; }

        [Display(Name = "Licen opis")]
        public string Bio { get; set; }

        [Display(Name = "Profesionalno zanimanje")]
        public string Job { get; set; }

        // [Display(Name = "Slika na profil")]
        // public virtual Image ProfilePicture { get; set; }

        public float Score { get; set; }

        public virtual List<Announcement> PrivateLessons { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public Tutor()
        {
            Score = 0;
            PrivateLessons = new List<Announcement>();
            Reviews = new List<Review>();
        }
    }
}