using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IContaReceberService
    {
            Task<IEnumerable<ContaReceberDTO>> ObterTodosAsync();
            Task<ContaReceberDTO?> ObterPorIdAsync(int id);
            Task<ContaReceberDTO> CriarAsync(CriarContaReceberDTO DTO);
            Task AtualizarAsync(AtualizarContaReceberDTO DTO);
            Task RemoverAsync(int id);
    }
}
