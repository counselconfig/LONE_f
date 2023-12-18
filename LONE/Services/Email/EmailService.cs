using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace LONE.Services.Email
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void Email(string contactEmail, string enquiryId, string contactFirstName, string contactLastName, string paymentReference, decimal amountReceived, string createdDate, string xml)
        {
            string host = _configuration["EmailHost"];
            int port = int.Parse(_configuration["Port"]);
            MimeMessage userMessage = new MimeMessage();
            userMessage.From.Add(new MailboxAddress(_configuration["EmailName"], _configuration["EmailFrom"])); //this is "sent as"
            userMessage.To.Add(new MailboxAddress("", contactEmail));
            userMessage.Subject = _configuration["EmailSubject"] + enquiryId + ")";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<p>Dear "+ contactFirstName + " "+ contactLastName + ",</p><p>Your payment was successfully received.</p><p>If you need to get in touch about your request for confirmation of no evidence of British naturalisation, please contact us at&nbsp;ceerequests@nationalarchives.gov.uk.</p><p><br />Payment Summary</p><p>Enquiry reference number:&nbsp"+enquiryId + "</p><p>Transaction reference:&nbsp" + paymentReference + "</p><p>Amount received: " + amountReceived+ " GBP (no VAT added)</pr><p>Date received: " + createdDate +"</p>";
            userMessage.Body = bodyBuilder.ToMessageBody();
            MimeMessage caseMessage = new MimeMessage();
            caseMessage.From.Add(new MailboxAddress(_configuration["EmailName"], _configuration["D365EmailFrom"])); //not sent from the foifees account
            caseMessage.To.Add(new MailboxAddress(_configuration["EmailName"], _configuration["D365EmailTo"]));
            caseMessage.Subject = _configuration["D365Subject"];
            caseMessage.Body = new TextPart(TextFormat.Plain) { Text = xml };
            var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect(host, port, SecureSocketOptions.Auto);
            client.Send(userMessage);
            client.Send(caseMessage);
            client.Disconnect(true);
        }
    }
}
