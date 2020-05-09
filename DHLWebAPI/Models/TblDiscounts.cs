using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblDiscounts
    {
        public TblDiscounts()
        {
            TblCustomerDiscount = new HashSet<TblCustomerDiscount>();
            TblCustomers = new HashSet<TblCustomers>();
            TblProductDiscount = new HashSet<TblProductDiscount>();
        }

        public int IdDiscount { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountDescription { get; set; }
        public byte DiscountType { get; set; }
        public float DiscountPerc { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public bool DiscountToActive { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblDiscountType DiscountTypeNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual ICollection<TblCustomers> TblCustomers { get; set; }
        public virtual ICollection<TblProductDiscount> TblProductDiscount { get; set; }
    }
}
