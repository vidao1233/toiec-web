using System.ComponentModel.DataAnnotations;

namespace toiec_web.ViewModels.Payment;

public class PaymentInfoModel
{
    [Required(ErrorMessage = "StudentId is required")]
    public Guid studentId { get; set; }
    public string? PaymentInfo { get; set; }
    [Range(1000, 50000000, ErrorMessage = "Amount must be greater than 0")]
    public double Amount { get; set; }
}