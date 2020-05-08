using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblUsersDTO
    {
        public int IdUser { get; set; }
        public string ContactName { get; set; }
        public int UserType { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

