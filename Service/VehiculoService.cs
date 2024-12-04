using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Service.Validators;

namespace Service
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehiculoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Vehiculo> CreateVehiculo(Vehiculo newVehiculo)
        {
            VehiculoValidator validator = new VehiculoValidator();
            var validationResult = await validator.ValidateAsync(newVehiculo);
            if (validationResult.IsValid)
            {
                await _unitOfWork.VehiculoRepository.InsertEntity(newVehiculo);
            }
            else
            {
                var failures = validationResult.Errors.Where( f => f!=null )
                                                .GroupBy(x => x.PropertyName, x => x.ErrorMessage,
                                                        (propertyName, errorMessages) => new
                                                        {
                                                            Key = propertyName,
                                                            Values = errorMessages.Distinct().ToArray()
                                                        }).ToDictionary(x => x.Key, x => x.Values);
                throw new ValidateException(failures);
            }

            return newVehiculo;
        }

        public async Task<List<Vehiculo>> GetAll()
        {
            return await _unitOfWork.VehiculoRepository.GetEntityAll();
        }

        public async Task<List<Vehiculo>>  GetCustom(string marca, string linea, string precio)
        {
            return await _unitOfWork.VehiculoRepository.GetCustom(marca, linea, precio);
        }

        public async Task<Vehiculo> GetVehiculoById(string id)
        {
            var vehiculo = await _unitOfWork.VehiculoRepository.GetEntityById(id);
            return vehiculo;
        }

    }
}
