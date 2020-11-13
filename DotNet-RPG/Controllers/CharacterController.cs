using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_RPG.Models;
using DotNet_RPG.Services.CharacterSrevice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        //private static Character knight = new Character();

        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {Id =1, Name = "Sam"}
        };
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(i => i.Id == id));
        }

        [HttpPost]
        public IActionResult Add (Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }
    }
}
