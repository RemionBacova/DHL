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
    public class CustomerAddressesController : ControllerBase
    {
        private readonly ICustomerAddressRepository customerAddressRepository;
        private readonly IMapper mapper;

        public CustomerAddressesController(ICustomerAddressRepository customerAddressRepository, IMapper mapper)
        {
            this.customerAddressRepository = customerAddressRepository;
            this.mapper = mapper;
        }


        /// <summary>
        /// Get list of Customers Addresses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomerAddresses()
        {
            var list = customerAddressRepository.GetCustomerAddresses();
            var listDTO = new List<TblCustomerAddressDTO>();

            foreach (var item in list)
            {
                listDTO.Add(mapper.Map<TblCustomerAddressDTO>(item));
            }

            return Ok(listDTO);
        }


        /// <summary>
        /// Get single customer address.
        /// </summary>
        /// <param name="addressID"></param>
        /// <returns></returns>
        [HttpGet("{addressID:int}", Name = "GetCustomerAddress")]
        public IActionResult GetCustomerAddress(int addressID)
        {
            var item = customerAddressRepository.GetCustomerAddress(addressID);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = mapper.Map<TblCustomerAddressDTO>(item);

            return Ok(itemDTO);
        }

        /// <summary>
        /// Create customer address details(object).
        /// </summary>
        /// <param name="tblCustomerAddressDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCustomerAddress([FromBody] TblCustomerAddressDTO tblCustomerAddressDTO)
        {
            if (tblCustomerAddressDTO == null)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = mapper.Map<TblCustomerAddress>(tblCustomerAddressDTO);

            return CreatedAtRoute("GetCustomerAddress", new 
            {
                customerAddressID = itemDTO.IdAddress
            });
        }

        /// <summary>
        /// Update single data in TblCustomerAddress
        /// </summary>
        /// <param name="customerAddressID"></param>
        /// <param name="tblCustomerAddressDTO"></param>
        /// <returns></returns>
        [HttpPatch("{customerAddressID:int}", Name = "UpdateCustomerAddress")]
        public IActionResult UpdateCustomerAddress
            (int customerAddressID, [FromBody] TblCustomerAddressDTO tblCustomerAddressDTO)
        {
            if (tblCustomerAddressDTO == null || customerAddressID != tblCustomerAddressDTO.IdAddress)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = mapper.Map<TblCustomerAddress>(tblCustomerAddressDTO);

            if (!customerAddressRepository.UpdateCustomerAddress(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an customer address object from the TblCustomerAddress
        /// </summary>
        /// <param name="customerAddressID"></param>
        /// <returns></returns>
        [HttpDelete("{customerAddressID:int}", Name = "DeleteCustomerAddress")]
        public IActionResult DeleteCustomerAddress(int customerAddressID)
        {
            var itemDTO = customerAddressRepository.GetCustomerAddress(customerAddressID);

            if (!customerAddressRepository.DeleteCustomerAddress(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}