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
    public class CustomerDiscountsController : ControllerBase
    {
        private readonly ICustomerDiscountsRepository _customerDiscountsRepository;
        private IMapper _mapper;

        //private readonly IDiscountRepository _discountsRepository;
        //private readonly IMapper _mapper;


        private CustomerDiscountsController(ICustomerDiscountsRepository cusdiscountRepository, IMapper mapper)
        {
            this._customerDiscountsRepository = cusdiscountRepository;
            this._mapper = mapper;
        }





        /// <summary>
        /// Get list of CustomerDiscounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomerDiscount()
        {
            var list = _customerDiscountsRepository.GetCustomerDiscount();
            var listDTO = new List<TblCustomerDiscountDTO>();

            foreach (var item in list)
            {
                listDTO.Add(_mapper.Map<TblCustomerDiscountDTO>(item));
            }

            return Ok(listDTO);
        }


        /// <summary>
        /// Get single customerdiscount.
        /// </summary>
        /// <param name="IdCustomer"></param>
        /// <returns></returns>
        [HttpGet("{IdCustomer:int}", Name = "GetCustomerDiscount")]
        public IActionResult GeCustomerDiscount(int IdCustomer)
        {
            var item = _customerDiscountsRepository.GetCustomerDiscount(IdCustomer);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = _mapper.Map<TblCustomerDiscountDTO>(item);

            return Ok(itemDTO);
        }

        /// <summary>
        /// Get single customerdiscount by token
        /// </summary>
        /// <param name="tokenString"></param>
        /// <returns></returns>
        [HttpGet("{tokenString:string}", Name = "GetCustomerDiscounts")]
        public IActionResult GetCustomerDiscounts(string tokenString)
        {
            var item = _customerDiscountsRepository.GetCustomerDiscounts(tokenString);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = _mapper.Map<TblCustomerDiscountDTO>(item);

            return Ok(itemDTO);
        }

        /// <summary>
        /// Create customerdiscount(object).
        /// </summary>
        /// <param name="tblcustomerDiscountDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDiscounts([FromBody] TblCustomerDiscountDTO tblcustomerDiscountDTO)
        {
            if (tblcustomerDiscountDTO == null)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblCustomerDiscount>(tblcustomerDiscountDTO);

            return CreatedAtRoute("GetCustomerDiscounts", new
            {
                customerID = itemDTO.IdCustomer
            });
        }

        /// <summary>
        /// Update single data in TblCustomerDiscount
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="tblcustomerDiscountDTO"></param>
        /// <returns></returns>
        [HttpPatch("{customerID:int}", Name = "UpdateCusDiscounts")]
        public IActionResult UpdateCusDiscounts
            (int customerID, [FromBody] TblCustomerDiscountDTO tblcustomerDiscountDTO)
        {
            if (tblcustomerDiscountDTO == null /*|| customerID != tblcustomerDiscountDTO.IdCustomer*/)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblCustomerDiscount>(tblcustomerDiscountDTO);

            if (!_customerDiscountsRepository.UpdateCusDiscounts(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an discount object from the TblCustomerDiscounts
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [HttpDelete("{customerID:int}", Name = "DeleteCusDiscounts")]
        public IActionResult DeleteCusDiscounts(int customerID)
        {
            var itemDTO = _customerDiscountsRepository.GetCustomerDiscount(customerID);

            if (!_customerDiscountsRepository.DeleteCusDiscounts(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


    }
}