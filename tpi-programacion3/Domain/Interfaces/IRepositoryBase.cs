using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// consulta a la base de datos y resuelve la dispersión de la interacción con la base de datos
namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T? Get<TId>(TId id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
