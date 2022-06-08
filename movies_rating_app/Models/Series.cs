﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRatingApp.API.Models
{
    public class Series
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string? Title { get; set; }
        [Range(1800,2100)]
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }
        [Range(1800, 2100)]
        [Display(Name = "End Year")]
        public int EndYear { get; set; }

        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<MoviePerson> MoviePeople { get; set; }
        


    }
}