using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Services;
using Domain.Wrappers;
using Microsoft.AspNetCore.Mvc;
using WebAppConcesionaria.Models;

namespace WebAppConcesionaria.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiculoController : Controller
    {

        private readonly IVehiculoService vehiculoService;
        private readonly IMapper mapper;

        public VehiculoController(IVehiculoService vehiculoService, IMapper mapper)
        {
            this.vehiculoService = vehiculoService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehiculos()
        {
            var vehiculos = await vehiculoService.GetAll();
            var mappedVehiculos = mapper.Map<List<Vehiculo>, List<VehiculoDTO>>(vehiculos);

            return Ok(new ApiResponse<List<VehiculoDTO>>(mappedVehiculos, $"Listado de vehículos obtenido exitosamente."));
        }

        [HttpGet("busqueda")]
        public async Task<IActionResult> GetCustomVehiculos(string? marca, string? linea, string? precio)
        {
            var vehiculos = await vehiculoService.GetCustom(marca, linea, precio);
            var mappedVehiculos = mapper.Map<List<Vehiculo>, List<VehiculoDTO>>(vehiculos);

            return Ok(new ApiResponse<List<VehiculoDTO>>(mappedVehiculos, $"Listado de vehículos obtenido exitosamente."));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehiculo([FromBody] VehiculoDTO newVehiculo)
        {
            try
            {
                var mapped = mapper.Map<VehiculoDTO, Vehiculo>(newVehiculo);
                var entity = await vehiculoService.CreateVehiculo(mapped);
                return Ok(new ApiResponse<VehiculoDTO>(mapper.Map<Vehiculo, VehiculoDTO>(entity), $"El vehiculo '{newVehiculo.Marca}' fue creado exitosamente."));
            }
            catch (ValidateException ex)
            {
                return BadRequest(new ApiResponse<VehiculoDTO>(ex.Message, ex.ErrorsDictionary));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<VehiculoDTO>($"El vehiculo '{newVehiculo.Marca}' no fue Creado, información: {ex.Message}"));
            }

        }
    }

}
