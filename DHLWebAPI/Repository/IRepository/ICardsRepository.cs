using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICardsRepository
    {
        //function below are listed as below:
        //1.Retrieve all card
        //2.Retrieve only one card filtered by its id
        //3.Create a new card
        //4.Update the information of a card
        //5.Remove a card
        //6.Check if the request is successfully completed
       
        Task<IEnumerable<TblCards>> GetCards();
        Task<TblCards> GetCard(string cardId);
        Task<TblCards> AddCard(TblCards card);
        Task<TblCards> UpdateCard(TblCards card);
        void DeleteCard(string cardId);
        Task<bool> SaveAllAsync();
    }
}
