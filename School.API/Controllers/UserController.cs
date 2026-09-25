using Microsoft.AspNetCore.Mvc;
using School.Application.DTOs.Course;
using School.Application.DTOs.User;
using School.Application.Interfaces;
using School.Application.Services;
using School.Domain.Account;

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
           
            var user = await _userService.AddAsync(userPostDTO);
            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower(), user.Profile);
            return Ok(new { Nome = user.Name, token = token});
        }
    }
}