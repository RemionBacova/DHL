using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblProduct
    {
        public string IdProduct { get; set; }
        public string ProductName { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertData { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
