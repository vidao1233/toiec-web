﻿namespace toiec_web.Models
{
    public class VipPackage
    {
        public Guid idPackage { get; set; }
        public Guid idPayment { get; set; }
        public Guid idAdmin { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public DateTime duration { get; set; }
        public virtual Payment Payment { get; set; } 
        public virtual Admin Admin { get; set; }
    }
}
