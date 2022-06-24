using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.RoleDtos
{
    public class RoleForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Role name cannot be longer than 50 characters.")]
        public string? Name { get; set; }
    }
}
