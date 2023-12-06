using toiec_web.Models;
using toiec_web.ViewModels.Payment;

namespace toiec_web.Services.IService
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentViewModel>> GetAllPayment();
        Task<IEnumerable<PaymentViewModel>> GetAllPaymentByUserId(string userId);
        Task<string> GetExpireTimeVipStudent(string userId);
        Task<PaymentModel> GetPaymentById(Guid paymentId);
        Task<bool> AddPayment(PaymentModel model);
        Task<bool> DeletePayment(Guid paymentId);
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(Guid idStudent, Guid idPackage, double price);
        Task<MomoExecuteResponseModel> MoMoPaymentExecuteAsync(IQueryCollection collection, Guid idMethod);
    }
}
