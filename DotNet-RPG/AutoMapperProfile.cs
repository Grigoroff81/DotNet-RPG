using AutoMapper;
using DotNet_RPG.DTOs.CharacterDTO;
using DotNet_RPG.DTOs.UserDTO;
using DotNetRpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            //CreateMap<User, UserRegisterDto>();
        }
    }
}
