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
        private readonly ICardsRepository _repository;
        //inject AutoMapper at runtime into card controller:
        private readonly IMapper _mapper;

        public CardsController(ICardsRepository cardRepository, IMapper mapper)
        {
            _repository = cardRepository;
            _mapper = mapper;
        }

        //GET:api/Cards
        [HttpGet]
        [Route("{id}", Name= "GetCards")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var cards = await _repository.GetAllCards();

                if (cards == null)
                {
                    return NotFound($"Couldn't find any cards from the database");
                }

               var cardsDTO= _mapper.Map<IEnumerable<TblCardsDTO>>(cards);
                
               return Ok(cardsDTO);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            
        }

        // GET: api/Card/5
        [HttpGet]
        [Route("{id}", Name = "GetCard")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var card = await _repository.GetCard(id);

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
        public async Task<IActionResult> Post([FromBody] TblCardsDTO cardDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var card = _mapper.Map<TblCards>(cardDto);

                     _repository.AddCard(card);

                    if(await _repository.SaveAllAsync())
                    {
                        var newcardDTO= _mapper.Map<TblCardsDTO>(card);

                        //The CreatedAtRoute method is intended to return a URI to the newly created resource 
                        //when you invoke a POST method to store some new object
                        return CreatedAtRoute("GetCard", new
                        {
                            cardID = newcardDTO.IdCard
                        },newcardDTO);
                    }
                }
                
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]TblCardsDTO cardDto)
        {
            try
            {
               
                var card = await _repository.GetCard(id);

                if (card == null)
                {
                    return NotFound($"Couldn't find a card of {id}");
                }

                _mapper.Map(cardDto,card);

                if (await _repository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<TblCardsDTO>(card));
                }
                else
                {
                    return BadRequest(string.Format("Could not update card: {0}"));
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var card = await _repository.GetCard(id);
                if (card == null)
                {
                    return NotFound($"Couldn’t found card of id {id}");
                }
                _repository.DeleteCard(card);

                if (await _repository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<TblCardsDTO>(card));
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
