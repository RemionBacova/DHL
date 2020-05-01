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
    public class CustomerLogsController : ControllerBase
    {
        private readonly ICustomerLogsRepository _customerLogsRepository;
        private readonly IMapper _mapper;

        public CustomerLogsController(ICustomerLogsRepository customerLogsRepository, IMapper mapper)
        {
            this._customerLogsRepository = customerLogsRepository;
            this._mapper = mapper;
        }


        /// <summary>
        /// Get list of Customers Logs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomerLogs()
        {
            var list = _customerLogsRepository.GetCustomerLogs();
            var listDTO = new List<TblCustomerLogsDTO>();

            foreach (var item in list)
            {
                listDTO.Add(_mapper.Map<TblCustomerLogsDTO>(item));
            }

            return Ok(listDTO);
        }


        /// <summary>
        /// Get single customer logs.
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        [HttpGet("{Pid:long}", Name = "GetCustomerLogs")]
        public IActionResult GetCustomerLogs(long Pid)
        {
            var item = _customerLogsRepository.GetCustomerLogs(Pid);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = _mapper.Map<TblCustomerLogsDTO>(item);

            return Ok(itemDTO);
        }

        /// <summary>
        /// Create customer logs details(object).
        /// </summary>
        /// <param name="tblCustomerLogsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCustomerLogs([FromBody] TblCustomerLogsDTO tblCustomerLogsDTO)
        {
            if (tblCustomerLogsDTO == null)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblCustomerLogs>(tblCustomerLogsDTO);

            return CreatedAtRoute("GetCustomerLogs", new
            {
                customerLogsID = itemDTO.Pid
            });
        }

        /// <summary>
        /// Update single data in TblCustomerLogs
        /// </summary>
        /// <param name="customerLogID"></param>
        /// <param name="tblCustomerLogsDTO"></param>
        /// <returns></returns>
        [HttpPatch("{customerLogID:long}", Name = "UpdateCustomerLogs")]
        public IActionResult UpdateCustomerLogs
            (int customerLogID, [FromBody] TblCustomerLogsDTO tblCustomerLogsDTO)
        {
            if (tblCustomerLogsDTO == null || customerLogID != tblCustomerLogsDTO.Pid)
            {
                return BadRequest(ModelState);
            }

            var itemDTO = _mapper.Map<TblCustomerLogs>(tblCustomerLogsDTO);

            if (!_customerLogsRepository.UpdateCustomerLogs(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an customer logs object from the TblCustomerLogs
        /// </summary>
        /// <param name="customerLogID"></param>
        /// <returns></returns>
        [HttpDelete("{customerLogID:long}", Name = "DeleteCustomerLogs")]
        public IActionResult DeleteCustomerLogs(long customerLogID)
        {
            var itemDTO = _customerLogsRepository.GetCustomerLogs(customerLogID);

            if (!_customerLogsRepository.DeleteCustomerLogs(itemDTO))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
    
