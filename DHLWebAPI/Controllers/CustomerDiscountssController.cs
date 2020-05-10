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
    public class CustomerDiscountssController : ControllerBase
    {
      
        private readonly ICustomerDiscountsRepository _repository;
        
        private readonly IMapper _mapper;

        public CustomerDiscountssController(ICustomerDiscountsRepository cusdiscRepository, IMapper mapper)
        {
            _repository = cusdiscRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of CustomerDiscounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllCusDisc()
        {
            try
            {
                
                var cusdiscs = await _repository.GetAllCusDisc();


                var cusdiscDTO = _mapper.Map<IEnumerable<TblCustomerDiscountDTO>>(cusdiscs);

                //display status code
                return Ok(cusdiscDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }
        }

        /// <summary>
        /// Get single CustomerDiscounts by IdDiscounts.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/CustomerDisocunts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCusDisc(int id)
        {
            try
            {
                
                var cusdisc = await _repository.GetCusDisc(id);

                if (cusdisc == null)
                {
                    //if the address does not exist display error message
                    return NotFound($"CustomerDiscounts of {id} was not found");

                }
                
                var cusdiscDto = _mapper.Map<TblCustomerDiscountDTO>(cusdisc);

               
                return Ok(cusdiscDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }

        }
        /// <summary>
        /// Create CustomerDiscount.
        /// </summary>
        /// <param name="cusdisDto"></param>
        /// <returns></returns>
        //POST: api/CustomerDisocunt
        [HttpPost(Name = "CreateCusDisc")]
        public async Task<IActionResult> Post([FromBody] TblCustomerDiscountDTO cusdisDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var cusdisc = _mapper.Map<TblCustomerDiscount>(cusdisDto);

                    _repository.AddCusDiscount(cusdisc);

                    if (await _repository.SaveAllAsync())
                    {
                        var newDto = _mapper.Map<TblCustomerDiscountDTO>(cusdisc);

                       
                        return CreatedAtRoute("GetCusDisc", new { id = newDto.IdDiscount }, newDto);
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
        /// Update CustomerDiscounts.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cusdiscDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerDiscount(int id, [FromBody]TblCustomerDiscountDTO cusdiscDto)
        {
            try
            {
                var cusdisc = await _repository.GetCusDisc(id);

                if (cusdisc == null)
                {
                    return NotFound($"Couldn't find an customerdiscount");
                }

               
                var newCusDisc = _mapper.Map(cusdiscDto, cusdisc);

                if (await _repository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<TblCustomerDiscountDTO>(newCusDisc));
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }


        }
        /// <summary>
        /// Delete CustomerDiscounts.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCusDisc(int id)
        {
            try
            {
                 
                var cusdisc = await _repository.GetCusDisc(id);

                if (cusdisc == null)
                {
                    
                    return NotFound($"Couldn’t found customerdiscounts in the database!");
                }
                
                _repository.DeleteCusDisc(cusdisc);

                if (await _repository.SaveAllAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(string.Format("Could not delete customerdiscounts"));
                }



            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }


        }
    }
}
