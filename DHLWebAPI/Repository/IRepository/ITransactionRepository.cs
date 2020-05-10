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


        Task<IEnumerable<TblTransactionLog>> GetTransactions();
        Task<TblTransactionLog> GetTransaction(int transactionId);

        Task<TblTransactionLog> AddTransaction(TblTransactionLog transaction);

        Task<TblTransactionLog> UpdateTransaction(TblTransactionLog transaction);


        Task<bool> SaveAllAsync();

    }
}


