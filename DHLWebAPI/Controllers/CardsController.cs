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
        private readonly ICardsRepository _cardRepository;
        //inject AutoMapper at runtime into card controller:
        private readonly IMapper _mapper;

        public CardsController(ICardsRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        //GET:api/Cards
        [HttpGet("GetCards")]

        public async Task<ActionResult<IEnumerable<TblCards>>> GetCards()
        {
            try
            {
                var cards = await _cardRepository.GetCards();
                var cardsDTO = new List<TblCardsDTO>();

                foreach (var card in cards)
                {
                    cardsDTO.Add(_mapper.Map<TblCardsDTO>(card));
                }

                if (cardsDTO != null)
                {
                    return Ok(cardsDTO);
                }
                return BadRequest();
                
   
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            
        }

        // GET: api/Card/5
        [HttpGet("GetCard/{id}")]
        public async Task<ActionResult<IEnumerable<TblCards>>> GetCard(string id)
        {
            var card = await _cardRepository.GetCard(id);

            if (card == null)
            {
                return NotFound($"Card of {id} was not found");

            }

            return Ok(_mapper.Map<TblCardsDTO>(card));
        }

        //POST: api/Card
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] TblCards model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var card = await _cardRepository.AddCard(model);

            //The CreatedAtRoute method is intended to return a URI to the newly created resource 
            //when you invoke a POST method to store some new object
            return CreatedAtRoute("GetCards", new
            {
                cardID = card.IdCard
            });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(string id, [FromBody]TblCards model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldCard = await _cardRepository.GetCard(id);
            if (oldCard == null)
            {
                return NotFound($"Couldn't find a card of {id}");
            }

            _mapper.Map(model, oldCard);

            if (await _cardRepository.SaveAllAsync())
            {
                return Ok(_mapper.Map<TblCardsDTO>(oldCard));
            }
            return BadRequest(string.Format("Could not update card: {0}"));


        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(string id)
        {
            var oldCard = _cardRepository.GetCard(id);
            if (oldCard == null)
            {
                return NotFound($"Couldn’t found card of id {id}");
            }
            _cardRepository.DeleteCard(id);

            if (await _cardRepository.SaveAllAsync())
            {
                return Ok();
            }

            return NoContent();
        }

    }
}
