using DotNet_RPG.DTOs.CharacterDTO;
using DotNet_RPG.DTOs.CharacterSkillDto;
using DotNetRpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponce<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkillDto);
    }
}
