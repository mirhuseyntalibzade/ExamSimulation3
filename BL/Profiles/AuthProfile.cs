using AutoMapper;
using BL.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginDTO, IdentityUser>().ReverseMap();
            CreateMap<RegisterDTO, IdentityUser>().ReverseMap();
        }
    }
}
