using System.ComponentModel.DataAnnotations;

namespace LONE.Models
{
    public class EmailAddressViewModel
    {
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [Required(ErrorMessage = "Required")]
        public string contact_email{ get; set; }
        [Display(Name = "Please confirm your email address")]
        [Required(ErrorMessage = "Required")]
        [Compare("contact_email", ErrorMessage = "Both email addresses need to be the same")] //https://www.sensibledev.com/compare-validator-in-mvc/
        public string contact_email2 { get; set; }
    }
}
