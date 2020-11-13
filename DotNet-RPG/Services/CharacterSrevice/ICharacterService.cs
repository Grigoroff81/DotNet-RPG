using DotNet_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.CharacterSrevice
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<Character>>> GetAllCharacters();
        Task<ServiceResponce<Character>> GetCharacterById(int id);
        Task<ServiceResponce<List<Character>>> AddCharacter(Character newCharacter);
    }
}
