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
        public async Task<IEnumerable<TblAddress>> GetAddresses()
        {
            //return the list with all addresses
           return await _context.TblAddress.ToListAsync();

        }


        //function to retrieve only one card filtered by its id
        public async Task<TblAddress> GetAddress(int addressId)
        {
            //return the user who matches the id
            return await _context.TblAddress.Where(adr => adr.IdAddress == addressId)
                                            .FirstOrDefaultAsync();
        }

        //function to create a new card
        public async Task<TblAddress> AddAddress(TblAddress address)
        {
            //add the new address
            var addressNew = await _context.TblAddress.AddAsync(address);
            //save changes
            await _context.SaveChangesAsync();
            //return new address 
            return addressNew.Entity;
        }

        //function to update the information of an address
        public async Task<TblAddress> UpdateAddress(TblAddress address)
        {
            //retrieve the address we are trying to update
            var address1= await _context.TblAddress.Where(adr => adr.IdAddress == address.IdAddress)
                                                  .FirstOrDefaultAsync();
            //
            if(address1 != null)
            {
                //if the card exist we can update its information
                address1.IdAddressType = address.IdAddressType;
                address1.AddressLabel = address.AddressLabel;
                address1.Country = address.Country;
                address1.Province = address.Province;
                address1.City = address.City;
                address1.PostalCode = address.PostalCode;
                address1.PostAddress = address.PostAddress;
                address1.PostAddressNumber = address.PostAddressNumber;
                address1.PostIntern = address.PostIntern;
                address1.OpenTimeStart = address.OpenTimeEnd;
                address1.OpenTimeEnd = address.OpenTimeStart;
                address1.LunchTimeStart = address.LunchTimeStart;
                address1.LunchTimeEnd = address.LunchTimeEnd;
                address1.ContactName = address.ContactName;

                //save changes
                await _context.SaveChangesAsync();

                //return result
                return address1;
            }
            return null;

        }

        //function to remove an address
        public async void DeleteAddress(int addressId)
        {
            //check if the card exist
            var address1 = await _context.TblAddress.Where(adr => adr.IdAddress == addressId)
                                        .FirstOrDefaultAsync();
            if (address1 != null)
            {
                //remove card
                _context.TblAddress.Remove(address1);
                //save changes
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

   
    }
}
