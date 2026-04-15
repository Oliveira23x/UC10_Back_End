namespace ControleEstoque.API.DTOs
{
    public class CriarPedidoDTO 
    {
        public int ClienteId { get; set; }
         public List<CriarItemPedidoDTO> Itens { get; set; } = new List<CriarItemPedidoDTO>();
    }
}
