using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using DHLWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHLWebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository repository;
        private readonly IMapper mapper;

        public AddressesController(IAddressRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get list of Addresses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAddresses()
        {
            var address = repository.GetAddresses();
            var addressDTO = new List<TblAddressDTO>();

            foreach (var item in address)
            {
                addressDTO.Add(mapper.Map<TblAddressDTO>(item));
            }

            return Ok(addressDTO);
        }

        /// <summary>
        /// Get single Address.
        /// </summary>
        /// <param name="id">The id address.</param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetAddress")]
        public IActionResult GetAddress(int id)
        {
            var address = repository.GetAddress(id);
            if (address == null)
            {
                return NotFound();
            }

            var addressDTO = mapper.Map<TblAddressDTO>(address);

            return Ok(addressDTO);
        }

        /// <summary>
        /// Create Address.
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateAddress")]
        public IActionResult CreateAddress([FromBody] TblAddressDTO addressDTO)
        {
            var address = mapper.Map<TblAddress>(addressDTO);
            repository.CreateAddress(address);

            return Created("GetAddress", addressDTO);
        }

        /// <summary>
        /// Update Address.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}")]
        public IActionResult UpdateAddress(int id, [FromBody]TblAddressDTO addressDTO)
        {
            var address = mapper.Map<TblAddress>(addressDTO);
            repository.UpdateAddress(address);

            return Created("getAddress", addressDTO);
        }
    }
}
