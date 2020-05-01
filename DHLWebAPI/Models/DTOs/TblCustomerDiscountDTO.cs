using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblCustomerDiscountDTO
    {
        public string IdCustomer { get; set; }
        public int IdDiscount { get; set; }
        public string CodeForActive { get; set; }
        public bool IsActive { get; set; }
        
    }
}
