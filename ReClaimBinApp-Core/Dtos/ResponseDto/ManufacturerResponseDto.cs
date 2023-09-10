using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Core.Dtos.ResponseDto
{
    public class ManufacturerResponseDto
    {
        public int Id { get; set; }
        public decimal PricePerKg { get; set; }
        public double MinKilogramAccepted { get; set; }


    }
}
