using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.Entities
{
    public class AuthorBookEntity : BaseEntity
    {
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }

        public Guid AuthorId { get; set; }
        public AuthorEntity Author { get; set; }

    }
}
