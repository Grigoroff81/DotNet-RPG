using AutoMapper;
using DotNet_RPG.Data;
using DotNet_RPG.DTOs.CharacterDTO;
using DotNetRpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.CharacterSrevice
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            //new Character {Id =1, Name = "Sam"}
        };
        private readonly IMapper _mapper;
        private readonly DotNetRpgContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public CharacterService(IMapper mapper, DotNetRpgContext context, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            //character.Id = characters.Max(i => i.Id) + 1; not needed since database is in SQL Server
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            serviceResponce.Data = _context.Characters.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponce;
        }


        public async Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            List<Character> dbCharacters = await _context.Characters.Include(c=>c.Class)
                .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                .Include(c=>c.Weapon).Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponce.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
            Character dbCharacter = await _context.Characters
                .Include(c=>c.Class).Include(c=>c.Weapon)
                .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                .FirstOrDefaultAsync(i => i.Id == id && i.User.Id == GetUserId());
            serviceResponce.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();

            try
            {
                Character character = await _context.Characters
                    .Include(c=>c.User).FirstOrDefaultAsync(i => i.Id == updateCharacter.Id);
                if (character.User.Id == GetUserId())
                {
                    character.Name = updateCharacter.Name;
                    character.Class = updateCharacter.Class;
                    character.Defence = updateCharacter.Defence;
                    character.Hitpoints = updateCharacter.Hitpoints;
                    character.Inelligence = updateCharacter.Inelligence;
                    character.Strenght = updateCharacter.Strenght;

                    _context.Characters.Update(character);
                    await _context.SaveChangesAsync();

                    serviceResponce.Data = _mapper.Map<GetCharacterDto>(character);
                }
                else
                {
                    serviceResponce.Success = false;
                    serviceResponce.Message = "Character not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

            return serviceResponce;
        }
        public async Task<ServiceResponce<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();

            try
            {
                Character character = await _context.Characters
                    .FirstOrDefaultAsync(i => i.Id == id && i.User.Id == GetUserId());
                if (character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();
                    serviceResponce.Data = _context.Characters.Where(c => c.User.Id == GetUserId())
                        .Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                }
                else
                {
                    serviceResponce.Success = false;
                    serviceResponce.Message = "Character not found.";
                }

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
