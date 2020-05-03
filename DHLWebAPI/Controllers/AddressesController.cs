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
    public class AddressesController : ControllerBase
    {
        //inject repository pattern for address
        private readonly IAddressRepository _addressRepository;
        //inject AutoMapper at runtime into address controller:
        private readonly IMapper _mapper;

        public AddressesController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }


        //GET:api/Address
        [HttpGet("GetAddresses")]
        public async Task<ActionResult<IEnumerable<TblAddress>>> GetAddresses()
        {
            try
            {
                var addresses = await _addressRepository.GetAddresses();
                return Ok(_mapper.Map<IEnumerable<TblAddressDTO>>(addresses));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/Address/5
        [HttpGet("GetAddress/{id:int}")]
        public async Task<ActionResult<IEnumerable<TblAddress>>> GetAddress(int id)
        {
            try
            {
                var address = await _addressRepository.GetAddress(id);

                if (address == null)
                {
                    return NotFound($"Address of {id} was not found");

                }
                return Ok(_mapper.Map<TblAddressDTO>(address));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        //POST: api/Address
        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] TblAddress model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var address = await _addressRepository.AddAddress(model);

                //The CreatedAtRoute method is intended to return a URI to the newly created resource 
                //when you invoke a POST method to store some new object
                //return CreatedAtRoute("GetAddresses", new
                //{
                //    addressID = address.IdAddress
                //});

                //created at action will provide a 201:Created response
                return CreatedAtAction(nameof(GetAddress), new
                {
                    addressId = address.IdAddress
                }, address);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new address record");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody]TblAddress address)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var oldAddress = await _addressRepository.GetAddress(id);

                if (oldAddress == null)
                {
                    return NotFound($"Couldn't find an address of {id}");
                }

                oldAddress = await _addressRepository.UpdateAddress(address);

                if (await _addressRepository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<TblAddressDTO>(oldAddress));
                }
                return BadRequest(string.Format("Could not update  address: {0}"));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }


        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("DeleteAddress/{id:int}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                var oldAddress = _addressRepository.GetAddress(id);

                if (oldAddress == null)
                {
                    return NotFound($"Couldn’t found address of id {id}");
                }
                _addressRepository.DeleteAddress(id);

                if (await _addressRepository.SaveAllAsync())
                {
                    return Ok();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }


        }
    }
}
