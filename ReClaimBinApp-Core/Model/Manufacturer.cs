using System.ComponentModel.DataAnnotations.Schema;

namespace ReClaimBinApp_Core.Model
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "Money")]
        public decimal PricePerKg { get; set; }
        public double MinKilogramAccepted { get; set; }
        public string UserId { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}     
