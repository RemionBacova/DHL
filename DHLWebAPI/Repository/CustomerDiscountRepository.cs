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
    public class CustomerDiscountRepository
    {

        private readonly DHLContext _context;

        public CustomerDiscountRepository(DHLContext context)
        {
            _context = context;
        }

      
    }
}
