using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblCustomerLogsDTO
    {
        public long Pid { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerXml { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int IdTool { get; set; }
    }
}
