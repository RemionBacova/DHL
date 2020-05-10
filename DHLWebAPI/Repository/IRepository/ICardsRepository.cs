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
        //4.Check if the request is successfully completed
       
        Task<IEnumerable<TblCard>> GetAllCards();
        Task<TblCard> GetCard(string id);
        void AddCard(TblCard card);
  
        Task<bool> SaveAllAsync();
    }
}
