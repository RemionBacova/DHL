using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICustomerDiscountRepository
    {
        //function to retrieve the  list with all cust discounts
        Task<IEnumerable<TblCustomerDiscount>> GetCustomerDiscounts();

        //function to retrieve only one cust discounts filtered by its id
        Task<TblCustomerDiscount> GetCustomerDiscount(int customerDiscountId);

        //function to create a new cust discount
        Task<TblCustomerDiscount> AddCustomerDiscount(TblCustomerDiscount customerDiscount);

        //function to update the information of an cust discounts
        Task<TblCustomerDiscount> UpdateCustomerDiscount(TblCustomerDiscount customerDiscount);

        //function to remove an cust discounts
        void DeleteCustomerDiscount(int customerDiscountId);
    }
}
