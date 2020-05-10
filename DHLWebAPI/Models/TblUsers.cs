using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblUsers
    {
        public TblUsers()
        {
            TblCardStatus = new HashSet<TblCardStatus>();
            TblCardsInsertByNavigation = new HashSet<TblCards>();
            TblCardsUpdateByNavigation = new HashSet<TblCards>();
            TblCustomerDiscount = new HashSet<TblCustomerDiscount>();
            TblCustomersInsertByNavigation = new HashSet<TblCustomers>();
            TblCustomersUpdateByNavigation = new HashSet<TblCustomers>();
            TblTransactionLogs = new HashSet<TblTransactionLogs>();
        }

        public int IdUser { get; set; }
        public string ContactName { get; set; }
        public int UserType { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual TblUserType UserTypeNavigation { get; set; }
        public virtual ICollection<TblCardStatus> TblCardStatus { get; set; }
        public virtual ICollection<TblCards> TblCardsInsertByNavigation { get; set; }
        public virtual ICollection<TblCards> TblCardsUpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual ICollection<TblCustomers> TblCustomersInsertByNavigation { get; set; }
        public virtual ICollection<TblCustomers> TblCustomersUpdateByNavigation { get; set; }
        public virtual ICollection<TblTransactionLogs> TblTransactionLogs { get; set; }
    }
}
