using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface IAddressRepository
    {
        //function to retrieve the  list with all addresses
        Task<IEnumerable<TblAddress>> GetAddresses();

        //function to retrieve only one address filtered by its id
        Task<TblAddress> GetAddress(int addressId);

        //function to create a new address
        Task<TblAddress> AddAddress(TblAddress address);

        //function to update the information of an address
        Task<TblAddress> UpdateAddress(TblAddress address);

        //function to remove an address
        void DeleteAddress(int addressId);
        
        //
        Task<bool> SaveAllAsync();
    }
}
