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
        //
        public byte IdCardStatus { get; set; }
        public string CardStatus { get; set; }

        //

    }
}
