using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface IDiscountRepository
    {
       
        Task<IEnumerable<TblDiscounts>> GetAllDiscounts();

        Task<TblDiscounts> GetDiscounts(int id);

        void AddDiscount(TblDiscounts disc);

        void DeleteDiscount(TblDiscounts disc);

        Task<bool> SaveAllAsync();

    }
}
