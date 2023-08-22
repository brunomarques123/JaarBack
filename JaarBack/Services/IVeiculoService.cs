using JaarBack.Models;

namespace JaarBack.Services
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> GetAllVeiculosAsync();
        Task<Veiculo> GetVeiculoByIdAsync(int id);
        Task CreateVeiculoAsync(Veiculo veiculo);
        Task UpdateVeiculoAsync(int id, Veiculo veiculo);
        Task DeleteVeiculoAsync(int id);
    }
}