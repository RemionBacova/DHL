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
            CreateMap<TblAddress, TblAddressDTO>().ReverseMap();

            //mapping address type entity and its dto
            CreateMap<TblAddressType, TblAddressTypeDTO>().ReverseMap();

            //mapping cards entity and its dto
            CreateMap<TblCards, TblCardsDTO>().ReverseMap();

            //mapping card status entity and its dto
            CreateMap<TblCardStatus, TblCardStatusDTO>().ReverseMap();

            //Mapping functionality that maps TblCustomerAddress with its DTO => TblCustomerAddressDTO
            CreateMap<TblCustomerAddress, TblCustomerAddressDTO>().ReverseMap();

            //mapping customer discount entity and its dto
            CreateMap<TblCustomerDiscount, TblCustomerDiscountDTO>().ReverseMap();

            CreateMap<TblCustomerLogs, TblCustomerLogsDTO>().ReverseMap();
            CreateMap<TblCustomers, TblCustomersDTO>().ReverseMap();
            CreateMap<TblCustomerStatus, TblCustomerStatusDTO>().ReverseMap();
            CreateMap<TblCustomerType, TblCustomerTypeDTO>().ReverseMap();
            CreateMap<TblDiscounts, TblDiscountsDTO>().ReverseMap();
            CreateMap<TblDiscountType, TblDiscountTypeDTO>().ReverseMap();

        }   
    }
}
