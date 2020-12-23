using Library.Models.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.DTOs.Author
{
    public class AuthorWithBooksDto : AuthorBaseDto
    {
        public Guid Id { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
