//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using DHLWebAPI.Models.DTOs;
//using DHLWebAPI.Models.JWT;
//using DHLWebAPI.Repository.IRepository;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;

//namespace DHLWebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        //inject repository pattern for address
//        private readonly IUserRepository _repository;
//        //inject AutoMapper at runtime into address controller:
//        private readonly IMapper _mapper;
//        //jwt
//        private readonly JWTSettings _jwtsettings;

//        public UsersController(IUserRepository repository, IMapper mapper, IOptions<JWTSettings> jwtsettings)
//        {
//            _repository = repository;
//            _mapper = mapper;
//            _jwtsettings = jwtsettings.Value;
//        }
//        // GET: api/Users
//        [HttpGet("GetUsers")]
//        public async Task<ActionResult<IEnumerable<TblUsersDTO>>> GetUsers()
//        {
//            //get all addresses saved until now
//            var users = await _repository.GetAllUsers();

//            if (users == null)
//            {
//                //if there are no addresses found display the msg
//                return NotFound($"Couldn't find any user from the database");
//            }
//            //transfer all the data to dto
//            var usersDTO = _mapper.Map<IEnumerable<TblUsersDTO>>(users);

//            //display status code
//            return Ok(usersDTO);
//        }

//        // GET: api/Users/5
//        [HttpGet("{id}", Name = "GetUser")]
//        public async Task<ActionResult<TblUsersDTO>> GetUser(int id)
//        {
//            //get user
//            var user = await _repository.GetUser(id);
           
//            //dispay not found code in case the user wasn't returned
//            if (user == null) return NotFound();

//            //return user
//            return Ok(_mapper.Map<TblUsersDTO>(user));

//        }

//        // POST: api/Users
//        [HttpPost("Login")]
//        public async Task<ActionResult<UserWithToken>> Login([FromBody] TblUsersDTO userDto)
//        {
//            var user = await _repository.GetUserWithCredentials(userDto.Username, userDto.Password);
//            //UserWithToken userWithToken = null;
//            if (user != null)
//            {
//                RefreshToken refreshToken = GenerateRefreshToken();
//                user.RefreshTokens.Add(refreshToken);
//                await _context.SaveChangesAsync();

//                userWithToken = new UserWithToken(user);
//                userWithToken.RefreshToken = refreshToken.Token;
//            }

//            if (userWithToken == null)
//            {
//                return NotFound();
//            }

//            //sign your token here here..
//            userWithToken.AccessToken = GenerateAccessToken(user.UserId);
//            return userWithToken;
//        }



//    }
//}
