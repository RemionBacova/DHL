using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblTools
    {
        public TblTools()
        {
            TblCustomerLogs = new HashSet<TblCustomerLogs>();
            TblShipments = new HashSet<TblShipments>();
            TblTransactionLogs = new HashSet<TblTransactionLogs>();
        }

        public string IdTool { get; set; }
        public string ToolName { get; set; }
        public byte[] ToolKey { get; set; }
        public bool ToolStatus { get; set; }
        public int IdProfile { get; set; }

        public virtual TblToolPermission IdProfileNavigation { get; set; }
        public virtual ICollection<TblCustomerLogs> TblCustomerLogs { get; set; }
        public virtual ICollection<TblShipments> TblShipments { get; set; }
        public virtual ICollection<TblTransactionLogs> TblTransactionLogs { get; set; }
    }
}
