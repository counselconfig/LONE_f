using System.ComponentModel.DataAnnotations;

namespace LONE.Models
{
    public class AgentViewModel
    {
        [Display(Name = "Full name")]
        public string? agent_fullname { get; set; }
        [Display(Name = "Address line 1")]
        [Required(ErrorMessage = "Required")]
        public string? agent_address1 { get; set; }
        [Display(Name = "Address line 2")]
        [Required(ErrorMessage = "Required")]
        public string? agent_contact_address2 { get; set; }
        [Display(Name = "Town or city")]
        [Required(ErrorMessage = "Required")]
        public string? agent_town { get; set; }
        [Display(Name = "County")]
        [Required(ErrorMessage = "Required")]
        public string? agent_contact_address_county { get; set; }
        [Display(Name = "Postcode")]
        [Required(ErrorMessage = "Required")]
        public string? agent_postcode { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required")]
        public string? agent_country { get; set; }
    }
}

