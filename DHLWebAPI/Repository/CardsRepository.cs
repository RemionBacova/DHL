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
    public class CardsRepository:ICardsRepository
    {
        private readonly DHLContext _context;

        public CardsRepository(DHLContext context)
        {
            _context = context;
        }

        //function to retrieve the  list with all cards
        public async Task<IEnumerable<TblCards>> GetCards()
        {
            //return all card
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
        public async Task<TblCards> AddCard(TblCards card)
        {
            //add the new card
            var cardNew = await _context.TblCards.AddAsync(card);
            //save changes
            await _context.SaveChangesAsync();
            //the new adr as 
            return cardNew.Entity;
        }

        //function to update the information of an card
        public async Task<TblCards> UpdateCard(TblCards card)
        {
            //retrieve the card we are trying to update
            var cardNew = await _context.TblCards.Where(c=>c.IdCard==card.IdCard)
                                                  .FirstOrDefaultAsync();
            //
            if (cardNew != null)
            {
                //if the card exist we can update its information
                cardNew.IdCustomer = card.IdCustomer;
                cardNew.Balance = card.Balance;
                cardNew.BalanceAvailable = card.BalanceAvailable;
                cardNew.CardStatus = card.CardStatus;
                cardNew.UpdateBy = card.UpdateBy;
                cardNew.UpdateDate = DateTime.Now;

            //save changes
             await _context.SaveChangesAsync();
                
            //return result
            return cardNew;
            }
            return null;
        }

        //function to remove an card
        public async void DeleteCard(string cardId)
        {
            //check if the card exist
            var cardRem= await _context.TblCards.Where(c => c.IdCard == cardId)
                                               .FirstOrDefaultAsync();
            if (cardRem != null)
            {
                //remove card
                _context.TblCards.Remove(cardRem);
                //save changes
                await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
