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
            CreateMap<TblCustomerAddress, TblCustomerAddressDTO>().ReverseMap();
        }
    }
}
