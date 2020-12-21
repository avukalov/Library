using Library.DAL.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.DTOs.Book
{
    public class BookWithAuthorDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public string Genre { get; set; }
        public DateTime Published { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
