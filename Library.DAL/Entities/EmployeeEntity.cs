using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Entities
{
    public class EmployeeEntity
    {
        [Key]
        public Guid EmployeeID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstame can't be longer then 50 characters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname can't be longer then 50 characters")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Oib is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Oib must contains 11 digits")]
        public string Oib { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of hire is required")]
        public DateTime HireDate { get; set; }

        //public ICollection<Borrowment> Borrowments { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
    }
}