using AutoMapper;
using DHLWebAPI.Models;
using DHLWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Mapper
{
    public class ClassMappings : Profile
    {
        public ClassMappings()
        {
            //mapping address entity and its dto
            CreateMap<TblAddress, TblAddressDTO>().ReverseMap();   //bidirectional mapping

            //mapping cards entity and its dto
            CreateMap<TblCard, TblCardsDTO>().ReverseMap();

            //Mapping functionality that maps TblCustomerAddress with its DTO => TblCustomerAddressDTO
            CreateMap<TblCustomerAddress, TblCustomerAddressDTO>().ReverseMap();

            //mapping customer discount entity and its dto
            CreateMap<TblCustomerDiscount, TblCustomerDiscountDTO>().ReverseMap();

            CreateMap<TblCustomerLog, TblCustomerLogsDTO>().ReverseMap();
            CreateMap<TblCustomer, TblCustomersDTO>().ReverseMap();
            CreateMap<TblCustomerStatus, TblCustomerStatusDTO>().ReverseMap();
            CreateMap<TblCustomerType, TblCustomerTypeDTO>().ReverseMap();
            CreateMap<TblDiscount, TblDiscountsDTO>().ReverseMap();
            CreateMap<TblDiscountType, TblDiscountTypeDTO>().ReverseMap();
            CreateMap<TblTransactionLog, TblTransactionLogsDTO>().ReverseMap();
            CreateMap<TblAddressType, TblAddressTypeDTO>().ReverseMap();
            CreateMap<TblCardStatus, TblCardStatusDTO>().ReverseMap();
            CreateMap<TblUser, TblUsersDTO>().ReverseMap();

        }
    }
}
