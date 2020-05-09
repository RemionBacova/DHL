
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class CardsRepository:ICardsRepository
    {
        private readonly DHLContext _context;

        public CardsRepository(DHLContext context)
        {
            _context = context;
        }

        //function to retrieve the  list with all cards
        public async Task<IEnumerable<TblCards>> GetAllCards()
        {
            //return all cards
           return await _context.TblCards.ToListAsync();
        }
           

        //function to retrieve only one card filtered by its id
       public async Task<TblCards> GetCard(string cardId)
        {
            //return the card who matches the id
            return await _context.TblCards.Where(c => c.IdCard == cardId)
                                          .FirstOrDefaultAsync();
           
        }

        //function to create a new  card
        public async void AddCard(TblCards card)
        {
            //add the new card
            await _context.TblCards.AddAsync(card);
            //save changes
            await _context.SaveChangesAsync(); 
        }

        //function to remove an card
        public async void DeleteCard(TblCards card)
        {
                //remove card
                _context.TblCards.Remove(card);
                //save changes
                await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
