using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICardsRepository
    {
        //function to retrieve the  list with all cards
        Task<IEnumerable<TblCards>> GetCards();

        //function to retrieve only one card filtered by its id
        Task<TblCards> GetCard(string cardId);

        //function to create a new  card
        Task<TblCards> AddCard(TblCards card);

        //function to update the information of an card
        Task<TblCards> UpdateCard(TblCards card);

        //function to remove an card
        void DeleteCard(string cardId);

        //
        Task<bool> SaveAllAsync();
    }
}
