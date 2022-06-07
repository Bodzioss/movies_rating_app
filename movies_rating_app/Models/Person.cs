using System.ComponentModel.DataAnnotations;

namespace MoviesRatingApp.API.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string? LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Nationality cannot be longer than 50 characters.")]
        public string? Nationality { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Day")]
        public DateTime BirthDate { get; set; }
        [Required]
        public int RoleID { get; set; }

    }
}
