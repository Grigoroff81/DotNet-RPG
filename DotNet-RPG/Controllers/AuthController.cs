using DotNet_RPG.DTOs.UserDTO;
using DotNetRpg.Data.Conracts;
using DotNetRpg.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto userDto)
        {
            ServiceResponce<int> responce = await _authRepository.Register(
                new User
                {
                    Username = userDto.Username,
                },
                userDto.Password
                );
            if (!responce.Success)
            {
                return BadRequest(responce);
            }
            return Ok(responce);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            ServiceResponce<string> responce = await _authRepository.Login(
                userDto.Username, userDto.Password
                );
            if (!responce.Success)
            {
                return BadRequest(responce);
            }
            return Ok(responce);
        }
    }
}
