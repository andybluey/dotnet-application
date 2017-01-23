using System.ComponentModel.DataAnnotations;
using TrialApplication.Entities;

namespace TrialApplication.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
