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
    public class CustomerLogsRepository : ICustomerLogsRepository
    {
        private readonly DHLContext db;

        //Dependenct Injection for DHLContext
        public CustomerLogsRepository(DHLContext db)
        {
            this.db = db;
        }
        //Below are different crud operations implemented by the ICustomerLogsRepository interface
        public bool CreateCustomerLogs(TblCustomerLogs customerLog)
        {
            db.TblCustomerLogs.Add(customerLog);
            return Save();
        }

        public bool DeleteCustomerLogs(TblCustomerLogs customerLog)
        {
            db.TblCustomerLogs.Remove(customerLog);
            return Save();
        }

        public TblCustomerLogs GetCustomerLogs(long customerLogID)
        {
            return db.TblCustomerLogs.FirstOrDefault(o => o.Pid.Equals(customerLogID));
        }

        public ICollection<TblCustomerLogs> GetCustomerLogs()
        {
            return db.TblCustomerLogs.ToList();
        }

        public bool UpdateCustomerLogs(TblCustomerLogs customerLog)
        {
            db.TblCustomerLogs.Update(customerLog);
            return Save();
        }

        public bool Save()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }
    }
}
