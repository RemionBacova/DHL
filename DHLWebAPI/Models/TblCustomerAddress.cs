using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerAddress
    {
        public string IdCustomer { get; set; }
        public int IdAddress { get; set; }

        public virtual TblAddress IdAddressNavigation { get; set; }
        public virtual TblCustomers IdCustomerNavigation { get; set; }
    }
}
