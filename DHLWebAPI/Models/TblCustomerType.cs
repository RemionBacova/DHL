﻿using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomerType
    {
        public TblCustomerType()
        {
            TblCustomers = new HashSet<TblCustomers>();
        }

        public int IdCustomerType { get; set; }
        public string Description { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomers> TblCustomers { get; set; }
    }
}
