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

        public FightService(DotNetRpgContext context)
        {
            _context = context;
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

                int damage = attacker.Weapon.Damage + new Random().Next(attacker.Strenght);
                damage -= new Random().Next(opponent.Defence);

                if (damage > 0)
                {
                    opponent.Hitpoints -= damage;
                }
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

                int damage = characterSkill.Skill.Damage + new Random().Next(attacker.Inelligence);
                damage -= new Random().Next(opponent.Defence);

                if (damage > 0)
                {
                    opponent.Hitpoints -= damage;
                }
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
    }
}
