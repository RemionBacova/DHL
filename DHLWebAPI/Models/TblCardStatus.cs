using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCardStatus
    {
        public TblCardStatus()
        {
            TblCard = new HashSet<TblCard>();
        }

        public int IdCardStatus { get; set; }
        public string CardStatus { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblUser UpdateByNavigation { get; set; }
        public virtual ICollection<TblCard> TblCard { get; set; }
    }
}
