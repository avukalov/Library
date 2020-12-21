﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.DTOs.Author
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }
}
