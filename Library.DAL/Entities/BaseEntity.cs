using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Entities
{
    public abstract class BaseEntity
    {
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        [Timestamp]
        public DateTime UpdatedAt { get; set; }
    }
}
