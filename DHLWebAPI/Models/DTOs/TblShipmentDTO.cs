using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblShipmentDTO
    {
        public int Pid { get; set; }
        public int? IdCostumer { get; set; }
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
        public int? IdTool { get; set; }
    }
}
