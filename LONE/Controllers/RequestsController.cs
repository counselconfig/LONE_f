using LONE.Models;
using LONE.Utils;
using Microsoft.AspNetCore.Mvc;
using Request = LONE.Entities.Request;
using LONE.Services.Impl;
using LONE.Entities;
using LONE.Services.Email;
using LONE.Services.Identification;
using System.Xml.Serialization;
using System.Xml;

namespace LONE.Controllers
{
    static class GuidReference
    {
        public static Guid guid;
    }

    public class RequestsController : Controller
    {
        private readonly LONEDbContext _loneDbContext;
        private readonly PayUkService _payUkService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _configuration;
        public RequestsController(LONEDbContext loneDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            this._loneDbContext = loneDbContext;
            _payUkService = new PayUkService(_configuration);
            this._httpContextAccessor = httpContextAccessor;
        }

        public ActionResult Index()
        {
            return View("AncestorInfo");
        }
        private Request GetRequest()
        {
            if (HttpContext.Session.GetObject<Request>("FormObject") == null)
            {
                HttpContext.Session.SetObject("FormObject", new Request());
            }
            return (Request)HttpContext.Session.GetObject<Request>("FormObject");
        }
        private void RemoveRequest()
        {
            HttpContext.Session.SetObject("FormObject", null);
        }

        string TNARef = IdGenerator.TNAReferenceNumber();

        [HttpPost]
        public ActionResult AncestorInfo(AncestorViewModel ancestor, string btnNext)
        {
            if (btnNext != null)
            {
                if (ModelState.IsValid)
                {
                    Request request = GetRequest();
                    request.subject_forename = ancestor.subject_forename;
                    request.subject_surname = ancestor.subject_surname;
                    request.other_forename = ancestor.other_forename;
                    request.other_surname = ancestor.other_surname;
                    request.birth_date = ancestor.birth_date;
                    request.death_date = ancestor.death_date;
                    request.country_of_birth = ancestor.country_of_birth;
                    HttpContext.Session.SetObject("FormObject", request);
                    RequestorViewModel info = new RequestorViewModel();
                    info.contact_title = request.contact_title;
                    info.contact_first_name = request.contact_first_name;
                    info.contact_last_name = request.contact_last_name;
                    info.contact_address1 = request.contact_address1;
                    info.contact_address2 = request.contact_address2;
                    info.contact_address_town_city = request.contact_address_town_city;
                    info.contact_address_county = request.contact_address_county;
                    info.contact_address_postcode = request.contact_address_postcode;
                    info.contact_address_country = request.contact_address_country;
                    info.requestor_agent = request.requestor_agent;
                    return View("RequestorInfo", info);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult RequestorInfo(RequestorViewModel requestor, bool requestor_agent, string btnPrevious, string btnNext)
        {
            Request request = GetRequest();
            if (btnPrevious != null)
            {
                AncestorViewModel info = new AncestorViewModel();
                info.subject_forename = request.subject_forename;
                info.subject_surname = request.subject_surname;
                info.other_forename = request.other_forename;
                info.other_surname = request.other_surname;
                info.birth_date = request.birth_date;
                info.death_date = request.death_date;
                info.country_of_birth = request.country_of_birth;
                request.contact_title = requestor.contact_title;
                request.contact_first_name = requestor.contact_first_name;
                request.contact_last_name = requestor.contact_last_name;
                request.contact_address1 = requestor.contact_address1;
                request.contact_address2 = requestor.contact_address2;
                request.contact_address_town_city = requestor.contact_address_town_city;
                request.contact_address_county = requestor.contact_address_county;
                request.contact_address_postcode = requestor.contact_address_postcode;
                request.contact_address_country = requestor.contact_address_country;
                request.requestor_agent = requestor.requestor_agent;
                HttpContext.Session.SetObject("FormObject", request);
                return View("AncestorInfo", info);
            }
            if (btnNext != null)
            {
                if (ModelState.IsValid)
                {
                    request.contact_title = requestor.contact_title;
                    request.contact_first_name = requestor.contact_first_name;
                    request.contact_last_name = requestor.contact_last_name;
                    request.contact_address1 = requestor.contact_address1;
                    request.contact_address2 = requestor.contact_address2;
                    request.contact_address_town_city = requestor.contact_address_town_city;
                    request.contact_address_county = requestor.contact_address_county;
                    request.contact_address_postcode = requestor.contact_address_postcode;
                    request.contact_address_country = requestor.contact_address_country;
                    request.requestor_agent = requestor.requestor_agent;
                }
            }
            if (requestor_agent == true)
            {
                if (ModelState.IsValid)
                {
                    request.contact_title = requestor.contact_title;
                    request.contact_first_name = requestor.contact_first_name;
                    request.contact_last_name = requestor.contact_last_name;
                    request.contact_address1 = requestor.contact_address1;
                    request.contact_address2 = requestor.contact_address2;
                    request.contact_address_town_city = requestor.contact_address_town_city;
                    request.contact_address_county = requestor.contact_address_county;
                    request.contact_address_postcode = requestor.contact_address_postcode;
                    request.contact_address_country = requestor.contact_address_country;
                    request.requestor_agent = requestor.requestor_agent;
                    ViewBag.contact_title = requestor.contact_title;
                    ViewBag.contact_first_name = requestor.contact_first_name;
                    ViewBag.contact_last_name = request.contact_last_name;
                    ViewBag.contact_address1 = request.contact_address1;
                    ViewBag.contact_address2 = request.contact_address2;
                    ViewBag.contact_address_town_city = request.contact_address_town_city;
                    ViewBag.contact_address_county = request.contact_address_county;
                    ViewBag.contact_address_postcode = request.contact_address_postcode;
                    ViewBag.contact_address_country = request.contact_address_country;
                    HttpContext.Session.SetObject("FormObject", request);
                    EmailAddressViewModel info = new EmailAddressViewModel();
                    info.contact_email = request.contact_email;
                    info.contact_email2 = request.contact_email2;
                    return View("EmailAddressInfo", info);
                }
            }
            if (requestor_agent == false)
            {
                if (ModelState.IsValid)
                {
                    request.contact_title = requestor.contact_title;
                    request.contact_first_name = requestor.contact_first_name;
                    request.contact_last_name = requestor.contact_last_name;
                    request.contact_address1 = requestor.contact_address1;
                    request.contact_address2 = requestor.contact_address2;
                    request.contact_address_town_city = requestor.contact_address_town_city;
                    request.contact_address_county = requestor.contact_address_county;
                    request.contact_address_postcode = requestor.contact_address_postcode;
                    request.contact_address_country = requestor.contact_address_country;
                    request.requestor_agent = requestor.requestor_agent;
                    ViewBag.title = requestor.contact_title;
                    ViewBag.contact_first_name = request.contact_first_name;
                    ViewBag.contact_last_name = request.contact_last_name;
                    ViewBag.contact_address1 = request.contact_address1;
                    ViewBag.contact_address2 = request.contact_address2;
                    ViewBag.contact_address_town_city = request.contact_address_town_city;
                    ViewBag.contact_address_county = request.contact_address_county;
                    ViewBag.contact_address_postcode = request.contact_address_postcode;
                    ViewBag.contact_address_country = request.contact_address_country;
                    HttpContext.Session.SetObject("FormObject", request);
                    AgentViewModel info = new AgentViewModel();
                    info.agent_fullname = request.agent_fullname;
                    info.agent_address1 = request.agent_address1;
                    info.agent_contact_address2 = request.agent_contact_address2;
                    info.agent_town = request.agent_town;
                    info.agent_contact_address_county = request.agent_contact_address_county;
                    info.agent_postcode = request.agent_postcode;
                    info.agent_country = request.agent_country;
                    return View("AgentInfo", info);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult AgentInfo(AgentViewModel agent, string btnPrevious, string btnNext)
        {
            Request request = GetRequest();
            if (btnPrevious != null)
            {
                RequestorViewModel info = new RequestorViewModel();
                info.contact_title = request.contact_title;
                info.contact_first_name = request.contact_first_name;
                info.contact_last_name = request.contact_last_name;
                info.contact_address1 = request.contact_address1;
                info.contact_address2 = request.contact_address2;
                info.contact_address_town_city = request.contact_address_town_city;
                info.contact_address_county = request.contact_address_county;
                info.contact_address_postcode = request.contact_address_postcode;
                info.contact_address_country = request.contact_address_country;
                info.requestor_agent = request.requestor_agent;
                request.agent_fullname = agent.agent_fullname;
                request.agent_address1 = agent.agent_address1;
                request.agent_contact_address2 = agent.agent_contact_address2;
                request.agent_town = agent.agent_town;
                request.agent_contact_address_county = agent.agent_contact_address_county;
                request.agent_postcode = agent.agent_postcode;
                request.agent_country = agent.agent_country;
                HttpContext.Session.SetObject("FormObject", request);
                return View("RequestorInfo", info);
            }
            if (btnNext != null)
            {
                if (ModelState.IsValid)
                {
                    request.agent_fullname = agent.agent_fullname;
                    request.agent_address1 = agent.agent_address1;
                    request.agent_contact_address2 = agent.agent_contact_address2;
                    request.agent_town = agent.agent_town;
                    request.agent_contact_address_county = agent.agent_contact_address_county;
                    request.agent_postcode = agent.agent_postcode;
                    request.agent_country = agent.agent_country;
                    ViewBag.agent_fullname = request.agent_fullname;
                    ViewBag.agent_address1 = request.agent_address1;
                    ViewBag.agent_contact_address2 = request.agent_contact_address2;
                    ViewBag.agent_town = request.agent_town;
                    ViewBag.agent_contact_address_county = request.agent_contact_address_county;
                    ViewBag.agent_postcode = request.agent_postcode;
                    ViewBag.agent_country = request.agent_country;
                    HttpContext.Session.SetObject("FormObject", request);
                    EmailAddressViewModel info = new EmailAddressViewModel();
                    info.contact_email = request.contact_email;
                    info.contact_email2 = request.contact_email2;
                    return View("Emailaddress2Info", info);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult EmailAddressInfo(EmailAddressViewModel emailaddress, string btnPrevious, string btnNext)
        {
            Request request = GetRequest();
            if (btnPrevious != null)
            {
                RequestorViewModel info = new RequestorViewModel();
                info.contact_title = request.contact_title;
                info.contact_first_name = request.contact_first_name;
                info.contact_last_name = request.contact_last_name;
                info.contact_address1 = request.contact_address1;
                info.contact_address2 = request.contact_address2;
                info.contact_address_town_city = request.contact_address_town_city;
                info.contact_address_county = request.contact_address_county;
                info.contact_address_postcode = request.contact_address_postcode;
                info.contact_address_country = request.contact_address_country;
                info.requestor_agent = request.requestor_agent;
                request.contact_email = emailaddress.contact_email;
                request.contact_email2 = emailaddress.contact_email2;
                HttpContext.Session.SetObject("FormObject", request);
                return View("RequestorInfo", info);
            }
            if (btnNext != null)
            {
                if (ModelState.IsValid)
                {
                    request.contact_email = emailaddress.contact_email;
                    request.contact_email2 = emailaddress.contact_email2;
                    ViewBag.subject_forename = request.subject_forename;
                    ViewBag.subject_surname = request.subject_surname;
                    ViewBag.other_forename = request.other_forename;
                    ViewBag.other_surname = request.other_surname;
                    ViewBag.birth_date = request.birth_date;
                    ViewBag.death_date = request.death_date;
                    ViewBag.country_of_birth = request.country_of_birth;
                    ViewBag.contact_email = request.contact_email;
                    ViewBag.contact_email2 = request.contact_email2;
                    ViewBag.contact_title = request.contact_title;
                    ViewBag.contact_first_name = request.contact_first_name;
                    ViewBag.contact_last_name = request.contact_last_name;
                    ViewBag.contact_address1 = request.contact_address1;
                    ViewBag.contact_address2 = request.contact_address2;
                    ViewBag.contact_address_town_city = request.contact_address_town_city;
                    ViewBag.contact_address_county = request.contact_address_county;
                    ViewBag.contact_address_postcode = request.contact_address_postcode;
                    ViewBag.contact_address_country = request.contact_address_country;
                    HttpContext.Session.SetObject("FormObject", request);
                    return View("Summary");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Emailcontact_address2Info(EmailAddressViewModel emailaddress, string btnPrevious, string btnNext) //remove "contact_" from the method name?
        {
            Request request = GetRequest();
            if (btnPrevious != null)
            {
                AgentViewModel info = new AgentViewModel();
                info.agent_fullname = request.agent_fullname;
                info.agent_address1 = request.agent_address1;
                info.agent_contact_address2 = request.agent_contact_address2;
                info.agent_town = request.agent_town;
                info.agent_contact_address_county = request.agent_contact_address_county;
                info.agent_postcode = request.agent_postcode;
                info.agent_country = request.agent_country;
                request.contact_email = emailaddress.contact_email;
                request.contact_email2 = emailaddress.contact_email2;
                HttpContext.Session.SetObject("FormObject", request);
                return View("AgentInfo", info);
            }
            if (btnNext != null)
            {
                if (ModelState.IsValid)
                {
                    request.contact_email = emailaddress.contact_email;
                    request.contact_email2 = emailaddress.contact_email2;
                    ViewBag.subject_forename = request.subject_forename;
                    ViewBag.subject_surname = request.subject_surname;
                    ViewBag.other_forename = request.other_forename;
                    ViewBag.other_surname = request.other_surname;
                    ViewBag.birth_date = request.birth_date;
                    ViewBag.death_date = request.death_date;
                    ViewBag.country_of_birth = request.country_of_birth;
                    ViewBag.contact_email = request.contact_email;
                    ViewBag.contact_email2 = request.contact_email2;
                    ViewBag.contact_title = request.contact_title;
                    ViewBag.contact_first_name = request.contact_first_name;
                    ViewBag.contact_last_name = request.contact_last_name;
                    ViewBag.contact_address1 = request.contact_address1;
                    ViewBag.contact_address2 = request.contact_address2;
                    ViewBag.contact_address_town_city = request.contact_address_town_city;
                    ViewBag.contact_address_county = request.contact_address_county;
                    ViewBag.contact_address_postcode = request.contact_address_postcode;
                    ViewBag.contact_address_country = request.contact_address_country;
                    ViewBag.agent_fullname = request.agent_fullname;
                    ViewBag.agent_address1 = request.agent_address1;
                    ViewBag.agent_contact_address2 = request.agent_contact_address2;
                    ViewBag.agent_town = request.agent_town;
                    ViewBag.agent_contact_address_county = request.agent_contact_address_county;
                    ViewBag.agent_postcode = request.agent_postcode;
                    ViewBag.agent_country = request.agent_country;
                    HttpContext.Session.SetObject("FormObject", request);
                    return View("Summary2");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Summary(string btnPrevious, string btnNext)
        {
            Request request = GetRequest();
            if (btnPrevious != null)
            {
                EmailAddressViewModel info = new EmailAddressViewModel();
                info.contact_email = request.contact_email;
                info.contact_email2 = request.contact_email2;
                return View("EmailAddressInfo", info);
            }
            if (btnNext != null)
            {
                ViewBag.contact_email = request.contact_email;
                ViewBag.contact_email2 = request.contact_email2;
                HttpContext.Session.SetObject("FormObject", request);
                _loneDbContext.Requests.Add(request);
                _loneDbContext.SaveChanges();
                GuidReference.guid = request.request_id;
                int cost = int.Parse(_configuration["Cost"]);
                var model = new CreatePaymentViewModel
                {
                    amount = cost,
                    reference = TNARef
                };
                model.description = "Letter of No Evidence Search - " + model.reference;
                model.return_url = "https://localhost:7160/Transaction/" + model.reference;
                var payment = new CreatePaymentViewModel()
                {
                    amount = model.amount,
                    reference = model.reference,
                    description = model.description,
                    return_url = model.return_url,
                };

                PaymentViewModel response = await _payUkService.CreateNewPayment(payment);
                var nexturlLinksVm = new LinksViewModel() { href = response._links.next_url.href, method = response._links.next_url.method };
                var linksVm = new PaymentLinksViewModel() { next_url = nexturlLinksVm };
                var paymentVm = new PaymentViewModel() { _links = linksVm };
                string Reference = response.reference;
                string PaymentID = response.payment_id;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(2d);
                Response.Cookies.Append(Reference, PaymentID, options);
                return Redirect(nexturlLinksVm.href);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Summary2(string btnPrevious, string btnNext)
        {
            Request request = GetRequest();
            if (btnPrevious != null)
            {
                EmailAddressViewModel info = new EmailAddressViewModel();
                info.contact_email = request.contact_email;
                info.contact_email2 = request.contact_email2;
                return View("EmailAddress2Info", info);
            }
            if (btnNext != null)
            {
                HttpContext.Session.SetObject("FormObject", request);
                _loneDbContext.Requests.Add(request);
                _loneDbContext.SaveChanges();
                GuidReference.guid = request.request_id;
                int cost = int.Parse(_configuration["Cost"]);
                var model = new CreatePaymentViewModel
                {
                    amount = cost,
                    reference = TNARef,
                };
                model.description = "Letter of No Evidence Search - " + model.reference;
                model.return_url = "https://localhost:7160/Transaction/" + model.reference;
                var payment = new CreatePaymentViewModel()
                {
                    amount = model.amount,
                    reference = model.reference,
                    description = model.description,
                    return_url = model.return_url,
                };
                PaymentViewModel response = await _payUkService.CreateNewPayment(payment);
                var nexturlLinksVm = new LinksViewModel() { href = response._links.next_url.href, method = response._links.next_url.method };
                var linksVm = new PaymentLinksViewModel() { next_url = nexturlLinksVm };
                var paymentVm = new PaymentViewModel() { _links = linksVm };
                string Reference = response.reference;
                string PaymentID = response.payment_id;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(2d);
                Response.Cookies.Append(Reference, PaymentID, options);
                return Redirect(nexturlLinksVm.href);
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetPaymentStatus(string id)
        {
            string paymentId = null;
            if (Request.Cookies[id] != null)
            {
                paymentId = Request.Cookies[id];
            }
            PaymentViewModel response = null;
            if (paymentId != null)
            {
                response = await _payUkService.GetPaymentById(paymentId);
            }
            var stateVm = new PaymentStateViewModel();
            var paymentVm = new PaymentViewModel();
            if (response != null)
            {
                stateVm.status = response.state.status;
                stateVm.finished = response.state.finished;
                paymentVm.payment_id = response.payment_id;
                paymentVm.state = stateVm;
                paymentVm.amount = Convert.ToDecimal(response.amount) / 100;
                paymentVm.reference = response.reference;
                paymentVm.description = response.description;
                response.created_date = DateTime.Now;
                paymentVm.created_date = response.created_date;
            }
            Payment payment = new Payment()
            {
                request_id = GuidReference.guid,
                enquiry_id = paymentVm.reference,
                payment_reference = paymentVm.payment_id,
                status = stateVm.status,
                finished = stateVm.finished,
                amount_received = paymentVm.amount,
                created_date = paymentVm.created_date,
            };
            _loneDbContext.Payments.Add(payment);
            _loneDbContext.SaveChanges();
            int transactionId = payment.transaction_id;
            Payment result = (from p in _loneDbContext.Payments
                              where p.transaction_id == transactionId
                              select p).SingleOrDefault();
            result.session_id = IdGenerator.GenerateSessionId(transactionId);
            _loneDbContext.SaveChanges();
            Request request = GetRequest();
            string contactEmail = request.contact_email;
            string enquiryId = payment.enquiry_id;
            string contactFirstName = request.contact_first_name;
            string contactLastName = request.contact_last_name;
            string paymentReference = payment.session_id;
            decimal amountReceived = payment.amount_received;
            string createdDate = payment.created_date.ToLongDateString();
            CaseViewModel xmlVm = new CaseViewModel()
            {
                enquiry_id = paymentVm.reference,
                payment_reference = paymentVm.payment_id,
                amount_received = paymentVm.amount,
                subject_forename = request.subject_forename,
                subject_surname = request.subject_surname,
                other_forename = request.other_forename,
                other_surname = request.other_surname,
                birth_date = request.birth_date,
                death_date = request.death_date,
                country_of_birth = request.country_of_birth,
                contact_title = request.contact_title,
                contact_first_name = request.contact_first_name,
                contact_last_name = request.contact_last_name,
                contact_email = request.contact_email,
                contact_address1 = request.contact_address1,
                contact_address2 = request.contact_address2,
                contact_address_town_city = request.contact_address_town_city,
                contact_address_county = request.contact_address_county,
                contact_address_postcode = request.contact_address_postcode,
                contact_address_country = request.contact_address_country,
                agent_fullname = request.agent_fullname,
                agent_address1 = request.agent_address1,
                agent_contact_address2 = request.agent_address1,
                agent_town = request.agent_town,
                agent_contact_address_county = request.agent_contact_address_county,
                agent_postcode = request.agent_postcode,
                agent_country = request.agent_country
            };
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serialiser = new XmlSerializer(typeof(CaseViewModel));
            using (StringWriter textwriter = new StringWriter())
            using (XmlWriter xmlWriter = XmlWriter.Create(textwriter, settings))
            {
                serialiser.Serialize(xmlWriter, xmlVm, emptyNamespaces);
                string xml = textwriter.ToString();
                EmailService emailService = new EmailService(_configuration);
                emailService.Email(contactEmail, enquiryId, contactFirstName, contactLastName, paymentReference, amountReceived, createdDate, xml);
            }
            RemoveRequest();
            return View("Receipt", paymentVm);
        }
    }
}



