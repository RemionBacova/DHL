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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomersRepository customersRepository, IMapper mapper)
        {
            _repository = customersRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of Customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            try
            {
                //get all customers saved until now
                var customers = await _repository.GetAllCustomers();


                //transfer all the data to dto
                var custDto = _mapper.Map<IEnumerable<TblCustomersDTO>>(customers);

                //display status code
                return Ok(custDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }
        }


        /// <summary>
        /// Get single Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(string id)
        {
            try
            {
                //get the customer as identified by its id
                var customer = await _repository.GetCustomer(id);

                if (customer == null)
                {
                    //if the cust does not exist display error message
                    return NotFound($"Customer of {id} was not found");

                }
                //transfer the data of source into dto 
                var custDto = _mapper.Map<TblCustomersDTO>(customer);

                //display the msg
                return Ok(custDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }

        }



        /// <summary>
        /// Create Customer.
        /// </summary>
        /// <param name="custDto"></param>
        /// <returns></returns>
        //POST: api/Address
        [HttpPost(Name = "CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] TblCustomersDTO custDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var customer = _mapper.Map<TblCustomer>(custDto);

                    _repository.AddCustomer(customer);

                    if (await _repository.SaveAllAsync())
                    {
                        var newcustDto = _mapper.Map<TblCustomersDTO>(customer);
                        return Ok(newcustDto);

                        //  return CreatedAtRoute("GetCustomer", new { id = newcustDto.IdCustomer }, newcustDto);
                    }

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
        /// Update Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="custDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] TblCustomersDTO custDto)
        {
            try
            {
                //get the address from the database
                var customer = await _repository.GetCustomer(id);

                if (customer == null)
                {
                    //if the customer is not found print the msg
                    return NotFound($"Couldn't find customer of {id}");
                }

                //send destination inf to source=> update inf
                var newCust = _mapper.Map(custDto, customer);

                if (await _repository.SaveAllAsync())
                {
                    //return the mapped result in case it is successfully saved
                    return Ok(_mapper.Map<TblCustomersDTO>(newCust));
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

        /// <summary>
        /// Delete Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                //get the customer from the db 
                var customer = await _repository.GetCustomer(id);

                if (customer == null)
                {
                    //in case it does exists display the msg
                    return NotFound($"Couldn’t found customer in the database!");
                }

                return BadRequest(string.Format("Customer is not permitted to be deleted. You can change its status!"));



            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }


        }
    }
}
