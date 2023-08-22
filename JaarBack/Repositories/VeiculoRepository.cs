using JaarBack.Data;
using JaarBack.Models;
using Microsoft.EntityFrameworkCore;

namespace JaarBack.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _dbContext;

        public VeiculoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _dbContext.Veiculos.ToListAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _dbContext.Veiculos.FindAsync(id);
        }

        public async Task CreateAsync(Veiculo veiculo)
        {
            _dbContext.Veiculos.Add(veiculo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            _dbContext.Entry(veiculo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var veiculo = await _dbContext.Veiculos.FindAsync(id);
            if (veiculo != null)
            {
                _dbContext.Veiculos.Remove(veiculo);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}