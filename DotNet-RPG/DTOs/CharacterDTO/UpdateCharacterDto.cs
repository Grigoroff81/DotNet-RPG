using DotNet_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.DTOs.CharacterDTO
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int Hitpoints { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Inelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
