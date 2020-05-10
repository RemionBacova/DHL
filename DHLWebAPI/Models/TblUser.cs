using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCardInsertByNavigation = new HashSet<TblCard>();
            TblCardStatus = new HashSet<TblCardStatus>();
            TblCardUpdateByNavigation = new HashSet<TblCard>();
            TblCustomerDiscount = new HashSet<TblCustomerDiscount>();
            TblCustomerInsertByNavigation = new HashSet<TblCustomer>();
            TblCustomerUpdateByNavigation = new HashSet<TblCustomer>();
            TblTransactionLog = new HashSet<TblTransactionLog>();
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
        public virtual ICollection<TblCard> TblCardInsertByNavigation { get; set; }
        public virtual ICollection<TblCardStatus> TblCardStatus { get; set; }
        public virtual ICollection<TblCard> TblCardUpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual ICollection<TblCustomer> TblCustomerInsertByNavigation { get; set; }
        public virtual ICollection<TblCustomer> TblCustomerUpdateByNavigation { get; set; }
        public virtual ICollection<TblTransactionLog> TblTransactionLog { get; set; }
    }
}
