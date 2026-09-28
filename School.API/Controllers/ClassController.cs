using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.DTOs.Class;
using School.Application.Interfaces;
using School.Infra.Ioc;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateClass(ClassPostDTO classPostDTO)
        {
            var createdClass = await _classService.AddAsync(classPostDTO);
            return Ok(new { message = "Turma criada com sucesso." });
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateClass(ClassPutDTO classPutDTO)
        {
            var updatedClass = await _classService.UpdateAsync(classPutDTO);
            return Ok(new { message = "Turma atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            var deletedClass = await _classService.DeleteAsync(id);
            return Ok(new { message = "Turma excluída com sucesso." });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetClassById(int id)
        {
            var newClass = await _classService.GetByIdAsync(id);
            if (newClass == null)
            {
                return NotFound("Turma não encontrada.");
            }
            return Ok(newClass);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAllClasses()
        {
            var classes = await _classService.GetAllAsync();
            return Ok(classes);
        }

        [HttpGet("user")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult> GetAllClassByUser()
        {
            var userId = User.GetUserId();

            var classes = await _classService.GetClassByUser(userId);
            return Ok(classes);
        }
    }
}