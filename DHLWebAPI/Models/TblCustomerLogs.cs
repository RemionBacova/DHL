using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerLogs
    {
        public long Pid { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerXml { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int IdTool { get; set; }

        public virtual TblCustomers IdCustomerNavigation { get; set; }
        public virtual TblTools IdToolNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
    }
}
