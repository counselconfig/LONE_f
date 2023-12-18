using System.Net.Http.Headers;
using System.Net;
using LONE.Services.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using LONE.Models;
using System.Diagnostics;
namespace LONE.Services.Impl
{
    public class PayUkService : IPayUkService
    {
        //access email service config
        private readonly IConfiguration _configuration;
        public PayUkService(IConfiguration configuration)
        {
            this._configuration = configuration;  
        }

        private static string ServiceUrl { get; } = "https://publicapi.payments.service.gov.uk/v1/payments";
        private static readonly HttpClient HttpClient = new HttpClient();
        public async Task<PaymentViewModel> CreateNewPayment(CreatePaymentViewModel payment)
        {
            var url = $"{ServiceUrl}";
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["ApiKey"]);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var response = await HttpClient.PostAsJsonAsync(url, payment))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PaymentViewModel>(); //httpcontent does not contain a defintion for ReadAsSync error install Microsoft.AspNet.WebApi.Client package
                }
                else
                {
                    throw new Exception($"error ocurred while creating a new payment:{url}||{response.ReasonPhrase}");
                }
            }
        }
        public async Task<PaymentViewModel> GetPaymentById(string paymentId)
        {
            var url = $"{ServiceUrl}/{paymentId}";
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["ApiKey"]);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var response = await HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PaymentViewModel>();
                }
                else
                {
                    throw new Exception($"error ocurred while returning a payment object by paymentId:{paymentId}||{response.ReasonPhrase}");
                }
            }
        }
    }
}