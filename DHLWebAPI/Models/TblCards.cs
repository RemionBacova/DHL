﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHLWebAPI.Models
{
    public partial class TblCards
    {
        public TblCards()
        {
            TblTransactionLogs = new HashSet<TblTransactionLogs>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCustomer { get; set; }
        public int IdCard { get; set; }
        public float Balance { get; set; }
        public float BalanceAvailable { get; set; }
        public int CardStatus { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual TblCardStatus CardStatusNavigation { get; set; }
        public virtual TblCustomers IdCustomerNavigation { get; set; }
        public virtual TblUsers InsertByNavigation { get; set; }
        public virtual TblUsers UpdateByNavigation { get; set; }
        public virtual ICollection<TblTransactionLogs> TblTransactionLogs { get; set; }
    }
}
