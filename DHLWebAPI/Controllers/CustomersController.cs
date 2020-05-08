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
        private readonly ICustomersRepository _customersRepository;
        private IMapper _mapper;

        //private readonly IDiscountRepository _discountsRepository;
        //private readonly IMapper _mapper;


        private CustomersController(ICustomersRepository customersRepository, IMapper mapper)
        {
            this._customersRepository = customersRepository;
            this._mapper = mapper;
        }





        /// <summary>
        /// Get list of Customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var list = _customersRepository.GetCustomers();
            var listDTO = new List<TblCustomersDTO>();

            foreach (var item in list)
            {
                listDTO.Add(_mapper.Map<TblCustomersDTO>(item));
            }

            return Ok(listDTO);
        }


        /// <summary>
        /// Get single customer.
        /// </summary>
        /// <param name="IdCustomer"></param>
        /// <returns></returns>
        [HttpGet("{IdCustomer:alpha}", Name = "GetCustomers")]
        public IActionResult GetCustomers(int IdCustomer)
        {
            var item = _customersRepository.GetCustomers(IdCustomer);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = _mapper.Map<TblCustomersDTO>(item);

            return Ok(itemDTO);
        }

        /// <summary>
        /// Create customer(object).
        /// </summary>
        /// <param name="tblcustomersDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCustomers([FromBody] TblCustomersDTO tblcustomersDTO)
        {
            if (tblcustomersDTO == null)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblCustomers>(tblcustomersDTO);

            return CreatedAtRoute("GetCustomers", new
            {
                customerID = itemDTO.IdCustomer
            });
        }

        /// <summary>
        /// Update single data in TblCustomer
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="tblcustomersDTO"></param>
        /// <returns></returns>
        [HttpPatch("{customerID:alpha}", Name = "UpdateCustomers")]
        public IActionResult UpdateCustomers
            (int customerID, [FromBody] TblCustomersDTO tblcustomersDTO)
        {
            if (tblcustomersDTO == null /*|| customerID != tblCustomersDTO.IdCustomer*/)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblCustomers>(tblcustomersDTO);

            if (!_customersRepository.UpdateCustomers(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an discount object from the TblCustomers
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [HttpDelete("{customerID:alpha}", Name = "DeleteCustomers")]
        public IActionResult DeleteCustomers(int customerID)
        {
            var itemDTO = _customersRepository.GetCustomers(customerID);

            if (!_customersRepository.DeleteCustomers(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}