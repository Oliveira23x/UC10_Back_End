using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceber : ControllerBase
    {
        private readonly Services.IContaReceberService _contaReceberService;

        public ContasReceber(Services.IContaReceberService contaReceberService)
        {
            _contaReceberService = contaReceberService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var contas = await _contaReceberService.ObterTodosAsync();
            return Ok(contas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var conta = await _contaReceberService.ObterPorIdAsync(id);
            if (conta == null) return NotFound();
            return Ok(conta);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] DTOs.CriarContaReceberDTO DTO)
        {
            var contaCriada = await _contaReceberService.CriarAsync(DTO);
            return Created(nameof(CriarAsync), contaCriada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] DTOs.AtualizarContaReceberDTO DTO)
        {
            if (id != DTO.Id) return BadRequest();
            var existe = await _contaReceberService.ObterPorIdAsync(id);
            if (existe == null) return NotFound();

            await _contaReceberService.AtualizarAsync(DTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverAsync(int id)
        {
            await _contaReceberService.RemoverAsync(id);
            return NoContent();
        }

    }
}
