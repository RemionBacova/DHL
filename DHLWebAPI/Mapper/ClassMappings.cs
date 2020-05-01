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
            CreateMap<TblAddress, TblCardDTO>().ReverseMap();

            //mapping cards entity and its dto
            CreateMap<TblCards, TblCardsDTO>().ReverseMap();

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
