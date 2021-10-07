using MVC_Web_Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Services
{
    public class PersonService : IDbService<string>
    {
        public string InsertItem(string item)
        {
            return item;
        }
    }
}
