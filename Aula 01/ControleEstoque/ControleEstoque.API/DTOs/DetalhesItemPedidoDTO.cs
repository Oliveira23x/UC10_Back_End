using ControleEstoque.API.Models;
using System.Globalization;

namespace ControleEstoque.API.DTOs
{
    public class DetalhesItemPedidoDTO
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        
        public decimal Total => Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
        public List<ItemPedidoDTO> Itens { get; set; } = new List<ItemPedidoDTO>();

    }
}

