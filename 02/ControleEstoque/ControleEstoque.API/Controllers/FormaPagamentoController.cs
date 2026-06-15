using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        [Authorize (Roles = "Cliente")]

        public class FormaPagamentoController : ControllerBase
        {
            private readonly IFormaPagamentoService _formaPagamentoService;

            public FormaPagamentoController(IFormaPagamentoService formaPagamentoService)
            {
                _formaPagamentoService = formaPagamentoService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var formasPagamento = await _formaPagamentoService.ObterTodosAsync();
                return Ok(formasPagamento);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var formaPagamento = await _formaPagamentoService.ObterPorIdAsync(id);
                if (formaPagamento == null) return NotFound();
                return Ok(formaPagamento);
            }

            [HttpPost]
            public async Task<IActionResult> Criar([FromBody] CriarFormaPagamentoDto dto)
            {
                var formaPagamento = await _formaPagamentoService.CriarAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = formaPagamento.Id }, formaPagamento);
            }

            [HttpPut]
            public async Task<IActionResult> Atualizar([FromBody] AtualizarFormaPagamentoDto dto)
            {
                  if (dto.Id <= 0) return BadRequest("ID inválido para atualização.");

                  await _formaPagamentoService.AtualizarAsync(dto);
                  return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Remover(int id)
            {
                await _formaPagamentoService.RemoverAsync(id);
                return NoContent();
            }
        }
    }
}

