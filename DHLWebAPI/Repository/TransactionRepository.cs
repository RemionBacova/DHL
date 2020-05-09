
using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DHLContext _context;

        public TransactionRepository(DHLContext context)
        {
            _context = context;
        }

        //  return the  list of all transactions
        public async Task<IEnumerable<TblTransactionLogs>> GetTransactions()
        {
            return await _context.TblTransactionLogs.ToListAsync();

        }


        // return one transaction filtered by its id
        public async Task<TblTransactionLogs> GetTransaction(int transactionId)
        {
            return await _context.TblTransactionLogs.Where(zh => zh.Pid == transactionId)
                                            .FirstOrDefaultAsync();
        }

        // create new 
        public async Task<TblTransactionLogs> AddTransaction(TblTransactionLogs transaction)
        {
            //add the new transaction
            var transactionNew = await _context.TblTransactionLogs.AddAsync(transaction);
            //save changes
            await _context.SaveChangesAsync();
            //return new  
            return transactionNew.Entity;
        }

        // update
        public async Task<TblTransactionLogs> UpdateTransaction(TblTransactionLogs transaction)
        {
            //retrieve the transaction we are trying to update
            var transaction1 = await _context.TblTransactionLogs.Where(zh => zh.Pid == transaction.Pid)
                                                  .FirstOrDefaultAsync();
            //
            if (transaction1 != null)
            {
                transaction1.IdCustomer = transaction.IdCustomer;
                transaction1.IdCard = transaction.IdCard;
                transaction1.TransactionType = transaction.TransactionType;
                transaction1.TransactionStatus = transaction.TransactionStatus;
                transaction1.TransactionId = transaction.TransactionId;
                transaction1.TransactionDateTime = transaction.TransactionDateTime;
                transaction1.Value = transaction.Value;
                transaction1.Awb = transaction.Awb;
                transaction1.Awbstatus = transaction.Awbstatus;
                transaction1.InsertBy = transaction.InsertBy;
                transaction1.InsertDate = transaction.InsertDate;
                transaction1.IdTool = transaction.IdTool;


                //save changes
                await _context.SaveChangesAsync();

                //return result
                return transaction1;
            }
            return null;

        }



        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


    }
}

