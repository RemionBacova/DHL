using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
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
        //4.Check if the request is successfully completed

        Task<IEnumerable<TblAddress>> GetAllAddresses();

        Task<TblAddress> GetAddress(int id);

        void AddAddress(TblAddress address);

        Task<bool> SaveAllAsync();

    }
}
