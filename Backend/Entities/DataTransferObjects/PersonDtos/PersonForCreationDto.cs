using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.PersonDtos
{
    public class PersonForCreationDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Nationality is required")]
        [StringLength(50, ErrorMessage = "Nationality cannot be longer than 50 characters.")]
        public string? Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public int RoleID { get; set; }
    }
}
