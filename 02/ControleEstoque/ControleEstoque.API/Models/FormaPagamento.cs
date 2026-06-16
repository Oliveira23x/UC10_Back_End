using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class FormaPagamento
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
