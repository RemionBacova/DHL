using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHLWebAPI.Data;
using DHLWebAPI.Models;
using DHLWebAPI.Repository.IRepository;

namespace DHLWebAPI.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DHLContext db;

        public AddressRepository(DHLContext db)
        {
            this.db = db;
        }

        public TblAddress GetAddress(int id) => db.TblAddress.FirstOrDefault(o => o.IdAddress == id);
        public ICollection<TblAddress> GetAddresses() => db.TblAddress.OrderBy(o => o.IdAddress).ToList();
        public bool CreateAddress(TblAddress address)
        {
            db.TblAddress.Add(address);
            return Save();
        }
        public bool DeleteAddress(TblAddress address)
        {
            db.TblAddress.Remove(address);
            return Save();
        }

        public bool UpdateAddress(TblAddress address)
        {
            db.TblAddress.Update(address);
            return Save();
        }
        public bool Save() => db.SaveChanges() >= 0 ? true : false;
    }
}
