using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblCustomersDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCustomer { get; set; }
        public int CustomerType { get; set; }
        public int CustomerStatus { get; set; }
        public string Channel { get; set; }
        public string CompanyName { get; set; }
        public string Iva { get; set; }
        public string Sdi { get; set; }
        public string ContactName { get; set; }
        public string FiscalCode { get; set; }
        public string Pec { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? IdDiscount { get; set; }
    }
}
