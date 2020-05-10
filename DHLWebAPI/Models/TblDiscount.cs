using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblDiscount
    {
        public TblDiscount()
        {
            TblCustomer = new HashSet<TblCustomer>();
            TblCustomerDiscount = new HashSet<TblCustomerDiscount>();
            TblProductDiscount = new HashSet<TblProductDiscount>();
        }

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

        public virtual ICollection<TblCustomer> TblCustomer { get; set; }
        public virtual ICollection<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual ICollection<TblProductDiscount> TblProductDiscount { get; set; }
    }
}
