using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblAddressTypeDTO
    {
        public byte IdAddressType { get; set; }
        public string AdressType { get; set; }
        public string Description { get; set; }
        public int InsertBy { get; set; }
        public int? UpdateBy { get; set; }

    }
}

