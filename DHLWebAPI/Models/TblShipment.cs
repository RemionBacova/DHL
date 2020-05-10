using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblShipment
    {
        public int Pid { get; set; }
        public string IdCostumer { get; set; }
        public int Awb { get; set; }
        public DateTime DatetimeCreation { get; set; }
        public bool ImmediateInvoicing { get; set; }
        public bool CheckPointFound { get; set; }
        public DateTime ShipmentDate { get; set; }
        public float TotalInvoice { get; set; }
        public bool IsDeleted { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IdTool { get; set; }

        public virtual TblCustomer IdCostumerNavigation { get; set; }
        public virtual TblTool IdToolNavigation { get; set; }
    }
}
