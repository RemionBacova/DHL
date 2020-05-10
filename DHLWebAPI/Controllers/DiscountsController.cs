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
    public class DiscountsController : ControllerBase
    {
        
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountRepository discountRepository, IMapper mapper)
        {
            _repository = discountRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of Discounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetDiscounts()
        {
            try
            {
               
                var discounts = await _repository.GetAllDiscounts();
                var discDTO = _mapper.Map<IEnumerable<TblDiscountsDTO>>(discounts
                    );
                return Ok(discDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }
        }

        /// <summary>
        /// Get single Discount.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDiscounts(int id)
        {
            try
            {
               
                var disc = await _repository.GetDiscounts(id);

                if (disc == null)
                {
           
                    return NotFound($"Discount of {id} was not found");

                }
                //transfer the data of source into dto 
                var discDto = _mapper.Map<TblDiscountsDTO>(disc);

                //display the msg
                return Ok(discDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }

        }
        /// <summary>
        /// Create Discount.
        /// </summary>
        /// <param name="discDto"></param>
        /// <returns></returns>
        //POST: api/Discounts
        [HttpPost(Name = "CreateDiscount")]
        public async Task<IActionResult> Post([FromBody] TblDiscountsDTO discDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var disc = _mapper.Map<TblDiscount>(discDto);

                    _repository.AddDiscount(disc);

                    if (await _repository.SaveAllAsync())
                    {
                        var newdiscDto = _mapper.Map<TblDiscountsDTO>(disc);

                        return Ok(newdiscDto);      
                //        return CreatedAtRoute("GetDiscounts", new { id = newdiscDto.IdDiscount}, newdiscDto);
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
        /// Update Discounts.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="discDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody]TblDiscountsDTO discDto)
        {
            try
            {
                var disc = await _repository.GetDiscounts(id);

                if (disc == null)
                {
                    return NotFound($"Couldn't find an discount of {id}");
                }

               
                _mapper.Map(discDto, disc);

                if (await _repository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<TblDiscountsDTO>(disc));
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
        /// Delete Discounts.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisocunt(int id)
        {
            try
            {
                
                var disc = await _repository.GetDiscounts(id);

                if (disc == null)
                {
               
                    return NotFound($"Couldn’t found discounts of id {id}");
                }
                //remove the discount
                _repository.DeleteDiscount(disc);

                if (await _repository.SaveAllAsync())
                {
                    return Ok();
                }

                return BadRequest(string.Format("Could not delete discount"));


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }


        }
    }
}
