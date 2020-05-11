
using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DHLContext _context;

        public CustomersRepository(DHLContext context)
        {
            _context= context;
        }

        public async void AddCustomer(TblCustomer customer)
        {
            //add the new customer
            await _context.TblCustomers.AddAsync(customer);
            //save changes
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TblCustomer>> GetAllCustomers()
        {
            var model = await _context.TblCustomers.ToListAsync();
            //return the list with all addresses
            return model;
        }

        public async Task<TblCustomer> GetCustomer(string id)
        {
            //return the user who matches the id
            return await _context.TblCustomers.Where(cust => cust.IdCustomer==id).FirstOrDefaultAsync();
        }

      
        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
