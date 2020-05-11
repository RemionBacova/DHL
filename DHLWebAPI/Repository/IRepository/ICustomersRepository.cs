using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICustomersRepository
    {
       
        Task<IEnumerable<TblCustomer>> GetAllCustomers();

        Task<TblCustomer> GetCustomer(string id);

        void AddCustomer(TblCustomer customer);

        Task<bool> SaveAllAsync();
    }
}
