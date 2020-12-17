using AutoMapper;
using DotNet_RPG.Data;
using DotNet_RPG.DTOs.Fight;
using DotNetRpg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DotNetRpgContext _context;
        private readonly IMapper _mapper;

        public FightService(DotNetRpgContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponce<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
        {
            ServiceResponce<AttackResultDto> responce = new ServiceResponce<AttackResultDto>();
            try
            {
                Character attacker = await _context.Characters
                    .Include(c => c.Weapon)
                    .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Character opponent = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == request.OpponentId);
                int damage = DoWeaponAttack(attacker, opponent);
                if (opponent.Hitpoints <= 0)
                {
                    responce.Message = $"{opponent.Name} is defeated";
                }

                _context.Characters.Update(opponent);
                await _context.SaveChangesAsync();

                responce.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    AttackerHP = attacker.Hitpoints,
                    Opponent = opponent.Name,
                    OpponentHP = opponent.Hitpoints,
                    Damage = damage

                };
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        public async Task<ServiceResponce<AttackResultDto>> SkillAttack(SkillAttackDto request)
        {
            ServiceResponce<AttackResultDto> responce = new ServiceResponce<AttackResultDto>();
            try
            {
                Character attacker = await _context.Characters
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Character opponent = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == request.OpponentId);

                CharacterSkill characterSkill =
                    attacker.CharacterSkills.FirstOrDefault(cs => cs.Skill.Id == request.SkillId);

                if (characterSkill == null)
                {
                    responce.Success = false;
                    responce.Message = $"{attacker.Name} does not have that skill.";
                    return responce;
                }

                int damage = DoSkillAttack(attacker, opponent, characterSkill);
                if (opponent.Hitpoints <= 0)
                {
                    responce.Message = $"{opponent.Name} is defeated";
                }

                _context.Characters.Update(opponent);
                await _context.SaveChangesAsync();

                responce.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    AttackerHP = attacker.Hitpoints,
                    Opponent = opponent.Name,
                    OpponentHP = opponent.Hitpoints,
                    Damage = damage

                };
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        
        public async Task<ServiceResponce<FightResultDto>> Fight(FightRequestDto request)
        {
            ServiceResponce<FightResultDto> responce = new ServiceResponce<FightResultDto>
            {
                Data = new FightResultDto()
            };
            try
            {
                List<Character> characters =
                    await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .Where(c => request.CharacterIds.Contains(c.Id)).ToListAsync();

                bool defeated = false;
                while(!defeated)
                {
                    foreach (Character attacker in characters)
                    {
                        List<Character> opponents = characters.Where(c => c.Id != attacker.Id).ToList();
                        Character opponent = opponents[new Random().Next(opponents.Count)];

                        int damage = 0;
                        string attackUsed = string.Empty;

                        bool useWeapon = new Random().Next(2) == 0;
                        if (useWeapon)
                        {
                            attackUsed = attacker.Weapon.WeaponName;
                            damage = DoWeaponAttack(attacker, opponent);
                        }
                        else
                        {
                            int randomSkill = new Random().Next(attacker.CharacterSkills.Count);
                            attackUsed = attacker.CharacterSkills[randomSkill].Skill.Name;
                            damage = DoSkillAttack(attacker, opponent, attacker.CharacterSkills[randomSkill]);
                        }

                        responce.Data.Log.Add($"{attacker.Name} attacks {opponent.Name} using {attackUsed}" +
                            $"with {(damage >= 0 ? damage : 0) } damage.");

                        if (opponent.Hitpoints <= 0)
                        {
                            defeated = true;
                            attacker.Victories++;
                            opponent.Defeats++;
                            responce.Data.Log.Add($"{opponent.Name} has been defeated!");
                            responce.Data.Log.Add($"{attacker.Name} wins with {attacker.Hitpoints} HP left.");
                            break;
                        }
                    }
                }
                characters.ForEach(c =>
                {
                    c.Fights++;
                    c.Hitpoints = 100;
                });

                _context.Characters.UpdateRange(characters);
                await  _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        public async Task<ServiceResponce<List<HighscoreDto>>> GetHighscore()
        {
            List<Character> characters = await _context.Characters
                .Where(c => c.Fights > 0)
                .OrderByDescending(c => c.Victories)
                .ThenBy(c => c.Defeats)
                .ToListAsync();

            var responce = new ServiceResponce<List<HighscoreDto>>
            {
                Data = characters.Select(c => _mapper.Map<HighscoreDto>(c)).ToList()
            };

            return responce;
        }

        private static int DoWeaponAttack(Character attacker, Character opponent)
        {
            int damage = attacker.Weapon.Damage + new Random().Next(attacker.Strenght);
            damage -= new Random().Next(opponent.Defence);

            if (damage > 0)
            {
                opponent.Hitpoints -= damage;
            }

            return damage;
        }
        private static int DoSkillAttack(Character attacker, Character opponent, CharacterSkill characterSkill)
        {
            int damage = characterSkill.Skill.Damage + new Random().Next(attacker.Inelligence);
            damage -= new Random().Next(opponent.Defence);

            if (damage > 0)
            {
                opponent.Hitpoints -= damage;
            }

            return damage;
        }

    }
}
