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
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountRepository _discountsRepository;
        private IMapper _mapper;

        //private readonly IDiscountRepository _discountsRepository;
        //private readonly IMapper _mapper;


      private DiscountsController(IDiscountRepository discountRepository, IMapper mapper)
        {
            this._discountsRepository = discountRepository;
            this._mapper = mapper;
        }

    



        /// <summary>
        /// Get list of Discounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDiscounts()
        {
            var list = _discountsRepository.GetDiscounts();
            var listDTO = new List<TblDiscountsDTO>();

            foreach (var item in list)
            {
                listDTO.Add(_mapper.Map<TblDiscountsDTO>(item));
            }

            return Ok(listDTO);
        }


        /// <summary>
        /// Get single discount.
        /// </summary>
        /// <param name="IdDiscount"></param>
        /// <returns></returns>
        [HttpGet("{IdDiscount:alpha}", Name = "GetDiscounts")]
        public IActionResult GetDiscounts(int IdDiscount)
        {
            var item = _discountsRepository.GetDiscounts(IdDiscount);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = _mapper.Map<TblDiscountsDTO>(item);

            return Ok(itemDTO);
        }

        /// <summary>
        /// Create discount(object).
        /// </summary>
        /// <param name="tblDiscountsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDiscounts([FromBody] TblDiscountsDTO tblDiscountsDTO)
        {
            if (tblDiscountsDTO == null)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblDiscounts>(tblDiscountsDTO);

            return CreatedAtRoute("GetDiscounts", new
            {
                discountsID = itemDTO.IdDiscount
            });
        }

        /// <summary>
        /// Update single data in TblDiscounts
        /// </summary>
        /// <param name="discountsID"></param>
        /// <param name="tblDiscountsDTO"></param>
        /// <returns></returns>
        [HttpPatch("{discountsID:alpha}", Name = "UpdateDiscounts")]
        public IActionResult UpdateDiscounts
            (int discountsID, [FromBody] TblDiscountsDTO tblDiscountsDTO)
        {
            if (tblDiscountsDTO == null || discountsID != tblDiscountsDTO.IdDiscount)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblDiscounts>(tblDiscountsDTO);

            if (!_discountsRepository.UpdateDiscounts(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an discount object from the TblCustomerAddress
        /// </summary>
        /// <param name="discountsID"></param>
        /// <returns></returns>
        [HttpDelete("{discountsID:alpha}", Name = "DeleteDiscounts")]
        public IActionResult DeleteDiscounts(int discountsID)
        {
            var itemDTO = _discountsRepository.GetDiscounts(discountsID);

            if (!_discountsRepository.DeleteDiscounts(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}