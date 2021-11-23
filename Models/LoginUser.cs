using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class LoginUser
    {
        [Display(Name = "User Email")]
        [Required(ErrorMessage = "You need to add an email!")]
        // [Required(String =".com")]
        [MinLength(5, ErrorMessage = "You need to add an email longer than 4 letters!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string LoginEmail {get;set;}

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "You need to add a password!")]
        [MinLength(4, ErrorMessage = "You need to add a password longer than 3 letters!")]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}
    }
}