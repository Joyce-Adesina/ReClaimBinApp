using System.ComponentModel.DataAnnotations;

namespace ReClaimBinApp_Core.Model
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        [StringLength(10)]
        public string? AccountNumber { get; set; }
        public string UserId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}