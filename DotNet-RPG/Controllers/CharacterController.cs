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
        
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add (Character newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}
