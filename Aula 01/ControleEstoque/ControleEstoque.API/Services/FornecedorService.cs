using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly AppDbContext _context;

        public FornecedorService(AppDbContext context)
        {
            _context = context;
        }


      async Task IFornecedorService.AtualizarAsync(AtualizarFornecedorDTO DTO)
      {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == DTO.Id);
            if (fornecedor != null) // verificando se o fornecedor existe antes de tentar atualizá-lo
            {
                fornecedor.NomeFantasia = DTO.NomeFantasia;
                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();
            }


        }

        async Task<FornecedorDTO> IFornecedorService.CriarAsync(CriarFornecedorDTO DTO)
        {
            var fornecedorAdd = new Fornecedor // mapeando o DTO de criação para a entidade Fornecedor
            {
                NomeFantasia = DTO.NomeFantasia,
                CNPJ = DTO.CNPJ
            };

            _context.Fornecedores.Add(fornecedorAdd);
            await _context.SaveChangesAsync();

            return new FornecedorDTO // mapeando a entidade Fornecedor para FornecedorDTO
            {
                Id = fornecedorAdd.Id,
                NomeFantasia = fornecedorAdd.NomeFantasia,
                CNPJ = fornecedorAdd.CNPJ
            };
        }

        async Task<FornecedorDTO?> IFornecedorService.ObterPorIdAsync(int id)
        {
            var fornecedorModel = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == id);
            if (fornecedorModel == null)
                return null;

            return new FornecedorDTO
            {
                Id = fornecedorModel.Id,
                NomeFantasia = fornecedorModel.NomeFantasia,
                CNPJ = fornecedorModel.CNPJ
            };
        }


        async Task<IEnumerable<FornecedorDTO>> IFornecedorService.ObterTodosAsync()
        {
            return await _context.Fornecedores // acessando a tabela Fornecedores do banco de dados
                .Select(f => new FornecedorDTO // mapeando a entidade Fornecedor para FornecedorDTO
                {
                    Id = f.Id, // assumindo que a entidade Fornecedor tem uma propriedade Id
                    NomeFantasia = f.NomeFantasia,
                    CNPJ = f.CNPJ
                })
                .ToListAsync();
        }

       async Task IFornecedorService.RemoverAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == id);
            if (fornecedor != null) // verificando se o fornecedor existe antes de tentar removê-lo
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}