
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DHLContext db;

        //Dependenct Injection for DHLContext
        public CustomersRepository(DHLContext db)
        {
            this.db = db;
        }

        //Below are different crud operations implemented by the ICustomersRepository interface
        public bool CreateCustomers(TblCustomers customers)
        {
            db.TblCustomers.Add(customers);
            return Save();
        }

        public bool DeleteCustomers(TblCustomers customers)
        {
            db.TblCustomers.Remove(customers);
            return Save();
        }

        public TblCustomers GetCustomers(string customerID)
        {
            return db.TblCustomers.FirstOrDefault(o => o.IdCustomer.Equals(customerID));
        }

        public ICollection<TblCustomers> GetCustomers()
        {
            return db.TblCustomers.ToList();
        }

        public bool UpdateCustomers(TblCustomers customers)
        {
            db.TblCustomers.Update(customers);
            return Save();
        }

        public bool Save()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }
    }
}
