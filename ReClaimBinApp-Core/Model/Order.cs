﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ReClaimBinApp_Core.Model
{
    public class Order : BaseEntity
    {
        public double WeightInKg { get; set; }
        public string PaperType { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPickUp { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }

        [ForeignKey(nameof(Supplier))]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        [ForeignKey(nameof(Manufacturer))]
        public string ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}                                  