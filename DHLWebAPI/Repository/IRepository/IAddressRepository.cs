using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHLWebAPI.Models;

namespace DHLWebAPI.Repository.IRepository
{
    public interface IAddressRepository
    {
        ICollection<TblAddress> GetAddresses();
        TblAddress GetAddress(int id);
        bool CreateAddress(TblAddress address);
        bool UpdateAddress(TblAddress address);
        bool DeleteAddress(TblAddress address);
        bool Save();
    }
}
