
using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository
{
    public class CustomerDiscountsRepository : ICustomerDiscountsRepository
    {
        private readonly DHLContext db;

        //Dependenct Injection for DHLContext
        public CustomerDiscountsRepository(DHLContext db)
        {
            this.db = db;
        }
        //Below are different crud operations implemented by the ICustomerDiscountRepository interface
        public bool CreateCusDiscounts(TblCustomerDiscount cusdiscounts)
        {
            db.TblCustomerDiscount.Add(cusdiscounts);
            return Save();
        }

        public bool DeleteCusDiscounts(TblCustomerDiscount cusdiscounts)
        {
            db.TblCustomerDiscount.Remove(cusdiscounts);
            return Save();
        }

        public TblCustomerDiscount GetCustomerDiscount(int customerID)
        {
            return db.TblCustomerDiscount.FirstOrDefault(o => o.IdCustomer.Equals(customerID));

        }

        public TblCustomerDiscount GetCustomerDiscounts(string tokenString)
        {
            return db.TblCustomerDiscount.FirstOrDefault(o => o.CodeForActive.Equals(tokenString));
        }

        public ICollection<TblCustomerDiscount> GetCustomerDiscount()
        {
            return db.TblCustomerDiscount.ToList();
        }
        public ICollection<TblCustomerDiscount> GetCustomerDiscounts()
        {
            return db.TblCustomerDiscount.ToList();
        }


        public bool UpdateCusDiscounts(TblCustomerDiscount cusdiscounts)
        {
            db.TblCustomerDiscount.Update(cusdiscounts);
            return Save();
        }

        public bool Save()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }
    }
}
