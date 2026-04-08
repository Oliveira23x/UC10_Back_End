using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        [Required, StringLength(20)]
        public string Status { get; set; } // Ex: Aberto, Fechado, Suspenso

        public ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
    }
}
