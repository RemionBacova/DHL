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
       
        Task<IEnumerable<TblDiscount>> GetAllDiscounts();

        Task<TblDiscount> GetDiscounts(int id);

        void AddDiscount(TblDiscount disc);

        void DeleteDiscount(TblDiscount disc);

        Task<bool> SaveAllAsync();

    }
}
