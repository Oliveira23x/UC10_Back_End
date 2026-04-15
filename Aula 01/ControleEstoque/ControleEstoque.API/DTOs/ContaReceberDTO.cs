namespace ControleEstoque.API.DTOs
{
    public class ContaReceberDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

    }


    public class AtualizarContaReceberDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
    
    public class CriarContaReceberDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public int ClienteId { get; set; }
        public int FornecedorId { get; set; }
    }

}

