using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    interface ICustomersRepository
    {
        ICollection<TblCustomers> GetCustomers();
        TblCustomers GetCustomers(int customerID);
        bool CreateCustomers(TblCustomers customers);
        bool UpdateCustomers(TblCustomers customers);
        bool DeleteCustomers(TblCustomers customers);
        bool Save();
    }
}
