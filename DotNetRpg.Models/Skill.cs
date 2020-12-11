using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetRpg.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public List<CharacterSkill> CharacterSkills { get; set; }
    }
}
