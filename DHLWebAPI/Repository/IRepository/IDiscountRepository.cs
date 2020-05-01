using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    interface IDiscountRepository
    {
        ICollection<TblDiscounts> GetDiscounts();
        TblDiscounts GetDiscounts(int discountsID);
        bool CreateDiscounts(TblDiscounts discounts);
        bool UpdateDiscounts(TblDiscounts discounts);
        bool DeleteDiscounts(TblDiscounts discounts);
        bool Save();
    }
}
