namespace toiec_web.Models
{
    public class Payment
    {
        public Guid idPayment { get; set; }
        public Guid idMethod { get; set; }
        public Guid idStudent { get; set; }
        public string message { get; set; }
        public DateTime paymentDate { get; set; }
        public double paymentAmount { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<VipPackage> VipPackages { get; set; }
        public virtual Student Student { get; set; }
    }
}
