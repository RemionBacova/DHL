using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblCardStatusDTO
    {
        public byte IdCardStatus { get; set; }
        public string CardStatus { get; set; }
        public int UpdateBy { get; set; }
    }
}
