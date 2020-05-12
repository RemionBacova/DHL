using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHLWebAPI.Models;

namespace DHLWebAPI.Repository.IRepository
{
    public interface ICardsRepository
    {
        ICollection<TblCards> GetCards();
        TblCards GetCard(int id);
        bool CreateCard(TblCards card);
        bool Save();
    }
}
