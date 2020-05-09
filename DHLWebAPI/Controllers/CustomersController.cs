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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomersRepository customersRepository, IMapper mapper)
        {
            _repository = customersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customersList = _repository.GetCustomers();
            var customersListDTO = new List<TblCustomersDTO>();

            foreach (var item in customersList)
            {
                customersListDTO.Add(_mapper.Map<TblCustomersDTO>(item));
            }

            return Ok(customersListDTO);
        }

        [HttpGet("{customerId:int}")]
        public IActionResult GetCustomer(int customerId)
        {
            var customer = _repository.GetCustomer(customerId);
            var customerDTO = _mapper.Map<TblCustomersDTO>(customer);

            return Ok(customerDTO);
        }

    }
}