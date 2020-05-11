using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DHLWebAPI.Models.DTOs;
using DHLWebAPI.Models.JWT;
using DHLWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DHLWebAPI.Models;


namespace DHLWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //inject repository pattern for address
        private readonly IUserRepository _repository;
        //inject AutoMapper at runtime into address controller:
        private readonly IMapper _mapper;
        
        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        // GET: api/Users
        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                //get all addresses saved until now
                var users = await _repository.GetAllUsers();

                //transfer all the data to dto
                var usersDTO = _mapper.Map<IEnumerable<TblUsersDTO>>(users);

                //display status code
                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }


        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<TblUsersDTO>> GetUser(int id)
        {
            //get user
            var user = await _repository.GetUser(id);

            //dispay not found code in case the user wasn't returned
            if (user == null) return NotFound();

            //return user
            return Ok(_mapper.Map<TblUsersDTO>(user));

        }

        // POST: api/Users
        [HttpPost("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] TblUsersDTO userDto)
        {
            try
            {
                var user = await _repository.GetUserWithCredentials(userDto.Username, userDto.Password);

                UserWithToken userWithToken = null;

                if (user != null)
                {
                    TblRefreshToken refreshToken = _repository.GenerateRefreshToken();
                    _repository.AddToken(refreshToken);

                    userWithToken = new UserWithToken(user);
                    userWithToken.RefreshToken = refreshToken.Token;
                }

                if (userWithToken == null)
                {
                    return NotFound();
                }

                //sign your token here here..
                userWithToken.AccessToken = _repository.GenerateAccessToken(user.IdUser);
                return userWithToken;
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }


        }

        // GET: api/Users
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<UserWithToken>> RefreshToken([FromBody] RefreshRequest refreshRequest)
        {
            try
            {
                TblUser user = await _repository.GetUserFromAccessToken(refreshRequest.AccessToken);

                if (user != null && await _repository.ValidateRefreshTokenAsync(user, refreshRequest.RefreshToken))
                {
                    UserWithToken userWithToken = new UserWithToken(user);
                    userWithToken.AccessToken = _repository.GenerateAccessToken(user.IdUser);

                    return userWithToken;
                }

                return null;
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }
           
        }

        // GET: api/Users
        [HttpPost("GetUserByAccessToken")]
        public async Task<ActionResult<TblUser>> GetUserByAccessToken([FromBody] string accessToken)
        {
            try
            {
                 TblUser user = await _repository.GetUserFromAccessToken(accessToken);

            if (user != null)
            {
                return user;
            }

            return null;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Explanation: {ex.Message} ");
            }
           
        }

    }  
}

