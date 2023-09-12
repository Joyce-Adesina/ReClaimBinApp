using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ReClaimBinApp_Core.Model
{
    public class Review : BaseEntity
    {
        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; }
        public string Comment { get; set; }
        [NotNull]
        public int Rating { get; set; }
        public Order Order { get; set; }
    }
}
