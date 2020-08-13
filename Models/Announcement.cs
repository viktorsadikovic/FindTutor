using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FindTutor.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Podnositel")]
        public virtual Tutor Tutor { get; set; }

        [Display(Name = "Oblast")]
        public string Field { get; set; }

        [Required]
        [Display(Name = "Naslov")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Cena")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Tezhina na kurs")]
        public string Difficulty { get; set; }

        [Display(Name = "Kratok opis")]
        public string Description { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public Announcement()
        {
            Score = 0;
        }
    }
}