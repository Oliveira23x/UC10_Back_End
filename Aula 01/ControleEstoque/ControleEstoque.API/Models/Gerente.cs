using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class Gerente : Usuario
    {
        [StringLength(50)]
        public string Turno { get; set; }


        // Propriedades específicas para Gerente
    }
}
