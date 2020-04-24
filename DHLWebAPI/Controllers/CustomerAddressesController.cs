using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    }
}