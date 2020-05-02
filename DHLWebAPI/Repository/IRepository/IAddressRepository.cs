using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface IAddressRepository
    {
        //function below are listed as below:
        //1.Retrieve all addresses
        //2.Retrieve only one address filtered by its id
        //3.Create a new address
        //4.Update the information of an address
        //5.Remove an address
        //6.Check if the request is successfully completed

        Task<IEnumerable<TblAddress>> GetAddresses();
        Task<TblAddress> GetAddress(int addressId);

        Task<TblAddress> AddAddress(TblAddress address);

        Task<TblAddress> UpdateAddress(TblAddress address);

        void DeleteAddress(int addressId);
        Task<bool> SaveAllAsync();
    }
}
