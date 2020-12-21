using Library.DAL.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.DTOs.Author
{
    public class AuthorWithBooksDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
