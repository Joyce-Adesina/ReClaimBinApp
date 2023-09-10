using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
