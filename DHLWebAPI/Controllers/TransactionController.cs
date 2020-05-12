using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DHLWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHLWebAPI.Controllers
{
   /* [Route("api/[controller]")]
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
                var transactions = await _transactionRepository.GetTransactions();

                //transfer all the data to dto
                var transactionDTO = _mapper.Map<IEnumerable<TblTransactionLogsDTO>>(transactions);

                //display status code
                return Ok(transactionDTO);

            

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"Error Explanation: {ex.Message} ");
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
                var transactionDto = _mapper.Map<TblTransactionLogsDTO>(transaction);

                //display the msg
                return Ok(transactionDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
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
                if (ModelState.IsValid)
                {
                    var transaction = _mapper.Map<TblTransactionLog>(transactionlogsDto);

                    _transactionRepository.AddTransaction(transaction);

                    
                    var newtransactionDto = _mapper.Map<TblAddressDTO>(transaction);
                    return Ok(newtransactionDto);
                    //}

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }

            return BadRequest(ModelState);
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
                var transaction = await _transactionRepository.GetTransaction(id);

                if (transaction == null)
                {
                    return NotFound($"Couldn't find a transaction of {id}");
                }

                var newTransaction = _mapper.Map(transactionlogsDto, transaction);

                if (await _transactionRepository.SaveAllAsync())
                {
                    //return the mapped result in case it is successfully saved
                    return Ok(_mapper.Map<TblTransactionLogsDTO>(newTransaction));
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }



        }
    }*/
}

