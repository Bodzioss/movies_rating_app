﻿using System.ComponentModel.DataAnnotations;

namespace MoviesRatingApp.API.Models
{
    public class Episode
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title name cannot be longer than 50 characters.")]
        public string? Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int SeasonID { get; set; }
    }
}
