using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCustomers
    {
        public TblCustomers()
        {
            TblCustomerAddress = new HashSet<TblCustomerAddress>();
            TblCustomerDiscount = new HashSet<TblCustomerDiscount>();
            TblCustomerLogs = new HashSet<TblCustomerLog>();
            TblShipments = new HashSet<TblShipment>();
            TblTransactionLogs = new HashSet<TblTransactionLog>();
        }

        public string IdCustomer { get; set; }
        public int CustomerType { get; set; }
        public int CustomerStatus { get; set; }
        public string Channel { get; set; }
        public string CompanyName { get; set; }
        public string Iva { get; set; }
        public string Sdi { get; set; }
        public string ContactName { get; set; }
        public string FiscalCode { get; set; }
        public string Pec { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IdDiscount { get; set; }

        public virtual TblCustomerStatus CustomerStatusNavigation { get; set; }
        public virtual TblCustomerType CustomerTypeNavigation { get; set; }
        public virtual TblDiscount IdDiscountNavigation { get; set; }
        public virtual TblUser InsertByNavigation { get; set; }
        public virtual TblUser UpdateByNavigation { get; set; }
        public virtual TblCard TblCards { get; set; }
        public virtual ICollection<TblCustomerAddress> TblCustomerAddress { get; set; }
        public virtual ICollection<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual ICollection<TblCustomerLog> TblCustomerLogs { get; set; }
        public virtual ICollection<TblShipment> TblShipments { get; set; }
        public virtual ICollection<TblTransactionLog> TblTransactionLogs { get; set; }
    }
}
