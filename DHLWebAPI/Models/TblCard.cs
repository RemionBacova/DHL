using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCard
    {
        public TblCard()
        {
            TblTransactionLog = new HashSet<TblTransactionLog>();
        }

        public string IdCustomer { get; set; }
        public string IdCard { get; set; }
        public float Balance { get; set; }
        public float BalanceAvailable { get; set; }
        public int CardStatus { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual TblCardStatus CardStatusNavigation { get; set; }
        public virtual TblCustomer IdCustomerNavigation { get; set; }
        public virtual TblUser InsertByNavigation { get; set; }
        public virtual TblUser UpdateByNavigation { get; set; }
        public virtual ICollection<TblTransactionLog> TblTransactionLog { get; set; }
    }
}
