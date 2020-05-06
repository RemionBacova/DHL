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
        //inject repository pattern for address
        private readonly IAddressRepository _addressRepository;
        //inject AutoMapper at runtime into address controller:
        private readonly IMapper _mapper;

        public AddressesController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAddresses()
        {
            try
            {
                //get all addresses saved until now
                var addresses = await _addressRepository.GetAddresses();

                if (addresses == null)
                {
                    //if there are no addresses found display the msg
                    return NotFound($"Couldn't find any address from the database");
                }
                //transfer all the data to dto
                var addresesDTO =  new List<TblAddressDTO>();

                foreach (var adr in addresses)
                {
                    addresesDTO.Add(_mapper.Map<TblAddressDTO>(adr));
                }
            
                //display the dto with the msg
                return Ok(addresesDTO);
            
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/Address/5
        [HttpGet("GetAddress/{id:int}")]
        public async Task<ActionResult> GetAddress(int id)
        {
            try
            {
                //get the address as identified by its id
                var address = await _addressRepository.GetAddress(id);

                if (address == null)
                {
                    //if the address does not exist display error message
                    return NotFound($"Address of {id} was not found");

                }
                //transfer the data of source into dto 
                var addressDto = _mapper.Map<TblAddressDTO>(address);

                //display the msg
                return Ok(addressDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        //POST: api/Address
        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] TblAddressDTO addressDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var address = _mapper.Map<TblAddress>(addressDto);

                await _addressRepository.AddAddress(address);

                await _addressRepository.SaveAllAsync();

                //created at action will provide a 201:Created response
                return CreatedAtAction(nameof(GetAddress), new
                {
                    addressId = address.IdAddress
                }, address);

                //The CreatedAtRoute method is intended to return a URI to the newly created resource 
                //when you invoke a POST method to store some new object
                //return CreatedAtRoute("GetAddresses", new
                //{
                //    addressID = address.IdAddress
                //});

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new address record");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody]TblAddressDTO addressDto)
        {
            try
            {
                var address = _mapper.Map<TblAddress>(addressDto);

                 await _addressRepository.GetAddress(id);

                if (address == null)
                {
                    return NotFound($"Couldn't find an address of {id}");
                }

                 await _addressRepository.UpdateAddress(address);

                if (await _addressRepository.SaveAllAsync())
                {
                    return Ok();
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
