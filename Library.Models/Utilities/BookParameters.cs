using Library.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class BookParameters : QueryStringParameters
    {
        public BookParameters()
        {
            OrderBy = "title";
        }

        public string Title { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public uint MinPublishedYear { get; set; }
        public uint MaxPublishedYear { get; set; } = (uint)DateTime.Now.Year;

        public bool ValidYearRange => MaxPublishedYear > MinPublishedYear;
    }
}
