using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerLog
    {
        public int Pid { get; set; }
        public string IdCustomer { get; set; }
        public string CustomerXml { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public string IdTool { get; set; }

        public virtual TblCustomer IdCustomerNavigation { get; set; }
        public virtual TblTool IdToolNavigation { get; set; }
    }
}
