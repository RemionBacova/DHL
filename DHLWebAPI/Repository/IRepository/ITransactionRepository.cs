using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DHLWebAPI.Repository.IRepository
{
    public interface ITransactionRepository
    {


        Task<IEnumerable<TblTransactionLogs>> GetTransactions();
        Task<TblTransactionLogs> GetTransaction(int transactionId);

        Task<TblTransactionLogs> AddTransaction(TblTransactionLogs transaction);

        Task<TblTransactionLogs> UpdateTransaction(TblTransactionLogs transaction);


        Task<bool> SaveAllAsync();

    }
}


