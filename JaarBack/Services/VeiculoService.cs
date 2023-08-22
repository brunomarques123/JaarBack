using JaarBack.Models;
using JaarBack.Repositories;

namespace JaarBack.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<Veiculo>> GetAllVeiculosAsync()
        {
            return await _veiculoRepository.GetAllAsync();
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(int id)
        {
            return await _veiculoRepository.GetByIdAsync(id);
        }

        public async Task CreateVeiculoAsync(Veiculo veiculo)
        {
            await _veiculoRepository.CreateAsync(veiculo);
        }

        public async Task UpdateVeiculoAsync(int id, Veiculo veiculo)
        {
            var existingVeiculo = await _veiculoRepository.GetByIdAsync(id);
            if (existingVeiculo == null)
            {
                throw new ArgumentException("Veiculo not found");
            }

            existingVeiculo.Ano = veiculo.Ano;
            existingVeiculo.CodigoFipe = veiculo.CodigoFipe;
            existingVeiculo.Placa = veiculo.Placa;
            existingVeiculo.Modelo = veiculo.Modelo;
            existingVeiculo.Tipo = veiculo.Tipo;
            existingVeiculo.Combustivel = veiculo.Combustivel;
            existingVeiculo.Valor = veiculo.Valor;

            await _veiculoRepository.UpdateAsync(existingVeiculo);
        }

        public async Task DeleteVeiculoAsync(int id)
        {
            await _veiculoRepository.DeleteAsync(id);
        }
    }
}