using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Repository.IRepository
{
     public  interface IUserRepository
    {
        //function below are listed as below:
        //1.Retrieve all addresses
        //2.Retrieve only one address filtered by its id
        //3.Create a new address
        //4.Remove an address
        //5.Check if the request is successfully completed
        
        Task<IEnumerable<TblUser>> GetAllUsers();

        Task<TblUser> GetUser(int id);

        Task<TblUser> GetUserWithCredentials(string username,string password);

        void AddUser(TblUser user);

        Task<bool> SaveAllAsync();

    }
}
