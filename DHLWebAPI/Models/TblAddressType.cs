using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblAddressType
    {
        public TblAddressType()
        {
            TblAddress = new HashSet<TblAddress>();
        }

        public byte IdAddressType { get; set; }
        public string AdressType { get; set; }
        public string Description { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual ICollection<TblAddress> TblAddress { get; set; }
    }
}
