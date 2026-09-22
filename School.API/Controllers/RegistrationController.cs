using Microsoft.AspNetCore.Mvc;
using School.Application.DTOs.Registration;
using School.Application.Interfaces;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegistration(RegistrationPostDTO registrationPostDTO)
        {
            var createdRegistration = await _registrationService.AddAsync(registrationPostDTO);

            if (createdRegistration == null)
            {
                return BadRequest("Não foi possível criar a matrícula.");
            }

            return Ok(new { message = "Matrícula criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRegistration(RegistrationPutDTO registrationPutDTO)
        {
            var updatedRegistration = await _registrationService.UpdateAsync(registrationPutDTO);

            if (updatedRegistration == null)
            {
                return BadRequest("Ocorreu um erro ao alterar esta matrícula.");
            }

            return Ok(new { message = "Matrícula atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegistration(int id)
        {
            var deletedRegistration = await _registrationService.DeleteAsync(id);

            if (deletedRegistration == null)
            {
                return BadRequest("Ocorreu um erro ao excluir esta matrícula.");
            }

            return Ok(new { message = "Matrícula excluída com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRegistrationById(int id)
        {
            var registration = await _registrationService.GetByIdAsync(id);

            if (registration == null)
            {
                return NotFound("Matrícula não encontrada.");
            }

            return Ok(registration);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRegistrations()
        {
            var registrations = await _registrationService.GetAllAsync();

            return Ok(registrations);
        }
    }
}