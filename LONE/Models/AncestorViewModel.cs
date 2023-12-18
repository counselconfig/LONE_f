using System.ComponentModel.DataAnnotations;

namespace LONE.Models
{
    public class AncestorViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Required")]
        public string subject_forename { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Required")]
        public string subject_surname { get; set; }
        [Display(Name = "Alternative first name")]
        public string? other_forename { get; set; }
        [Display(Name = "Alternative last name")]
        public string? other_surname { get; set; }
        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Required")]
        public string birth_date { get; set; }
        [Display(Name = "Date of death")]
        public string? death_date { get; set; }
        [Display(Name = "Country of birth")]
        public string? country_of_birth { get; set; }

    }
}
