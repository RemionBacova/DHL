using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblUserType
    {
        public TblUserType()
        {
            TblUser = new HashSet<TblUser>();
        }

        public int IdUserType { get; set; }
        public string UserTypeTitle { get; set; }
        public string Description { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
