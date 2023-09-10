using ReClaimBinApp_Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Core.Dtos.ResponseDto
{
    public class OrderResponseDto
    {
        public int Quantity { get; set; }
        public string BookType { get; set; }
        public string Size { get; set; }
        public string ManufacturerToSell { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public bool IsPickUp { get; set; }
        public string Status { get; set; }// = Status.Pending;
        public string Location { get; set; }
        public string Image { get; set; }
    }
}
