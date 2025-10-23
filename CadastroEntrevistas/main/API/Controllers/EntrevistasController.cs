using CadastroEntrevista.APLICATION.UseCases.Interfaces;
using CadastroEntrevista.DOMAIN.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEntrevista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntrevistasController : ControllerBase
    {
        public readonly ICadastroEntrevistaUseCase _useCase;
        public EntrevistasController(ICadastroEntrevistaUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriaEntrevistasAsync([FromBody] EntrevistaRequest request)
        {
            var entrevistas = await _useCase.ExecuteAsync(request.Cpf!,
                 request.dataAdmissao,
                 request.dataDesligamento);

            if (entrevistas.Any())
                return Created(string.Empty, entrevistas);

            return NoContent();
        }

        [HttpGet()]
        public async Task<IActionResult> RecuperaEntrevistasAsync(Guid idEntrevista)
        {
            return Ok();
        }

        [HttpGet("{idEntrevista}")]
        public async Task<IActionResult> RecuperaEntrevistaAsync(Guid idEntrevista)
        {
            return Ok();
        }
        
        
        [HttpPatch("{idEntrevista}")]
        public async Task<IActionResult> AlteraEntrevistaAsync(Guid idEntrevista)
        {
            return Ok();
        }

        [HttpDelete("{idEntrevista}")]
        public async Task<IActionResult> ExcluiEntrevistaAsync(Guid idEntrevista)
        {
            return NoContent();
        } 
    }
}
