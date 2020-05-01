using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICustomerLogsRepository
    {
        ICollection<TblCustomerLogs> GetCustomerLogs();
        TblCustomerLogs GetCustomerLogs(long customerLogID);
        bool CreateCustomerLogs(TblCustomerLogs customerLog);
        bool UpdateCustomerLogs(TblCustomerLogs customerLog);
        bool DeleteCustomerLogs(TblCustomerLogs customerLog);
        bool Save();

    }
}
