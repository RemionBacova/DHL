using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblTransactionLogs
    {
        public long Pid { get; set; }
        public string IdCustomer { get; set; }
        public string IdCard { get; set; }
        public byte TransactionType { get; set; }
        public byte TransactionStatus { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public float Value { get; set; }
        public long? Awb { get; set; }
        public bool Awbstatus { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public string IdTool { get; set; }

        public virtual TblCards IdCardNavigation { get; set; }
        public virtual TblCustomers IdCustomerNavigation { get; set; }
        public virtual TblTools IdToolNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
    }
}
