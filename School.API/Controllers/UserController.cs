using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.API.Models;
using School.Application.DTOs.Course;
using School.Application.DTOs.User;
using School.Application.Interfaces;
using School.Application.Services;
using School.Domain.Account;
using System.Net.WebSockets;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticate _authenticate;
        public UserController(IUserService userService, IAuthenticate authenticate)
        {
            _userService = userService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserPostDTO userPostDTO)
        {
            var userExists = await _authenticate.UserExists(userPostDTO.Email);
            if (userExists)
                return BadRequest(new { MessageProcessingHandler = "Já existe um usuário utilizado este e-mail!" });
            var user = await _userService.AddAsync(userPostDTO);
            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower(), user.Profile);
            return Ok(new { Nome = user.Name, token = token});
        }

        [HttpPost("login")]
        public async Task<ActionResult> GetTokenUser(UserLogin userLogin)
        {
            var user = await _authenticate.GetUserByIdEmail(userLogin.Email);
            if (user == null)
                return BadRequest(new { Message = "Usuário ou senha inválidos" });

            var userValid = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Password);
            if (!userValid)
                return BadRequest(new { Message = "Usuário ou senha ivalidos" });

            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower(), user.Profile);
            return Ok(new { Nome = user.Name, Token = token });
        }

        [HttpGet("rota-teste")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Teste()
        {
            var users = await _userService.GetAllAsync();
            return Ok(new {Message = "Usuário logado!"});
        }
    }
}