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

        public async Task<ActionResult> GetCards()
        {
            try
            {
                var cards = await _cardRepository.GetCards();
                if (cards == null)
                {
                    return NotFound($"Couldn't find any cards from the database");
                }
                var cardsDTO = new List<TblCardsDTO>();

                foreach (var card in cards)
                {
                    cardsDTO.Add(_mapper.Map<TblCardsDTO>(card));
                }
                 return Ok(cardsDTO);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            
        }

        // GET: api/Card/5
        [HttpGet("GetCard/{id}")]
        public async Task<ActionResult> GetCard(string id)
        {
            try
            {
                var card = await _cardRepository.GetCard(id);

                if (card == null)
                {
                    return NotFound($"Card of {id} was not found");

                }

                return Ok(_mapper.Map<TblCardsDTO>(card));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //POST: api/Card
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] TblCardsDTO cardDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var card = _mapper.Map<TblCards>(cardDto);

                await _cardRepository.AddCard(card);

                await _cardRepository.SaveAllAsync();

                //The CreatedAtRoute method is intended to return a URI to the newly created resource 
                //when you invoke a POST method to store some new object
                return CreatedAtRoute("GetCards", new
                {
                    cardID = card.IdCard
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(string id, [FromBody]TblCardsDTO cardDto)
        {
            try
            {
                var card = _mapper.Map<TblCards>(cardDto);
               
                card= await _cardRepository.GetCard(id);

                if (card == null)
                {
                    return NotFound($"Couldn't find a card of {id}");
                }

                await _cardRepository.UpdateCard(card);

                if (await _cardRepository.SaveAllAsync())
                {
                    return Ok();
                }
                return BadRequest(string.Format("Could not update card: {0}"));

            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }



        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(string id)
        {
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
