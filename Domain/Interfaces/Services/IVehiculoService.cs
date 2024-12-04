using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IVehiculoService
    {

        Task<Vehiculo> GetVehiculoById(string id);
        Task<List<Vehiculo>> GetAll();
        Task<List<Vehiculo>> GetCustom(string marca, string linea, string precio);
        Task<Vehiculo> CreateVehiculo(Vehiculo newVehiculo);
        /*Task<Vehiculo> UpdateVehiculo(string id, Vehiculo newVehiculoValues);
        Task<Vehiculo> DeleteVehiculo(string id);*/

    }
}
