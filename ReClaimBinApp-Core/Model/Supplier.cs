using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Core.Model
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        [StringLength(14)]
        public string AccountNumber { get; set; }
        public string UserId { get; set; }
        public ICollection<Order> Orders { get; set; }
        //public ICollection<Review> Reviews { get; set; }
    }
}
