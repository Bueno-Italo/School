using Microsoft.AspNetCore.Mvc;
using School.Application.DTOs.Class;
using School.Application.Interfaces;

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
        public async Task<ActionResult> CreateClass(ClassPostDTO classPostDTO)
        {
            var createdClass = await _classService.AddAsync(classPostDTO);
            if (createdClass == null)
            {
                return BadRequest("Não foi possível criar a turma.");
            }
            return Ok(new { message = "Turma criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClass(ClassPutDTO classPutDTO)
        {
            var updatedClass = await _classService.UpdateAsync(classPutDTO);
            if (updatedClass == null)
            {
                return BadRequest("Ocorreu um erro ao alterar esta turma.");
            }
            return Ok(new { message = "Turma atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            var deletedClass = await _classService.DeleteAsync(id);
            if (deletedClass == null)
            {
                return BadRequest("Ocorreu um erro ao excluir esta turma.");
            }
            return Ok(new { message = "Turma excluída com sucesso." });
        }

        [HttpGet("{id}")]
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
        public async Task<ActionResult> GetAllClasses()
        {
            var classes = await _classService.GetAllAsync();
            return Ok(classes);
        }
    }
}