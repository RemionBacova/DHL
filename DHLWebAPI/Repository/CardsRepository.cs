using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;

namespace DHLWebAPI.Repository
{
    public class CardsRepository : ICardsRepository
    {
        private readonly DHLContext db;

        public CardsRepository(DHLContext db)
        {
            this.db = db;
        }

        public TblCards GetCard(int id) => db.TblCards.FirstOrDefault(o => o.IdCard == id);

        public ICollection<TblCards> GetCards() => db.TblCards.OrderBy(o => o.IdCard).ToList();

        public bool Save() => db.SaveChanges() >= 0 ? true : false;
        public bool CreateCard(TblCards card)
        {
            db.TblCards.Add(card);
            return Save();
        }
    }
}
