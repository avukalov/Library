using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.DTOs.Book
{
    public class BookForUpdateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Publisher must be between 1 and 100 characters")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Language is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Language must be between 1 and 50 characters")]
        public string Language { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "ISBN must be 10 characters")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Language must be between 1 and 50 characters")]
        public string Category { get; set; } = "uncategorized";

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Genre must be between 1 and 50 characters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Published is required")]
        [DataType(DataType.Date)]
        public DateTime Published { get; set; }

        [Required(ErrorMessage = "Book must have an author")]
        public Guid AuthorId { get; set; }
    }
}
