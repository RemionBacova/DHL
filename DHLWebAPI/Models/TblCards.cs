using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCards
    {
        public TblCards()
        {
            TblTransactionLogs = new HashSet<TblTransactionLogs>();
        }

        public string IdCustomer { get; set; }
        public string IdCard { get; set; }
        public float Balance { get; set; }
        public float BalanceAvailable { get; set; }
        public int CardStatus { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblCardStatus CardStatusNavigation { get; set; }
        public virtual TblCustomers IdCustomerNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual ICollection<TblTransactionLogs> TblTransactionLogs { get; set; }
    }
}
