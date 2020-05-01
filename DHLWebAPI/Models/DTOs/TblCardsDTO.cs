using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblCardsDTO
    {
        public string IdCustomer { get; set; }
        public string IdCard { get; set; }
        public float Balance { get; set; }
        public float BalanceAvailable { get; set; }
        public byte CardStatus { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }

    }
}
