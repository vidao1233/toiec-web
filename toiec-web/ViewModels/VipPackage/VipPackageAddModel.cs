﻿namespace toiec_web.ViewModels.VipPackage
{
    public class VipPackageAddModel
    {
        public Guid idPackage { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int duration { get; set; }
    }
}
