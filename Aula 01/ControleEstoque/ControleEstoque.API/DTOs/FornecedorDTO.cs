namespace ControleEstoque.API.DTOs
{
    public class FornecedorDTO
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }

    public class CriarFornecedorDTO
    {
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }

    public class AtualizarFornecedorDTO
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
    }
}