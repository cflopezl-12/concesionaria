using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IVehiculoRepository vehiculoRepository)
        {
            VehiculoRepository = vehiculoRepository;
        }

        public IVehiculoRepository VehiculoRepository { get; }

    }
}
