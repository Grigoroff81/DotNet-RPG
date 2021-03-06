﻿using AutoMapper;
using DotNet_RPG.Data;
using DotNet_RPG.DTOs.CharacterDTO;
using DotNet_RPG.DTOs.WeaponDto;
using DotNetRpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DotNetRpgContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IMapper _mapper;

        public WeaponService(DotNetRpgContext context, IHttpContextAccessor accessor, IMapper mapper)
        {
            _context = context;
            _accessor = accessor;
            _mapper = mapper;
        }

        public IHttpContextAccessor Accessor { get; }

        public async Task<ServiceResponce<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponce<GetCharacterDto> responce = new ServiceResponce<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters.Include(c=>c.Weapon)
                    .Include(c=>c.Class)
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
                    c.User.Id == int.Parse(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (character == null)
                {
                    responce.Success = false;
                    responce.Message = "Character not found.";
                    return responce;
                }
                Weapon weapon = new Weapon
                {
                    WeaponName = newWeapon.WeaponName,
                    Damage = newWeapon.WeaponDamage,
                    CharacterId = newWeapon.CharacterId
                };

                await _context.Weapons.AddAsync(weapon);
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
