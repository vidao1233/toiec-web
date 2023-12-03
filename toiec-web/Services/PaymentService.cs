using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using toiec_web.Helper;
using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Payment;

namespace toiec_web.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<MomoOptionModel> _options;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IOptions<MomoOptionModel> options)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _options = options;
        }
        public async Task<bool> AddPayment(PaymentModel model)
        {
            return await _paymentRepository.AddPayment(model);
        }

        public Task<bool> DeletePayment(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentModel>> GetAllPayment()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentModel> GetPaymentById(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        public async Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(PaymentInfoModel model)
        {
            string orderId = DateTime.UtcNow.Ticks.ToString();
            var rawData =
                $"partnerCode={_options.Value.PartnerCode}" +
                $"&accessKey={_options.Value.AccessKey}" +
                $"&requestId={orderId}&amount={model.Amount}" +
                $"&orderId={orderId}" +
                $"&orderInfo={model.PaymentInfo}" +
                $"&returnUrl={_options.Value.ReturnUrl}" +
                $"&notifyUrl={_options.Value.NotifyUrl}" +
                $"&extraData={model.studentId}";

            var signature = HashHelper.ComputeHmacSha256(rawData, _options.Value.SecretKey);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_options.Value.MomoApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Create an object representing the request data
            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = _options.Value.ReturnUrl,
                orderId = orderId,
                amount = model.Amount.ToString(),
                orderInfo = model.PaymentInfo,
                requestId = orderId,
                extraData = model.studentId,
                signature = signature
            };
            Console.WriteLine(_options.Value.MomoApiUrl);
            // Gửi request và xử lý phản hồi
            HttpResponseMessage response = await client.PostAsJsonAsync(_options.Value.MomoApiUrl, requestData);

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return JsonConvert.DeserializeObject<MomoCreatePaymentResponseModel>(responseBody);
        }

        public async Task<MomoExecuteResponseModel> MoMoPaymentExecuteAsync(IQueryCollection collection, Guid paymentMethodId)
        {
            var amount = collection.First(s => s.Key == "amount").Value;
            var orderInfo = collection.First(s => s.Key == "orderInfo").Value;
            var orderId = collection.First(s => s.Key == "orderId").Value;
            var extraData = collection.First(s => s.Key == "extraData").Value;
            var message = collection.First(s => s.Key == "message").Value;
            var errorCode = collection.First(s => s.Key == "errorCode").Value;
            Guid studentId = Guid.Parse(extraData);
            Console.WriteLine("check: ------------"+paymentMethodId);
            PaymentModel payment = new PaymentModel()
            {
                idPayment = Guid.NewGuid(),
                idMethod = paymentMethodId,
                idStudent = studentId,
                message = message,
                paymentDate = DateTime.Now,
                paymentAmount = Double.Parse(amount),
            };
            if (errorCode == "42")
            {
                return new MomoExecuteResponseModel()
                {
                    StudentId = studentId,
                    Amount = amount,
                    Message = "Thanh toán không thành công, giao dịch bị hủy!",
                    PaymentInfo = orderInfo,
                };
            } 
            else
                if(await _paymentRepository.AddPayment(payment) == true)
                    {
                        return new MomoExecuteResponseModel()
                        {
                            StudentId = studentId,
                            Amount = amount,
                            Message = "Thanh toán thành công!",
                            PaymentInfo = orderInfo,
                        };
                    }    
            return null;
        }
    }
}
