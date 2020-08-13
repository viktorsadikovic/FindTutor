using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindTutor.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Podnositel")]
        public virtual Customer Submitter { get; set; }

        [Display(Name = "Oglas za koj se podnesuva procenka")]
        public virtual Announcement PrivateLesson { get; set; }

        [Display(Name = "Podnositel na oglasot")]
        public virtual Tutor Tutor { get; set; }

        [Range(1, 5)]
        public int Score { get; set; }

        [Display(Name = "Kratok komentar")]
        public string Reason { get; set; }
    }
}