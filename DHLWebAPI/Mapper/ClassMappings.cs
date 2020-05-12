using AutoMapper;
using DHLWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHLWebAPI.Models.DTOs;

namespace DHLWebAPI.Mapper
{
    public class ClassMappings : Profile
    {
        public ClassMappings()
        {
            CreateMap<TblAddress, TblAddressDTO>().ReverseMap();
            CreateMap<TblCards, TblCardsDTO>().ReverseMap();
            CreateMap<TblCustomerAddress, TblCustomerAddressDTO>().ReverseMap();
            CreateMap<TblCustomerDiscount, TblCustomerDiscountDTO>().ReverseMap();
            CreateMap<TblCustomerLogs, TblCustomerLogsDTO>().ReverseMap();
            CreateMap<TblCustomers, TblCustomersDTO>().ReverseMap();
            CreateMap<TblCustomerStatus, TblCustomerStatusDTO>().ReverseMap();
            CreateMap<TblCustomerType, TblCustomerTypeDTO>().ReverseMap();
            CreateMap<TblDiscounts, TblDiscountsDTO>().ReverseMap();
            CreateMap<TblDiscountType, TblDiscountTypeDTO>().ReverseMap();
            CreateMap<TblTransactionLogs, TblTransactionLogsDTO>().ReverseMap();
            CreateMap<TblAddressType, TblAddressTypeDTO>().ReverseMap();
            CreateMap<TblCardStatus, TblCardStatusDTO>().ReverseMap();
            CreateMap<TblUsers, TblUsersDTO>().ReverseMap();
        }
    }
}
