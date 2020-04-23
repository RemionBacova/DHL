using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblUsers
    {
        public TblUsers()
        {
            TblAddressTypeInsertByNavigation = new HashSet<TblAddressType>();
            TblAddressTypeUpdateByNavigation = new HashSet<TblAddressType>();
            TblCardStatus = new HashSet<TblCardStatus>();
            TblCardsInsertByNavigation = new HashSet<TblCards>();
            TblCardsUpdateByNavigation = new HashSet<TblCards>();
            TblCustomerAddressInsertByNavigation = new HashSet<TblCustomerAddress>();
            TblCustomerAddressUpdateByNavigation = new HashSet<TblCustomerAddress>();
            TblCustomerDiscount = new HashSet<TblCustomerDiscount>();
            TblCustomerLogs = new HashSet<TblCustomerLogs>();
            TblCustomerStatusInsertByNavigation = new HashSet<TblCustomerStatus>();
            TblCustomerStatusUpdateByNavigation = new HashSet<TblCustomerStatus>();
            TblCustomerTypeInsertByNavigation = new HashSet<TblCustomerType>();
            TblCustomerTypeUpdateByNavigation = new HashSet<TblCustomerType>();
            TblCustomersInsertByNavigation = new HashSet<TblCustomers>();
            TblCustomersUpdateByNavigation = new HashSet<TblCustomers>();
            TblDiscountTypeInsertByNavigation = new HashSet<TblDiscountType>();
            TblDiscountTypeUpdateByNavigation = new HashSet<TblDiscountType>();
            TblDiscountsInsertByNavigation = new HashSet<TblDiscounts>();
            TblDiscountsUpdateByNavigation = new HashSet<TblDiscounts>();
            TblProductDiscount = new HashSet<TblProductDiscount>();
            TblProductsInsertByNavigation = new HashSet<TblProducts>();
            TblProductsUpdatedByNavigation = new HashSet<TblProducts>();
            TblShipmentsInsertByNavigation = new HashSet<TblShipments>();
            TblShipmentsUpdateByNavigation = new HashSet<TblShipments>();
            TblTransactionLogs = new HashSet<TblTransactionLogs>();
        }

        public int IdUser { get; set; }
        public string ContactName { get; set; }
        public byte UserType { get; set; }
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
        public virtual ICollection<TblAddressType> TblAddressTypeInsertByNavigation { get; set; }
        public virtual ICollection<TblAddressType> TblAddressTypeUpdateByNavigation { get; set; }
        public virtual ICollection<TblCardStatus> TblCardStatus { get; set; }
        public virtual ICollection<TblCards> TblCardsInsertByNavigation { get; set; }
        public virtual ICollection<TblCards> TblCardsUpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomerAddress> TblCustomerAddressInsertByNavigation { get; set; }
        public virtual ICollection<TblCustomerAddress> TblCustomerAddressUpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual ICollection<TblCustomerLogs> TblCustomerLogs { get; set; }
        public virtual ICollection<TblCustomerStatus> TblCustomerStatusInsertByNavigation { get; set; }
        public virtual ICollection<TblCustomerStatus> TblCustomerStatusUpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomerType> TblCustomerTypeInsertByNavigation { get; set; }
        public virtual ICollection<TblCustomerType> TblCustomerTypeUpdateByNavigation { get; set; }
        public virtual ICollection<TblCustomers> TblCustomersInsertByNavigation { get; set; }
        public virtual ICollection<TblCustomers> TblCustomersUpdateByNavigation { get; set; }
        public virtual ICollection<TblDiscountType> TblDiscountTypeInsertByNavigation { get; set; }
        public virtual ICollection<TblDiscountType> TblDiscountTypeUpdateByNavigation { get; set; }
        public virtual ICollection<TblDiscounts> TblDiscountsInsertByNavigation { get; set; }
        public virtual ICollection<TblDiscounts> TblDiscountsUpdateByNavigation { get; set; }
        public virtual ICollection<TblProductDiscount> TblProductDiscount { get; set; }
        public virtual ICollection<TblProducts> TblProductsInsertByNavigation { get; set; }
        public virtual ICollection<TblProducts> TblProductsUpdatedByNavigation { get; set; }
        public virtual ICollection<TblShipments> TblShipmentsInsertByNavigation { get; set; }
        public virtual ICollection<TblShipments> TblShipmentsUpdateByNavigation { get; set; }
        public virtual ICollection<TblTransactionLogs> TblTransactionLogs { get; set; }
    }
}
