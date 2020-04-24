using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public bool CreateCustomerAddress(TblCustomerAddress customerAddress)
        {
            db.TblCustomerAddress.Add(customerAddress);
            return Save();
        }

        public bool DeleteCustomerAddress(TblCustomerAddress customerAddress)
        {
            db.TblCustomerAddress.Remove(customerAddress);
            return Save();
        }

        public TblCustomerAddress GetCustomerAddress(int customerAddressID)
        {
            return db.TblCustomerAddress.FirstOrDefault(o => o.IdAddress.Equals(customerAddressID));
        }

        public ICollection<TblCustomerAddress> GetCustomerAddresses()
        {
            return db.TblCustomerAddress.ToList();
        }

        public bool UpdateCustomerAddress(TblCustomerAddress customerAddress)
        {
            db.TblCustomerAddress.Update(customerAddress);
            return Save();
        }

        public bool Save()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }
    }
}
