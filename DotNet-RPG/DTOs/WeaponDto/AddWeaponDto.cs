using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.DTOs.WeaponDto
{
    public class AddWeaponDto
    {
        public int? WeaponId { get; set; }
        public string WeaponName { get; set; }
        public int WeaponDamage { get; set; }
        public int CharacterId { get; set; }
    }
}
