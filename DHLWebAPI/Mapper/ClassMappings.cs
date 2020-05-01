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
            CreateMap<TblAddress, TblAddressDTO>();

            //mapping address type entity and its dto
            CreateMap<TblAddressType, TblAddressTypeDTO>();

            //mapping cards entity and its dto
            CreateMap<TblCards, TblCardsDTO>();

            //mapping card status entity and its dto
            CreateMap<TblCardStatus, TblCardStatusDTO>();

            //Mapping functionality that maps TblCustomerAddress with its DTO => TblCustomerAddressDTO
            CreateMap<TblCustomerAddress, TblCustomerAddressDTO>().ReverseMap();

            //mapping customer discount entity and its dto
            CreateMap<TblCustomerDiscount, TblCustomerDiscountDTO>();

        }   
    }
}
