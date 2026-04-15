using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedido(int id)
        {
            var pedido = await _pedidoService.ObterPedidoComDetalhesAsync(id);
            if (pedido == null)
                return NotFound();

            var pedidoDTO = new DetalhesItemPedidoDTO
            {
                Id = pedido.Id,
                DataPedido = pedido.DataPedido,
                Status = pedido.Status,
                Cliente = pedido.Cliente.Nome,
                Itens = pedido.ItensPedido.Select(i => new ItemPedidoDTO
                {
                    Id = i.Id,
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade,
                    ProdutoNome = i.Produto.Nome
                    
                   
                }).ToList()


            };


            return Ok(pedidoDTO);
        }
        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoDTO pedido)
        {
            var itensPedido = pedido.Itens.Select(i => new ItemPedido
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
            }).ToList();



            var NovoPedido = await _pedidoService.CriarPedidoAsync(pedido.ClienteId, itensPedido);
            return Ok(pedido);
            }


        }
    }

