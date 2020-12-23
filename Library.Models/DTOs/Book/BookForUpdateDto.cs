using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.DTOs.Book
{
    public class BookForUpdateDto : BookBaseDto
    {
        [Required]
        public Guid AuthorId { get; set; }
    }
}
