using System;
using System.Collections.Generic;

namespace DHLWebAPI.Models
{
    public partial class TblProfilePermission
    {
        public string ProfileSetName { get; set; }
        public int IdProfile { get; set; }
        public string ProfileCode { get; set; }

        public virtual TblToolPermission IdProfileNavigation { get; set; }
    }
}
