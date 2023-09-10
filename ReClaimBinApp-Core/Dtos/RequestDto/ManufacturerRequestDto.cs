using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Core.Dtos.RequestDto
{
    public class ManufacturerRequestDto
    {
        public decimal PricePerKg { get; set; }
        public double MinKilogramAccepted { get; set; }

    }
}
