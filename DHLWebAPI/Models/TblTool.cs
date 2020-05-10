using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblTool
    {
        public TblTool()
        {
            TblCustomerLog = new HashSet<TblCustomerLog>();
            TblShipment = new HashSet<TblShipment>();
            TblTransactionLog = new HashSet<TblTransactionLog>();
        }

        public string IdTool { get; set; }
        public string ToolName { get; set; }
        public byte[] ToolKey { get; set; }
        public bool ToolStatus { get; set; }
        public int IdProfile { get; set; }

        public virtual TblToolPermission IdProfileNavigation { get; set; }
        public virtual ICollection<TblCustomerLog> TblCustomerLog { get; set; }
        public virtual ICollection<TblShipment> TblShipment { get; set; }
        public virtual ICollection<TblTransactionLog> TblTransactionLog { get; set; }
    }
}
