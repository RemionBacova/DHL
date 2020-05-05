using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    interface ICustomerDiscountsRepository
    {
        ICollection<TblCustomerDiscount> GetCustomerDiscount();
        ICollection<TblCustomerDiscount> GetCustomerDiscounts();
        TblCustomerDiscount GetCustomerDiscount(int customerID);
        TblCustomerDiscount GetCustomerDiscounts(string tokenString);
        bool CreateCusDiscounts(TblCustomerDiscount cusdiscounts);
        bool UpdateCusDiscounts(TblCustomerDiscount cusdiscounts);
        bool DeleteCusDiscounts(TblCustomerDiscount cusdiscounts);
        bool Save();
    }
}
