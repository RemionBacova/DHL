using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHLWebAPI.Models;

namespace DHLWebAPI.Models.JWT
{
    public class UserWithToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(TblUser user)
        {
            //this.IdUser = user.IdUser;
            //this.ContactName = user.ContactName;
            //this.TitleofCourtest = user.TitleOfCourtesy;
            //this.TitleOfCourtesy = user.TitleOfCourtesy;
            //this.Birthdate = user.Birthdate;
            //this.Hiredate = user.Hiredate;
            //this.Phone = user.Phone;
            //this.Email = user.Email;
            //this.Username = user.Username;


        }
    }
}
