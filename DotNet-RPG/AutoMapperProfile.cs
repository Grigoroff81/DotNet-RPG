using AutoMapper;
using DotNet_RPG.DTOs.CharacterDTO;
using DotNet_RPG.DTOs.SkillDto;
using DotNet_RPG.DTOs.UserDTO;
using DotNet_RPG.DTOs.WeaponDto;
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
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(cs => cs.Skill)));
            CreateMap<AddCharacterDto, Character>();
            //CreateMap<User, UserRegisterDto>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
        }
    }
}
