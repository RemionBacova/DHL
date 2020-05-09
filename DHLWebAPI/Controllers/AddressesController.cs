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
        private readonly IAddressRepository _repository;
        //inject AutoMapper at runtime into address controller:
        private readonly IMapper _mapper;

        public AddressesController(IAddressRepository addressRepository, IMapper mapper)
        {
            _repository = addressRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of Addresses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAddresses()
        {
            try
            {
                //get all addresses saved until now
                var addresses = await _repository.GetAllAddresses();

            
                //transfer all the data to dto
                var addresesDTO =_mapper.Map<IEnumerable<TblAddressDTO>>(addresses);

                //display status code
                return Ok(addresesDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }
        }

        /// <summary>
        /// Get single Address.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAddress(int id)
        {
            try
            {
                //get the address as identified by its id
                var address = await _repository.GetAddress(id);

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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }

        }
        /// <summary>
        /// Create Address.
        /// </summary>
        /// <param name="addressDto"></param>
        /// <returns></returns>
        //POST: api/Address
        [HttpPost(Name = "CreateAddress")]
        public async Task<IActionResult> Post([FromBody] TblAddressDTO addressDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var address = _mapper.Map<TblAddress>(addressDto);

                    _repository.AddAddress(address);

                    if(await _repository.SaveAllAsync())
                    {
                        var newaddressDto = _mapper.Map<TblAddressDTO>(address);

                        //The CreatedAtRoute method is intended to return a URI to the newly created resource 
                        //when you invoke a POST method to store some new object
                        return CreatedAtRoute("GetAddress", new { id = newaddressDto.IdAddress }, newaddressDto);
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
        /// Update Address.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody]TblAddressDTO addressDto)
        {
            try
            {
                var address = await _repository.GetAddress(id);

                if (address == null)
                {
                    return NotFound($"Couldn't find an address of {id}");
                }

                //send destination inf to source=> update inf
                _mapper.Map(addressDto,address);

                if (await _repository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<TblAddressDTO>(address));
                }
                else
                {
                    return BadRequest();
                }
              
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }


        }
        /// <summary>
        /// Delete Address.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                //get the address from the db 
                var address = await _repository.GetAddress(id);

                if (address == null)
                { 
                    //in case it does exists display the msg
                    return NotFound($"Couldn’t found address of id {id}");
                }
                //remove the address
                _repository.DeleteAddress(address);

                if (await _repository.SaveAllAsync())
                {
                    return Ok();
                }
                
                    return BadRequest(string.Format("Could not delete address"));
                
               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }


        }
    }
}
