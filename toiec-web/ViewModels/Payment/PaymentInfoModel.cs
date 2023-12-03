using System.ComponentModel.DataAnnotations;

namespace toiec_web.ViewModels.Payment;

public class PaymentInfoModel
{
    [Required(ErrorMessage = "UserId is required")]
    public Guid UserId { get; set; }
    public string? PaymentInfo { get; set; }
    [Range(1000, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public double Amount { get; set; }
}