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
            CreateMap<TblAddress, TblAddressDTO>()
                //mapping complex type to primitive ones
                .ForMember(dest => dest.AdressType, act => act.MapFrom(src => src.IdAddressTypeNavigation.AdressType))
                .ForMember(dest=>dest.Description,act=>act.MapFrom(src=>src.IdAddressTypeNavigation.Description))
                .ReverseMap();   //bidirectional mapping

            //mapping cards entity and its dto
            CreateMap<TblCards, TblCardsDTO>()
                        .ForMember(dest => dest.CardStatus, act => act.MapFrom(src => src.CardStatusNavigation.IdCardStatus))
                        .ForMember(dest=>dest.CardStatus,act=>act.MapFrom(src=>src.CardStatusNavigation.CardStatus))
                        .ReverseMap();

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
            CreateMap<TblTransactionLogs, TblTransactionLogsDTO>().ReverseMap();


        }
    }
}
