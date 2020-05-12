using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblProductsDTO
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertData { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
