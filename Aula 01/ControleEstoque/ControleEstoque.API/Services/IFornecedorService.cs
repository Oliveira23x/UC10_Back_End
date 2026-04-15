using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDTO>> ObterTodosAsync();
        Task<FornecedorDTO?> ObterPorIdAsync(int id);
        Task<FornecedorDTO> CriarAsync(CriarFornecedorDTO DTO);
        Task AtualizarAsync(AtualizarFornecedorDTO DTO);
        Task RemoverAsync(int id);
    }
}