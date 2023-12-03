using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentModel>> GetAllPayments();
        Task<PaymentModel> GetPaymentById(Guid paymentId);
        Task<IEnumerable<PaymentModel>> GetAllPaymentByStudentId(Guid studentId);
        Task<bool> AddPayment(PaymentModel model);
        Task<bool> DeletePayment(Guid paymentId);
    }
}
