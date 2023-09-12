namespace ReClaimBinApp_Core.Dtos.ResponseDto
{
    public class ManufacturerResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerKg { get; set; }
        public double MinKilogramAccepted { get; set; }
        public string UserId { get; set; }
    }
}