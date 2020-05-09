using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblCustomerAddressDTO
    {
        public string IdCustomer { get; set; }
        public int IdAddress { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }
    }
}
