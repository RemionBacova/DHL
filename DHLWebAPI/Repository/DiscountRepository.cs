
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DHLContext db;

        //Dependenct Injection for DHLContext
        public DiscountRepository(DHLContext db)
        {
            this.db = db;
        }
        //Below are different crud operations implemented by the IDiscountRepository interface
        public bool CreateDiscounts(TblDiscounts discounts)
        {
            db.TblDiscounts.Add(discounts);
            return Save();
        }

        public bool DeleteDiscounts(TblDiscounts discounts)
        {
            db.TblDiscounts.Remove(discounts);
            return Save();
        }

        public TblDiscounts GetDiscounts(int discountsID)
        {
            return db.TblDiscounts.FirstOrDefault(o => o.IdDiscount.Equals(discountsID));
        }

        public ICollection<TblDiscounts> GetDiscounts()
        {
            return db.TblDiscounts.ToList();
        }

        public bool UpdateDiscounts(TblDiscounts discounts)
        {
            db.TblDiscounts.Update(discounts);
            return Save();
        }

        public bool Save()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }
    }
}
