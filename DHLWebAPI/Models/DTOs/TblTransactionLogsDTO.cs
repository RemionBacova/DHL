﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblTransactionLogsDTO
    {
        public int Pid { get; set; }
        public int IdCustomer { get; set; }
        public int? IdCard { get; set; }
        public byte TransactionType { get; set; }
        public byte TransactionStatus { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public float Value { get; set; }
        public long? Awb { get; set; }
        public bool Awbstatus { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int? IdTool { get; set; }
    }
}
