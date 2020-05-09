using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblCardStatus
    {
        public TblCardStatus()
        {
            TblCards = new HashSet<TblCards>();
        }

        public int IdCardStatus { get; set; }
        public int CardStatus { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual ICollection<TblCards> TblCards { get; set; }
    }
}
