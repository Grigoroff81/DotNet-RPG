using DotNet_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.CharacterSrevice
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {Id =1, Name = "Sam"}
        };

        public async Task<ServiceResponce<List<Character>>> AddCharacter(Character newCharacter)
        {
            ServiceResponce<List<Character>> serviceResponce = new ServiceResponce<List<Character>>();
            characters.Add(newCharacter);
            serviceResponce.Data = characters;
            return serviceResponce;
        }

        public async Task<ServiceResponce<List<Character>>> GetAllCharacters()
        {
            ServiceResponce<List<Character>> serviceResponce = new ServiceResponce<List<Character>>();
            serviceResponce.Data = characters;
            return serviceResponce;
        }

        public async Task<ServiceResponce<Character>> GetCharacterById(int id)
        {
            ServiceResponce<Character> serviceResponce = new ServiceResponce<Character>();
            serviceResponce.Data = characters.FirstOrDefault(i => i.Id == id);
            return serviceResponce;
        }
    }
}
