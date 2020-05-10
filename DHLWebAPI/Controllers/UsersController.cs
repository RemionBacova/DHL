using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DHLWebAPI.Models.DTOs;
using DHLWebAPI.Models.JWT;
using DHLWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using DHLWebAPI.Models;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;

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
        //jwt
        private readonly JWTSettings _jwtsettings;

        public UsersController(IUserRepository repository, IMapper mapper, IOptions<JWTSettings> jwtsettings)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtsettings = jwtsettings.Value;
        }
        // GET: api/Users
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<TblUsersDTO>>> GetUsers()
        {
            //get all addresses saved until now
            var users = await _repository.GetAllUsers();

            if (users == null)
            {
                //if there are no addresses found display the msg
                return NotFound($"Couldn't find any user from the database");
            }
            //transfer all the data to dto
            var usersDTO = _mapper.Map<IEnumerable<TblUsersDTO>>(users);

            //display status code
            return Ok(usersDTO);
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
        public async Task<ActionResult> Login([FromBody] TblUsersDTO userDto)
        {
            var user = await _repository.GetUserWithCredentials(userDto.Username, userDto.Password);
           
            UserWithToken userWithToken = null;
            
            if (user != null)
            {
                TblRefreshToken refreshToken = GenerateRefreshToken();
                _repository.AddToken(refreshToken);
                
                userWithToken = new UserWithToken(user);
                userWithToken.RefreshToken = refreshToken.Token;
            }

            if (userWithToken == null)
            {
                return NotFound();
            }

            //sign your token here here..
            userWithToken.AccessToken = GenerateAccessToken(user.IdUser);
            return userWithToken;
        }


        // GET: api/Users
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<UserWithToken>> RefreshToken([FromBody] RefreshRequest refreshRequest)
        {
            TblUser user = await GetUserFromAccessToken(refreshRequest.AccessToken);

            if (user != null && await ValidateRefreshTokenAsync(user, refreshRequest.RefreshToken))
            {
                UserWithToken userWithToken = new UserWithToken(user);
                userWithToken.AccessToken = GenerateAccessToken(user.IdUser);

                return userWithToken;
            }

            return null;
        }

        // GET: api/Users
        [HttpPost("GetUserByAccessToken")]
        public async Task<ActionResult<TblUser>> GetUserByAccessToken([FromBody] string accessToken)
        {
            TblUser user = await GetUserFromAccessToken(accessToken);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        private async Task<bool> ValidateRefreshTokenAsync(TblUser user, string refreshToken)
        {

            TblRefreshToken refreshTokenUser = await _repository.GetToken(refreshToken);

            if (refreshTokenUser != null && refreshTokenUser.IdUser == user.IdUser
                && refreshTokenUser.ExpiryDate > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }

        private async Task<TblUser> GetUserFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.Name)?.Value;
                                 
                        //return await _context.Users.Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                return new TblUser();
            }

            return new TblUser();
        }

        private TblRefreshToken GenerateRefreshToken()
        {
            TblRefreshToken refreshToken = new TblRefreshToken();

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            refreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(6);

            return refreshToken;
        }

        private string GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

