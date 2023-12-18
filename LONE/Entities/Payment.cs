using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LONE.Entities
{
    public class Payment
    {
        [Key]
        public string enquiry_id { get; set; }
        [ForeignKey("Request")]
        public Guid request_id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transaction_id { get; set; }
        public string session_id { get; set; }
        public String payment_reference { get; set; }
        public string status { get; set; }
        public bool finished { get; set; }
        public DateTime created_date { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal amount_received { get; set; }
        public Request Request { get; set; }
    }
}
