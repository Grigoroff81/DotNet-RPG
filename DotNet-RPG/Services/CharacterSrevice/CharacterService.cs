using AutoMapper;
using DotNet_RPG.DTOs.CharacterDTO;
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
        private IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(i => i.Id) + 1;
            characters.Add(character);
            serviceResponce.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            serviceResponce.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
            serviceResponce.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(i => i.Id == id));
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();

            try
            {
                Character character = characters.FirstOrDefault(i => i.Id == updateCharacter.Id);
                character.Name = updateCharacter.Name;
                character.Class = updateCharacter.Class;
                character.Defence = updateCharacter.Defence;
                character.Hitpoints = updateCharacter.Hitpoints;
                character.Inelligence = updateCharacter.Inelligence;
                character.Strenght = updateCharacter.Strenght;

                serviceResponce.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message; 
            }
            
            return serviceResponce;
        }
    }
}
