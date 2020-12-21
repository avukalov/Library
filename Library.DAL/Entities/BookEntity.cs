using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.DAL.Entities
{
    [Table("Book")]
    public class BookEntity : BaseEntity
    {
        [Key]
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; } = "uncategorized";
        public string Genre { get; set; }
        [DataType(DataType.Date)]
        public DateTime Published { get; set; }

        public List<AuthorBookEntity> BookAuthors { get; set; }
    }
}