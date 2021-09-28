using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Models
{
    public interface IDbAction<T>
    {

        Task Create(T item);
        Task<IEnumerable<T>> GetAllData();

        Task Delete(T item);

        Task Update(T item);
    }
}
