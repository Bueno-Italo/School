using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.API.Extensions;
using School.API.Models;
using School.Application.DTOs.Course;
using School.Application.Interfaces;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourse(CoursePostDTO coursePostDTO)
        {
            var createdCourse = await _courseService.AddAsync(coursePostDTO);
            if (createdCourse == null)
            {
                return BadRequest("Não foi possível criar o curso.");
            }
            return Ok(new { message = "Curso criado com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse(CoursePutDTO coursePutDTO)
        {
            var updatedCourse = await _courseService.UpdateAsync(coursePutDTO);
            if (updatedCourse == null)
            {
                return BadRequest("Ocorreu um erro ao alterar este curso.");
            }
            return Ok(new { message = "Curso atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var deletedCourse = await _courseService.DeleteAsync(id);
            if (deletedCourse == null)
            {
                return BadRequest("Ocorreu um erro ao excluir este curso.");
            }
            return Ok(new { message = "Curso excluído com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCourses([FromQuery]PaginationParams paginationParams)
        {
            var courses = await _courseService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader
                (new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, courses.TotalCount, courses.TotalPages));
            return Ok(courses);
        }
    }
}