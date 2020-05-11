
using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Models.JWT;
using DHLWebAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DHLContext _context;
        //jwt
        private readonly JWTSettings _jwtsettings;


          public UserRepository(DHLContext context, IOptions<JWTSettings> jwtsettings)
            {
                _context = context;
                _jwtsettings = jwtsettings.Value;
            }

        public void AddToken(TblRefreshToken token)
        {
            _context.TblRefreshTokens.AddAsync(token);
        }

        public async void AddUser(TblUser user)
        {
            _context.TblUsers.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TblUser>> GetAllUsers()
        {
            //return all user registered
            return await _context.TblUsers.ToListAsync();
        }

        public async Task<TblRefreshToken> GetToken(string refreshToken)
        {
           var model = _context.TblRefreshTokens.Where(rt => rt.Token == refreshToken)
                                                .OrderByDescending(rt => rt.ExpiryDate)
                                                .FirstOrDefault();
            return  model;
        }

        public async Task<TblUser> GetUser(int id)
        {
            return await _context.TblUsers.Where(u => u.IdUser == id)
                 .FirstOrDefaultAsync();
                
        }

        public async Task<TblUser> GetUserWithCredentials(string username, string password)
        {
         return await _context.TblUsers.Where(u => u.Username == username && u.Password == password)
                 .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //generate access token 
        public string GenerateAccessToken(int userId)
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

        //generate refresh token
        public TblRefreshToken GenerateRefreshToken()
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

        //validating refresh token
        public async Task<bool> ValidateRefreshTokenAsync(TblUser user, string refreshToken)
        {

            TblRefreshToken refreshTokenUser = await GetToken(refreshToken);

            if (refreshTokenUser != null && refreshTokenUser.IdUser == user.IdUser
                && refreshTokenUser.ExpiryDate > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }

        //get user from access token
        public async Task<TblUser> GetUserFromAccessToken(string accessToken)
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

                    return await _context.TblUsers.Where(u => u.IdUser == Convert.ToInt32(userId)).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                return new TblUser();
            }

            return new TblUser();
        }

    }

}

