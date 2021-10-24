using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRepsoitoryService<T> 
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        List<T> GetAllById(int id);
        T GetById(int id);

    }
}
