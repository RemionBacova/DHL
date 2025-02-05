﻿using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblDiscountType
    {
        public TblDiscountType()
        {
            TblDiscounts = new HashSet<TblDiscounts>();
        }

        public int IdDiscountType { get; set; }
        public string DiscountTypeTitle { get; set; }
        public string Description { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual ICollection<TblDiscounts> TblDiscounts { get; set; }
    }
}
