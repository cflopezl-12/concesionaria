using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IReadRepository<T>
        where T : class
    {

        Task<List<T>> GetEntityAll();
        Task<T> GetEntityById(string id);

    }
}
