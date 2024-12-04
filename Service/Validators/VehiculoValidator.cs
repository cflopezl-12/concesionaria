using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class VehiculoValidator : AbstractValidator<Vehiculo>
    {
        public VehiculoValidator() {

            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("La marca del vehículo es obligatorio")
                .MaximumLength(30).WithMessage("La marca del vehículo no puede exceder los 30 caracteres."); ;

            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("El modelo del vehículo es obligatorio")
                .ExclusiveBetween(2014,2025).WithMessage("No se venden vehículos con modelos menores a 2015 o mayores a 2024");

        }
    }
}
