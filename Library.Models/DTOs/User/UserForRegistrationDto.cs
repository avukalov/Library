using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.DTOs.User
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstame can't be longer then 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname can't be longer then 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username can't be longer then 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Oib is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Oib must contains 11 digits")]
        public string Oib { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}
