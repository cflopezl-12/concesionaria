using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> 
        where T : class
    {

        Task InsertEntity(T Entity);
        Task UpdateEntity(T Entity);
        Task DeleteEntity(string id);

    }


}
