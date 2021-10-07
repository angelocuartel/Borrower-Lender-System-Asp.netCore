using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Interface
{
   public interface IDbService<T>
    {

        T InsertItem(T item);
    }
}
