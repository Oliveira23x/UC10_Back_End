namespace ControleEstoque.API.Models
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;
        public Pedido Pedidos { get; set; } = new();
    }
}
