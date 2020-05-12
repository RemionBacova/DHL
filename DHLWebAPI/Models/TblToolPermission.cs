using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblToolPermission
    {
        public TblToolPermission()
        {
            TblProfilePermission = new HashSet<TblProfilePermission>();
            TblTools = new HashSet<TblTools>();
        }

        public int IdProfile { get; set; }
        public string ProfileCode { get; set; }

        public virtual ICollection<TblProfilePermission> TblProfilePermission { get; set; }
        public virtual ICollection<TblTools> TblTools { get; set; }
    }
}
