using Library.Models.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.DTOs.Book
{
    public class BookWithAuthorDto : BookBaseDto
    {
        public Guid Id { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
