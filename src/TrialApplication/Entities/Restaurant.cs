﻿using System.ComponentModel.DataAnnotations;

namespace TrialApplication.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        French,
        Japanese,
        Indonesian
    }

    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
