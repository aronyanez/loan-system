using AutoMapper;
using LoanSystem.Core.DTOs;
using LoanSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanSystem.Infrastructure.Mappings
{
   public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
