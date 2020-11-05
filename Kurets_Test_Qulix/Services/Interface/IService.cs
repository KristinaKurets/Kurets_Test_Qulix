using Kurets_Test_Qulix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurets_Test_Qulix.Services.Interface
{
    public interface IService<T>
    {
        List<T> GetAll();
        void Add(T item);
        void Edit(T item);
        void Delete(T item);

    }
}
