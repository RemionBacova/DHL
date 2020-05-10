
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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DHLContext _context;

        public DiscountRepository(DHLContext context)
        {
            _context = context;
        }

    
        public async Task<IEnumerable<TblDiscount>> GetAllDiscounts()
        {
            var model = await _context.TblDiscounts.ToListAsync();
            return model;
        }


        
        public async Task<TblDiscount> GetDiscounts(int Id)
        {
            //return the user who matches the id
            return await _context.TblDiscounts.Where(d => d.IdDiscount == Id)
                                            .FirstOrDefaultAsync();
        }

     
        public async void AddDiscount(TblDiscount disc)
        {
            
            await _context.TblDiscounts.AddAsync(disc);
            await _context.SaveChangesAsync();

        }


     
        public async void DeleteDiscount(TblDiscount disc)
        {
            
            _context.TblDiscounts.Remove(disc);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


    }
}
