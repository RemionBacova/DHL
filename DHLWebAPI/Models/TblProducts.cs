using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblProducts
    {
        public TblProducts()
        {
            TblProductDiscount = new HashSet<TblProductDiscount>();
        }

        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertData { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdatedByNavigation { get; set; }
        public virtual ICollection<TblProductDiscount> TblProductDiscount { get; set; }
    }
}
