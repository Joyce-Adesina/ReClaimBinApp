﻿namespace ReClaimBinApp_Core.Dtos.RequestDto
{
    public class OrderRequestDto
    {

        public double WeightInKg { get; set; }
        public string PaperType { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPickUp { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
    }
}