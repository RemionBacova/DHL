using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICustomerDiscountsRepository
    {


        Task<IEnumerable<TblCustomerDiscount>> GetAllCusDisc();

        Task<TblCustomerDiscount> GetCusDisc(int id);

        void AddCusDiscount(TblCustomerDiscount cusdisc);

        void DeleteCusDisc(TblCustomerDiscount cusdisc);

        Task<bool> SaveAllAsync();
        
    }
}