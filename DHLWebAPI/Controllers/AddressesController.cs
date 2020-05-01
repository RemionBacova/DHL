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
        //inject repository pattern for card
        private readonly IAddressRepository _addressRepository;
        //inject AutoMapper at runtime into card controller:
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
            var addresses = await _addressRepository.GetAddresses();
            return Ok(_mapper.Map<IEnumerable<TblCardsDTO>>(addresses));
        }

        // GET: api/Address/5
        [HttpGet("GetAddress/{id}")]
        public async Task<ActionResult<IEnumerable<TblAddress>>> GetAddress(int id)
        {
            var card = await _addressRepository.GetAddress(id);

            if (card == null)
            {
                return NotFound($"Address of {id} was not found");

            }

            return Ok(_mapper.Map<TblCardsDTO>(card));
        }

        //POST: api/Address
        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] TblAddress model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var card = await _addressRepository.AddAddress(model);
           
            //The CreatedAtRoute method is intended to return a URI to the newly created resource 
            //when you invoke a POST method to store some new object
            return CreatedAtRoute("GetAddresses", new
            {
                addressID = card.IdAddress
            });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody]TblAddress model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldAddress = await _addressRepository.GetAddress(id);
            if(oldAddress==null)
            {
                return NotFound($"Couldn't find an card of {id}");
            }

            model.AddressLabel = oldAddress.AddressLabel;

            _mapper.Map(model, oldAddress);

            if (await _addressRepository.SaveAllAsync())
            {
                return Ok(_mapper.Map<TblAddress>(oldAddress));
            }
            return BadRequest(string.Format("Could not update  card: {0}"));


        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var oldAddress = _addressRepository.GetAddress(id);
            if (oldAddress == null) {
                return NotFound($"Couldn’t found card of id {id}");
            }
                _addressRepository.DeleteAddress(id);

            if (await _addressRepository.SaveAllAsync())
            {
                return Ok();
            }
            return NoContent();
        }
          
        }
    }
