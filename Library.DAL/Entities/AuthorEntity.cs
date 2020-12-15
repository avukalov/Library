using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Entities
{
    public class AuthorEntity
    {
        [Key]
        public Guid AuthorID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstame can't be longer then 50 characters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname can't be longer then 50 characters")]
        public string LastName { get; set; }

        public string Nationality { get; set; } = "unknown";

        public ICollection<BookEntity> Books { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
    }
}