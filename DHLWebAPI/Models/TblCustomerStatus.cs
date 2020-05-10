using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerStatus
    {
        public TblCustomerStatus()
        {
            TblCustomer = new HashSet<TblCustomer>();
        }

        public int IdCustomerStatus { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<TblCustomer> TblCustomer { get; set; }
    }
}
