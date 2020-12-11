using AutoMapper;
using DotNet_RPG.Data;
using DotNet_RPG.DTOs.CharacterDTO;
using DotNet_RPG.DTOs.CharacterSkillDto;
using DotNetRpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DotNetRpgContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IMapper _mapper;

        public CharacterSkillService(DotNetRpgContext context, IHttpContextAccessor accessor, IMapper mapper)
        {
            _context = context;
            _accessor = accessor;
            _mapper = mapper;
        }

        //public IHttpContextAccessor Accessor { get; }

        public async Task<ServiceResponce<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkillDto)
        {
            ServiceResponce<GetCharacterDto> responce = new ServiceResponce<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters.Include(c => c.Weapon)
                    .Include(c => c.Class)
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkillDto.CharacterId &&
                    c.User.Id == int.Parse(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (character == null)
                {
                    responce.Success = false;
                    responce.Message = "Character not found.";
                    return responce;
                }
                
                Skill skill = await _context.Skills
                    .FirstOrDefaultAsync(s => s.Id == newCharacterSkillDto.SkillId);
                
                if (skill == null)
                {
                    responce.Success = false;
                    responce.Message = "Skill not found.";
                    return responce;
                }

                CharacterSkill characterSkill = new CharacterSkill
                {
                    Character = character,
                    Skill = skill,
                };

                await _context.ChararacterSkills.AddAsync(characterSkill);
                await _context.SaveChangesAsync();

                responce.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
    }
}
