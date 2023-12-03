
using toiec_web.Models;
using toiec_web.ViewModels.Payment;

namespace toiec_web.Services.IService;

public interface IMomoService
{
    Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(PaymentInfoModel userId);
    PaymentModel PaymentExecuteAsync(IQueryCollection collection);
}