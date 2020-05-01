using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblCustomerLogsDTO
    {
        public long Pid { get; set; }
        public string IdCustomer { get; set; }
        public string CustomerXml { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public string IdTool { get; set; }
    }
}
