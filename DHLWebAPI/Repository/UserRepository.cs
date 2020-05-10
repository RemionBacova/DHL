﻿
using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DHLContext _context;
        public UserRepository(DHLContext context)
        {
            _context = context;
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
            return await _context.TblUsers.ToListAsync();
        }

        public async Task<TblRefreshToken> GetToken(string refreshToken)
        {
          return _context.TblRefreshTokens.Where(rt => rt.Token == refreshToken)
                                                .OrderByDescending(rt => rt.ExpiryDate)
                                                .FirstOrDefault();
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
    }
}
