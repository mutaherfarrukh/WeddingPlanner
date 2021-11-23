using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class User
    {
    [Key]
    public int UserId {get;set;}
    
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "You need to add a first name!")]
    [MinLength(2, ErrorMessage = "You need to add a first name with at least 2 letters!")]
    public string FirstName {get;set;}

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "You need to add a last name!")]
    [MinLength(2, ErrorMessage = "You need to add a last name with at least 2 letters!")]
    public string LastName {get;set;}

    // [Display(Name = "Your Birthday")]
    // [Required(ErrorMessage = "You need to add a birthday!")]
    // [DataType(DataType.Date)]
    // public DateTime? Birthday {get;set;}

    [Display(Name = "Email")]
    [Required(ErrorMessage = "You need to add an email!")]
    // [Required(String =".com")]
    [MinLength(5, ErrorMessage = "You need to add an email with at least 5 letters!")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email {get;set;}

    [Display(Name = "Password")]
    [Required(ErrorMessage = "You need to add a password!")]
    [MinLength(4, ErrorMessage = "You need to add a password with at least 4 letters!")]
    [DataType(DataType.Password)]
    public string Password {get;set;}

    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "You need to add a confirmation password!")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Both Passwords need to match!")]
    [NotMapped]
    public string Confirm {get;set;}


    public List<RSVP> Attending {get;set;}
    public List<Wedding> WeddingsPlanned {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}