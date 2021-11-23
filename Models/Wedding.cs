using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingID { get; set; }

        [Required(ErrorMessage = "You need to add a Wedder's First Name!")]
        [Display(Name = "First Name of Wedder")]
        public string Wedder1 { get; set; }

        [Required(ErrorMessage = "You need to add a Wedder's Second Name!")]
        [Display(Name = "Second Name of Wedder")]
        public string Wedder2 { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime WeddingDate {get;set;}

        // public int RSVPID { get; set; }//This is not needed, right?
        public List<RSVP> Guests { get; set; }

        public int UserID { get; set; }
        public User Planner { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}