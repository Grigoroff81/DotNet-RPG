using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetRpg.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hitpoints { get; set; }
        public int Strenght { get; set; }
        public int Defence { get; set; }
        public int Inelligence { get; set; }
        public int RpgClassId { get; set; }
        public RpgClass Class { get; set; }
        public User User { get; set; }
        //public int? WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public List<CharacterSkill> CharacterSkills { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
