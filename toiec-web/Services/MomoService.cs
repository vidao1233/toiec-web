using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using toiec_web.Helper;
using toiec_web.Models;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Payment;

namespace toiec_web.Services;

public class MomoService : IMomoService
{
    private readonly IOptions<MomoOptionModel> _options;

    public MomoService(IOptions<MomoOptionModel> options)
    {
        _options = options;
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
        client.BaseAddress  = new Uri(_options.Value.MomoApiUrl);
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

    public PaymentModel  PaymentExecuteAsync(IQueryCollection collection)
    {
        var amount = collection.First(s => s.Key == "amount").Value;
        var orderInfo = collection.First(s => s.Key == "orderInfo").Value;
        string orderId = collection.First(s => s.Key == "orderId").Value;
        string extraData = collection.First(s => s.Key == "extraData").Value;
        Guid studentId = Guid.Parse(extraData);
        var message = collection.First(s => s.Key == "message").Value;

        return new PaymentModel()
        {
            idPayment = Guid.NewGuid(),
            idStudent = studentId,
            paymentAmount = Double.Parse(amount),
            idMethod = studentId,
            message = message,
            paymentDate = DateTime.Now,
        };
    }
}