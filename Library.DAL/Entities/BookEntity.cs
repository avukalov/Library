using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.DAL.Entities
{
    [Table("Book")]
    public class BookEntity
    {
        [Key]
        public Guid BookID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        public string Category { get; set; } = "uncategorized";

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseYear { get; set; }

        [ForeignKey(nameof(AuthorEntity))]
        public Guid AuthorID { get; set; }
        public AuthorEntity Author { get; set; }
    }
}