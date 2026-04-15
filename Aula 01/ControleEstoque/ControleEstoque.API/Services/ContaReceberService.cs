using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class ContaReceberService : IContaReceberService
    {

        private readonly AppDbContext _context;

        public ContaReceberService(AppDbContext context)
        {
            _context = context;
        }

        async Task IContaReceberService.AtualizarAsync(AtualizarContaReceberDTO DTO)
        {
            var contaReceber =  await _context.ContasReceber.FindAsync(DTO.Id);
            if (contaReceber != null)
            {
                contaReceber.Descricao = DTO.Descricao;
                contaReceber.DataVencimento = DTO.DataVencimento;
                contaReceber.DataPagamento = DTO.DataPagamento;
                _context.ContasReceber.Update(contaReceber);
                await _context.SaveChangesAsync();
            }


        }

        async Task<ContaReceberDTO> IContaReceberService.CriarAsync(CriarContaReceberDTO DTO)
        {
            var contaReceber = new Models.ContaReceber
            {
                Descricao = DTO.Descricao,
                Valor = DTO.Valor,
                DataVencimento = DTO.DataVencimento,
                ClienteId = DTO.ClienteId,
                FornecedorId = DTO.FornecedorId,
                Status = "Pendente"
            };

            _context.ContasReceber.Add(contaReceber);
            await _context.SaveChangesAsync();

            return new ContaReceberDTO
            {
                Id = contaReceber.Id,
                Descricao = contaReceber.Descricao,
                DataVencimento = contaReceber.DataVencimento,
                DataPagamento = contaReceber.DataPagamento
            };
        }

        async Task<ContaReceberDTO?> IContaReceberService.ObterPorIdAsync(int id)
        {
            return await _context.ContasReceber
                .Where(c => c.Id == id)
                .Select(c => new ContaReceberDTO
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    DataVencimento = c.DataVencimento,
                    DataPagamento = c.DataPagamento
                })
                .FirstOrDefaultAsync();
        }

      async Task<IEnumerable<ContaReceberDTO>> IContaReceberService.ObterTodosAsync()
        {
            return await _context.ContasReceber
            .Select(c => new ContaReceberDTO
            {
                Id = c.Id,
                Descricao = c.Descricao,
                DataVencimento = c.DataVencimento,
                DataPagamento = c.DataPagamento
            })
            .ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var contaRemover = await _context.ContasReceber.FindAsync(id);
            if (contaRemover != null)
            {
                _context.ContasReceber.Remove(contaRemover);
                await _context.SaveChangesAsync();
            }
        }
    }
}
