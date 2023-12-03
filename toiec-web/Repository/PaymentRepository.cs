using toiec_web.Models;
using toiec_web.Infrastructure;
using toiec_web.Repository.IRepository;
using AutoMapper;

namespace toiec_web.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PaymentRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<bool> AddPayment(PaymentModel model)
        {
            try
            {
                var payment = _mapper.Map<Payment>(model);
                payment.idMethod = Guid.NewGuid();
                Entities.Add(payment);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePayment(Guid paymentId)
        {
            var paymentMethod = GetById(paymentId);
            if (paymentMethod == null)
            {
                throw new ArgumentNullException(nameof(paymentMethod));
            }
            Entities.Remove(paymentMethod);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentByStudentId(Guid studentId)
        {
            IAsyncEnumerable<Payment> payments = Entities.AsAsyncEnumerable();
            IEnumerable<PaymentModel> data = null;
            await foreach (var payment in payments)
            {
                if (payment.idStudent == studentId)
                {
                    PaymentModel paymentModel = _mapper.Map<PaymentModel>(payment);
                    data.Append(paymentModel);
                }
            }
            return data;
        }

        public Task<IEnumerable<PaymentModel>> GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentModel> GetPaymentById(Guid paymentId)
        {
            IAsyncEnumerable<Payment> paymentMethods = Entities.AsAsyncEnumerable();
            await foreach (var paymentMethod in paymentMethods)
            {
                if (paymentMethod.idPayment == paymentId)
                {
                    PaymentModel data = _mapper.Map<PaymentModel>(paymentMethod);
                    return data;
                }
            }
            return null;
        }
    }
}
