
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
        private readonly DHLContext _db;

        public CustomersRepository(DHLContext dHLContext)
        {
            _db = dHLContext;
        }

        public TblCustomers GetCustomer(int customerId)
        {
            return _db.TblCustomers.FirstOrDefault(o => o.IdCustomer == customerId);
        }

        public ICollection<TblCustomers> GetCustomers() => _db.TblCustomers.ToList();
    }
}
