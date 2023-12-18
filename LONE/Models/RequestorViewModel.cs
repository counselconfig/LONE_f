using System.ComponentModel.DataAnnotations;

namespace LONE.Models
{
    public class RequestorViewModel
    {
        [Display(Name = "Title")]
        public string? contact_title { get; set; }
        [Display(Name = "First Name")]
        public string? contact_first_name{ get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required")]
        public string contact_last_name { get; set; }
        [Display(Name = "Address line 1")]
        [Required(ErrorMessage = "Required")]
        public string contact_address1 { get; set; }
        [Display(Name = "Address line 2")]
        public string? contact_address2 { get; set; }
        [Display(Name = "Town or city")]
        [Required(ErrorMessage = "Required")]
        public string contact_address_town_city { get; set; }
        [Display(Name = "County")]
        public string? contact_address_county { get; set; }
        [Display(Name = "Post Code")]
        [Required(ErrorMessage = "Required")]
        public string contact_address_postcode { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required")]
        public string contact_address_country { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool? requestor_agent { get; set; } = null;
    }
}
