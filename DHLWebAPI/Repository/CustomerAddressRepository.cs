using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly DHLContext db;

        public CustomerAddressRepository(DHLContext db)
        {
            this.db = db;
        }
        public TblCustomerAddress GetCustomerAddress(int customerAddressID)
        {
            return db.TblCustomerAddress.FirstOrDefault(o => o.IdAddress.Equals(customerAddressID));
        }

        public ICollection<TblCustomerAddress> GetCustomerAddresses()
        {
            return db.TblCustomerAddress.ToList();
        }
    }
}
