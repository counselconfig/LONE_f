namespace LONE.Models
{
    public class CreatePaymentViewModel
    {
        public Int32 amount { get; set; }
        public string reference { get; set; }
        public string description { get; set; }
        public string return_url { get; set; }
    }

    public class PaymentViewModel
    {
        public Decimal amount { get; set; }
        public PaymentStateViewModel state { get; set; }
        public string description { get; set; }
        public string reference { get; set; }
        public string payment_id { get; set; }
        public string payment_provider { get; set; }
        public string return_url { get; set; }
        public DateTime created_date { get; set; }
        public RefundSummaryViewModel refund_summary { get; set; }
        public SettlementSummaryViewModel settlement_summary { get; set; }
        public PaymentLinksViewModel _links { get; set; }
    }

    public class PaymentStateViewModel
    {
        public string status { get; set; }
        public bool finished { get; set; }
    }

    public class RefundSummaryViewModel
    {
        public string status { get; set; }
        public Int32 amount_available { get; set; }
        public Int32 amount_submitted { get; set; }

    }

    public class SettlementSummaryViewModel
    {
        public string status { get; set; }
    }

    public class PaymentLinksViewModel
    {
        public LinksViewModel self { get; set; }
        public LinksViewModel next_url { get; set; }
        public NextUrlPostLinksViewModel next_url_post { get; set; }
        public LinksViewModel events { get; set; }
        public LinksViewModel refunds { get; set; }
        public LinksViewModel cancel { get; set; }
    }

    public class LinksViewModel
    {
        public string href { get; set; }
        public string method { get; set; }
    }

    public class NextUrlPostLinksViewModel
    {
        public string type { get; set; }
        public ParamsViewModel @params { get; set; }
        public string href { get; set; }
        public string method { get; set; }
    }

    public class ParamsViewModel
    {
        public string chargeTokenId { get; set; }
    }
}
