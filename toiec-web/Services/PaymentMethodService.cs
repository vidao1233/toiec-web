using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddPaymentMethod(PaymentMethodModel model)
        {
            var data = _mapper.Map<PaymentMethodModel>(model);
            return await _paymentMethodRepository.AddPaymentMethod(data);
        }

        public async Task<bool> DeletePaymentMethod(Guid methodId)
        {
            return await _paymentMethodRepository.DeletePaymentMethod(methodId);
        }

        public async Task<IEnumerable<PaymentMethodModel>> GetAllPaymentMethods()
        {
            var data = await _paymentMethodRepository.GetAllPaymentMethods();
            List<PaymentMethodModel> listData = new List<PaymentMethodModel>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<PaymentMethodModel>(item);
                    listData.Add(obj);
                }
                return listData;
            }
            return null;
        }

        public async Task<PaymentMethodModel> GetPaymentMethodById(Guid methodId)
        {
            var data = await _paymentMethodRepository.GetPaymentMethodById(methodId);
            if (data != null)
            {
                var obj = _mapper.Map<PaymentMethodModel>(data);
                return obj;
            }
            return null;
        }

    }
}
