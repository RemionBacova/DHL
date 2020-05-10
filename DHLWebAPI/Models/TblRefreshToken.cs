using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblRefreshToken
    {
        public int TokenId { get; set; }
        public int IdUser { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual TblUser IdUserNavigation { get; set; }
    }
}
