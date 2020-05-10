﻿using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerLogs
    {
        public int Pid { get; set; }
        public string IdCustomer { get; set; }
        public string CustomerXml { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public string IdTool { get; set; }

        public virtual TblCustomers IdCustomerNavigation { get; set; }
        public virtual TblTools IdToolNavigation { get; set; }
    }
}
