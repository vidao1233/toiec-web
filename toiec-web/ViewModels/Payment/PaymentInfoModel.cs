using System.ComponentModel.DataAnnotations;

namespace toiec_web.ViewModels.Payment;

public class PaymentInfoModel
{
    [Required(ErrorMessage = "UserId is required")]
    public Guid UserId { get; set; }
    public Guid IdPackage { get; set; }
}