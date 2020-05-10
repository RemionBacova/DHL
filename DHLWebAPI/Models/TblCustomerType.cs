using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerType
    {
        public TblCustomerType()
        {
            TblCustomer = new HashSet<TblCustomer>();
        }

        public int IdCustomerType { get; set; }
        public string Description { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<TblCustomer> TblCustomer { get; set; }
    }
}
