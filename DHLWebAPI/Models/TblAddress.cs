using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblAddress
    {
        public TblAddress()
        {
            TblCustomerAddress = new HashSet<TblCustomerAddress>();
        }

        public int IdAddress { get; set; }
        public int IdAddressType { get; set; }
        public string AddressLabel { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PostAddress { get; set; }
        public string PostAddressNumber { get; set; }
        public string PostIntern { get; set; }
        public string OpenTimeStart { get; set; }
        public string OpenTimeEnd { get; set; }
        public string LunchTimeStart { get; set; }
        public string LunchTimeEnd { get; set; }
        public string ContactName { get; set; }

        public virtual TblAddressType IdAddressTypeNavigation { get; set; }
        public virtual ICollection<TblCustomerAddress> TblCustomerAddress { get; set; }
    }
}
