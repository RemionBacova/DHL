using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using DHLWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHLWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        //inject repository pattern for transaction
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of Transactions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetTransactions()
        {
            try
            {
                var transaction = await _transactionRepository.GetTransactions();

                if (transaction == null)
                {
                    return NotFound($"Couldn't find any transaction on the database");
                }
                var transactionDTO = new List<TblTransactionLogsDTO>();

                foreach (var zh in transaction)
                {
                    transactionDTO.Add(_mapper.Map<TblTransactionLogsDTO>(zh));
                }

                return Ok(transactionDTO);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Get a single Transaction.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Transaction/5
        [HttpGet("GetTransaction/{id:int}")]
        public async Task<ActionResult> GetTransaction(int id)
        {
            try
            {
                var transaction = await _transactionRepository.GetTransaction(id);

                if (transaction == null)
                {
                    return NotFound($"Transaction of {id} was not found");

                }
                return Ok(_mapper.Map<TblTransactionLogsDTO>(transaction));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        /// <summary>
        /// Create Transaction.
        /// </summary>
        /// <param name="transactionlogsDto"></param>
        /// <returns></returns>
        //POST: api/Transaction
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TblTransactionLogsDTO transactionlogsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var transaction = _mapper.Map<TblTransactionLogs>(transactionlogsDto);

                await _transactionRepository.AddTransaction(transaction);

                await _transactionRepository.SaveAllAsync();

                //created at action will provide a 201:Created response
                return CreatedAtAction(nameof(GetTransaction), new
                {
                    Id = transaction.Pid
                }, transaction);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new transaction record");
            }

        }

        /// <summary>
        /// Update Transaction.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transactionlogsDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody]TblTransactionLogsDTO transactionlogsDto)
        {
            try
            {
                var transaction = _mapper.Map<TblTransactionLogs>(transactionlogsDto);

                await _transactionRepository.GetTransaction(id);

                if (transaction == null)
                {
                    return NotFound($"Couldn't find a transaction of {id}");
                }

                await _transactionRepository.UpdateTransaction(transaction);

                if (await _transactionRepository.SaveAllAsync())
                {
                    return Ok();
                }
                return BadRequest(string.Format("Could not update  transaction"));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }


        }
    }
}

