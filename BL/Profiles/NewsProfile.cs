using AutoMapper;
using BL.DTOs.NewsDTOs;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class NewsProfile: Profile
    {
        public NewsProfile()
        {
            CreateMap<News, AddNewsDTO>().ReverseMap();
            CreateMap<News, UpdateNewsDTO>().ReverseMap();
            CreateMap<News, GetNewsDTO>().ReverseMap();
            CreateMap<UpdateNewsDTO, GetNewsDTO>().ReverseMap();
        }
    }
}
