
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
    public class AddressRepository : IAddressRepository
    {
        private readonly DHLContext _context;

        public AddressRepository(DHLContext context)
        {
            _context = context;
        }

        //function to retrieve the  list with all addresses
        public async Task<IEnumerable<TblAddress>> GetAllAddresses()
        {
            var model = await _context.TblAddresses
                                       .Include(cust => cust.TblCustomerAddress)
                                      .ToListAsync();
            //return the list with all addresses
            return model;
        }


        //function to retrieve only one card filtered by its id
        public async Task<TblAddress> GetAddress(int addressId)
        {
            //return the user who matches the id
            return await _context.TblAddresses.Where(adr => adr.IdAddress == addressId)
                                           .Include(cust => cust.TblCustomerAddress)
                                            .FirstOrDefaultAsync();
        }

        //function to create a new card
        public async void AddAddress(TblAddress address)
        {
          

            //add the new address
          await _context.TblAddresses.AddAsync(address);

            //save changes
           // await _context.SaveChangesAsync();

        }

    
        //function to remove an address
        public async void DeleteAddress(TblAddress address)
        {
                //remove card
                _context.TblAddresses.Remove(address);
               
            
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

   
    }
}
