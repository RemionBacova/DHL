using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerDiscount
    {
        public int IdCustomer { get; set; }
        public int IdDiscount { get; set; }
        public string CodeForActive { get; set; }
        public bool IsActive { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual TblCustomers IdCustomerNavigation { get; set; }
        public virtual TblDiscounts IdDiscountNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
    }
}
