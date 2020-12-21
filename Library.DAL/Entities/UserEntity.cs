using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.DAL.Entities
{
    public class UserEntity : IdentityUser<Guid>, IEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Oib { get; set; }
        public DateTime JoinDate { get; set; }
       

        //public ICollection<Borrowment> Borrowments { get; set; }

    }
}