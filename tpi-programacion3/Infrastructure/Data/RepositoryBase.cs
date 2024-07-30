using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    //una lista T acepta tipo de datos genéricos (la clase como tal existe pero hasta que nadie la llama con lo que viene adentro esa clase
    //no existe realmente (lo mismo con la lista)
    
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public T? Get<TId>(TId id) //TId busca el identificador de T
        {
            return _dbContext.Set<T>().Find(new object[] { id } );
        }


        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }


    }
}
