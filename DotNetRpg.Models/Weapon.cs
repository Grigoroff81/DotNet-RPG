using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetRpg.Models
{
    public class Weapon
    {
        public int WeaponId { get; set; }
        public string WeaponName { get; set; }
        public int Damage { get; set; }
        public Character Character { get; set; }
    }
}
