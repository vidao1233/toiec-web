using toiec_web.Models;
using toiec_web.ViewModels.Payment;

namespace toiec_web.Services.IService
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentModel>> GetAllPayment();
        Task<PaymentModel> GetPaymentById(Guid paymentId);
        Task<bool> AddPayment(PaymentModel model);
        Task<bool> DeletePayment(Guid paymentId);
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(PaymentInfoModel model);
        Task<MomoExecuteResponseModel> MoMoPaymentExecuteAsync(IQueryCollection collection, Guid idMethod);
    }
}
