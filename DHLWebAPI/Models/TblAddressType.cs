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

        public int IdAddressType { get; set; }
        public string AdressType { get; set; }
        public string Description { get; set; }
        public DateTime? InsertDate { get; set; }

        public virtual ICollection<TblAddress> TblAddress { get; set; }
    }
}
