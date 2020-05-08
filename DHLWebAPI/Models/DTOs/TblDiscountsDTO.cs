using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblDiscountsDTO
    {
        public int IdDiscount { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountDescription { get; set; }
        public int DiscountType { get; set; }
        public float DiscountPerc { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public bool DiscountToActive { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
