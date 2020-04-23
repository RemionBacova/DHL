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
    }
}