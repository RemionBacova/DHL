using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICustomerAddressRepository
    {
        ICollection<TblCustomerAddress> GetCustomerAddresses();
        TblCustomerAddress GetCustomerAddress(int customerAddressID);

    }
}
