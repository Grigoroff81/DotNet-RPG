using DotNet_RPG.DTOs.CharacterDTO;
using DotNet_RPG.DTOs.WeaponDto;
using DotNetRpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponce<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}
