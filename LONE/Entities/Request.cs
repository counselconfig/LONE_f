using System.ComponentModel.DataAnnotations;

namespace LONE.Entities
{
    public class Request
    {
        [Key]
        public Guid request_id { get; set; }
        public string subject_forename { get; set; }
        public string subject_surname { get; set; }
        public string? other_forename { get; set; }
        public string? other_surname { get; set; }
        public string birth_date { get; set; }
        public string? death_date { get; set; }
        public string? country_of_birth { get; set; }
        public string? contact_title { get; set; }
        public string? contact_first_name { get; set; }
        public string contact_last_name { get; set; }
        public string contact_email { get; set; }
        public string contact_email2 { get; set; }
        public string contact_address1 { get; set; }
        public string? contact_address2 { get; set; }
        public string contact_address_town_city { get; set; }
        public string? contact_address_county { get; set; }
        public string contact_address_postcode { get; set; }
        public string contact_address_country { get; set; }
        public bool? requestor_agent { get; set; }
        public string? agent_fullname { get; set; }
        public string? agent_address1 { get; set; }
        public string? agent_contact_address2 { get; set; }
        public string? agent_town { get; set; }
        public string? agent_contact_address_county { get; set; }
        public string? agent_postcode { get; set; }
        public string? agent_country { get; set; }
        public Payment Payment { get; set; }
    }
}
