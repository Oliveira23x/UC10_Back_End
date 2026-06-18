using ControleEstoque.API.Models;
using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IPedidoService
    {
        Task<Pedido?> ObterPedidoComDetalhesAsync(int pedidoId);
        Task<IEnumerable<Pedido>> ListarPedidosDoClienteAsync(int clienteId);
        Task<Pedido> CriarPedidoAsync (int clienteId, List<ItemPedido> itens, FormaPagamento formaPagamento);
  
    }
}
