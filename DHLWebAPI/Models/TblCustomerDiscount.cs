using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerDiscount
    {
        public string IdCustomer { get; set; }
        public int IdDiscount { get; set; }
        public string CodeForActive { get; set; }
        public bool IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }

        public virtual TblCustomer IdCustomerNavigation { get; set; }
        public virtual TblDiscount IdDiscountNavigation { get; set; }
        public virtual TblUser InsertByNavigation { get; set; }
    }
}
