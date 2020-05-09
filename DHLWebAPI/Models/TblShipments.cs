using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblShipments
    {
        public long Pid { get; set; }
        public string IdCostumer { get; set; }
        public long Awb { get; set; }
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

        public virtual TblCustomers IdCostumerNavigation { get; set; }
        public virtual TblTools IdToolNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
    }
}
