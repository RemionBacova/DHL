
using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public class CustomerDiscountsRepository : ICustomerDiscountsRepository
    {
        private readonly DHLContext _context;

        public CustomerDiscountsRepository(DHLContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<TblCustomerDiscount>> GetAllCusDisc()
        {
            var model = await _context.TblCustomerDiscounts.ToListAsync();
            return model;
        }


    
        public async Task<TblCustomerDiscount> GetCusDisc(int Id)
        {
           
            return await _context.TblCustomerDiscounts.Where(o => o.IdDiscount == Id)
                                            .FirstOrDefaultAsync();
        }

        
        public async void AddCusDiscount(TblCustomerDiscount cusdisc)
        {
           
            await _context.TblCustomerDiscounts.AddAsync(cusdisc);
            await _context.SaveChangesAsync();

        }


        
        public async void DeleteCusDisc(TblCustomerDiscount cusdisc)
        {
            
            _context.TblCustomerDiscounts.Remove(cusdisc);
            
             await _context.SaveChangesAsync();

        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


    }
}
