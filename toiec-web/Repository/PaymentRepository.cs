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
        private readonly IStudentRepository _studentRepository;

        public PaymentRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper
            , IStudentRepository studentRepository) : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public Task<bool> AddPayment(PaymentModel model)
        {
            try
            {
                //var student = await _studentRepository.GetStudentByUserId(userId);
                var payment = _mapper.Map<Payment>(model);

                //payment.idPayment = Guid.NewGuid();
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
            var payment = GetById(paymentId);
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            Entities.Remove(payment);
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

        public async Task<IEnumerable<PaymentModel>> GetAllPayments()
        {
            IAsyncEnumerable<Payment> payments = Entities.AsAsyncEnumerable();
            IEnumerable<PaymentModel> data = null;
            await foreach (var payment in payments)
            {
                PaymentModel paymentModel = _mapper.Map<PaymentModel>(payment);
                data.Append(paymentModel);
            }
            return data;
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
