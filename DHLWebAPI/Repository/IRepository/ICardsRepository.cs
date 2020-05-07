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
        //4.Remove a card
        //5.Check if the request is successfully completed
       
        Task<IEnumerable<TblCards>> GetAllCards();
        Task<TblCards> GetCard(string id);
        void AddCard(TblCards card);
        void DeleteCard(TblCards card);
        Task<bool> SaveAllAsync();
    }
}
