using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Oib { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
