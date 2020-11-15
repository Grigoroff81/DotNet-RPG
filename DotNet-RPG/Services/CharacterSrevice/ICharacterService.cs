using DotNet_RPG.DTOs.CharacterDTO;
using DotNet_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.CharacterSrevice
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);

    }
}
