using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.DTOs.Book
{
    public abstract class BookBaseDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Language { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 13)]
        public string ISBN { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Category { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Genre { get; set; }
        
        [StringLength(100, MinimumLength = 1)]
        public string Publisher { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Published { get; set; }
    }
}
