using DotNet_RPG.DTOs.Fight;
using DotNetRpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponce<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        Task<ServiceResponce<AttackResultDto>> SkillAttack(SkillAttackDto request);
        Task<ServiceResponce<FightResultDto>> Fight(FightRequestDto request);
        Task<ServiceResponce<List<HighscoreDto>>> GetHighscore();
    }
}
