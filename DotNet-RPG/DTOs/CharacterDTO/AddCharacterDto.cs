﻿using DotNetRpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.DTOs.CharacterDTO
{
    public class AddCharacterDto
    {
        public string Name { get; set; }
        public int Hitpoints { get; set; }
        public int Strenght { get; set; }
        public int Defence { get; set; }
        public int Inelligence { get; set; }
        public int RpgClassId { get; set; }
        public RpgClass Class { get; set; }
    }
}
