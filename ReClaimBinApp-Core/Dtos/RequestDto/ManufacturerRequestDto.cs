namespace ReClaimBinApp_Core.Dtos.RequestDto
{
    public class ManufacturerRequestDto
    {
        public string Name { get; set; }
        public decimal PricePerKg { get; set; }
        public double MinKilogramAccepted { get; set; }
        public string UserId { get; set; }
    }
}