using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{

    public enum PerfilUsuario
    {
        Cliente,
        Gerente,
        Caixa
    }
    public abstract class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string? Nome { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string? Email { get; set; }

        [Required]
        public string? SenhaHash { get; set; } //Aplicar Tamanho mínimo

        [Required]
        public PerfilUsuario Perfil { get; set; }
    }
    public class Cliente : Usuario
    {
        [StringLength(14)]
        public string CPF { get; set; }
        
        
        // Propriedades específicas para Cliente    

    }

    public class Gerente : Usuario
    {
        [StringLength(50)]
        public string Turno { get; set; }


        // Propriedades específicas para Gerente
    }

    public class Caixa : Usuario
    {
        [StringLength(50)]
        public string Setor { get; set; }

        // Propriedades específicas para Caixa
    }
}
