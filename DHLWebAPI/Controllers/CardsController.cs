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
    public class CardsController : ControllerBase
    {
        //inject repository pattern for cards
        private readonly ICardsRepository repository;
        //inject AutoMapper at runtime into card controller:
        private readonly IMapper mapper;

        public CardsController(ICardsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get list of Cards.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCards()
        {
            var card = repository.GetCards();
            var cardDTO = new List<TblCardsDTO>();

            foreach (var item in card)
            {
                cardDTO.Add(mapper.Map<TblCardsDTO>(item));
            }

            return Ok(cardDTO);
        }
        /// <summary>
        /// Get a single Card.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetCard")]
        public IActionResult GetCard(int id)
        {
            var card = repository.GetCard(id);
            if (card == null)
            {
                return NotFound();
            }

            var cardDTO = mapper.Map<TblCardsDTO>(card);

            return Ok(cardDTO);
        }
        /// <summary>
        /// Create Card.
        /// </summary>
        /// <param name="cardDTO"></param>
        /// <returns></returns>
        //POST: api/Card
        [HttpPost(Name = "CreateCard")]
        public IActionResult CreateCard([FromBody] TblCardsDTO cardDTO)
        {
            var card = mapper.Map<TblCards>(cardDTO);
            repository.CreateCard(card);

            return Created("GetCard", cardDTO);
        }
    }
}
