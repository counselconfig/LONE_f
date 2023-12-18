using LONE.Models;

namespace LONE.Services.Interface
{
    public interface IPayUkService
    {
        Task<PaymentViewModel> CreateNewPayment(CreatePaymentViewModel payment);
        Task<PaymentViewModel> GetPaymentById(string paymentId);
    }
}
