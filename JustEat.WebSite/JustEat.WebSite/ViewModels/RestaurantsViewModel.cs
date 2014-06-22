namespace JustEat.WebSite.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RestaurantsViewModel
    {
        [Required(ErrorMessage = "Outcode is required.")]
        public string Outcode { get; set; }

        public IEnumerable<RestaurantViewModel> Restaurants { get; set; }

        public string Error { get; set; }
    }
}