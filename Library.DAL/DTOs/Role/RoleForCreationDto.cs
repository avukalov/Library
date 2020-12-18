using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.DTOs.Role
{
    public class RoleForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "String must be between 1 and 50 characters")]
        public string Name { get; set; }
    }
}
