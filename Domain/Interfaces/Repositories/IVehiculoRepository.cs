using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IVehiculoRepository : IBaseRepository<Vehiculo>, IReadRepository<Vehiculo>
    {
        Task<List<Vehiculo>> GetCustom(string marca, string linea, string precio);
    }
}
