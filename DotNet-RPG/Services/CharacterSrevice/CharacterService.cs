﻿using DotNet_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Services.CharacterSrevice
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {Id =1, Name = "Sam"}
        };

        public List<Character> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            return characters.FirstOrDefault(i => i.Id == id)
        }
    }
}