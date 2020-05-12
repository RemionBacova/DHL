using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHLWebAPI.Models
{
    public partial class TblCustomers
    {
        public TblCustomers()
        {
            TblCustomerAddress = new HashSet<TblCustomerAddress>();
            TblCustomerDiscount = new HashSet<TblCustomerDiscount>();
            TblCustomerLogs = new HashSet<TblCustomerLogs>();
            TblShipments = new HashSet<TblShipments>();
            TblTransactionLogs = new HashSet<TblTransactionLogs>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCustomer { get; set; }
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
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? IdDiscount { get; set; }

        public virtual TblCustomerStatus CustomerStatusNavigation { get; set; }
        public virtual TblCustomerType CustomerTypeNavigation { get; set; }
        public virtual TblDiscounts IdDiscountNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual TblCards TblCards { get; set; }
        public virtual ICollection<TblCustomerAddress> TblCustomerAddress { get; set; }
        public virtual ICollection<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual ICollection<TblCustomerLogs> TblCustomerLogs { get; set; }
        public virtual ICollection<TblShipments> TblShipments { get; set; }
        public virtual ICollection<TblTransactionLogs> TblTransactionLogs { get; set; }
    }
}
