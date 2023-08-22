using JaarBack.Models;
using JaarBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaarBack.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class VeiculosController : ControllerBase
        {
            private readonly IVeiculoService _veiculoService;

            public VeiculosController(IVeiculoService veiculoService)
            {
                _veiculoService = veiculoService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Veiculo>>> GetAllVeiculos()
            {
                var veiculos = await _veiculoService.GetAllVeiculosAsync();
                return Ok(veiculos);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Veiculo>> GetVeiculoById(int id)
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
                if (veiculo == null)
                {
                    return NotFound();
                }
                return Ok(veiculo);
            }

            [HttpPost]
            public async Task<ActionResult> CreateVeiculo(Veiculo veiculo)
            {
                await _veiculoService.CreateVeiculoAsync(veiculo);
                return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculo);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> UpdateVeiculo(int id, Veiculo veiculo)
            {
                if (id != veiculo.Id)
                {
                    return BadRequest();
                }

                try
                {
                    await _veiculoService.UpdateVeiculoAsync(id, veiculo);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteVeiculo(int id)
            {
                await _veiculoService.DeleteVeiculoAsync(id);
                return NoContent();
            }
        }
    }
