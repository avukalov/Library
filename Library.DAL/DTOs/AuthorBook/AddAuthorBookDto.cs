using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.DTOs.AuthorBook
{
    public class AddAuthorBookDto
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }

        public AddAuthorBookDto(Guid authorId, Guid bookId)
        {
            AuthorId = authorId;
            BookId = bookId;
        }
    }
}
