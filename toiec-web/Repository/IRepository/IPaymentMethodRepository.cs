﻿using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethodModel>> GetAllPaymentMethods();
        Task<PaymentMethodModel> GetPaymentMethodById(Guid paymentMethodId);
        Task<bool> AddPaymentMethod(PaymentMethodModel model);
        Task<bool> DeletePaymentMethod(Guid paymentMethodId);
    }
}
