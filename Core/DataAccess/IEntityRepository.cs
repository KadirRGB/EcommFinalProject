using System.Linq.Expressions;
using Core.Entities;
//Core katmanı diğer katmanları referans almaz

namespace Core.DataAccess
{
    //Generic Constraint ->class:referans tip olabilir, IEntity: IEntity implemente eden bir nesne olabilir, 
    //new():new'lenebilir olmalı
    
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
         List<T> GetAll(Expression<Func<T,bool>> filter=null);
         T Get(Expression<Func<T,bool>> filter);
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);
        // List<T> GetAllByCategory(int categoryId); Not nececcary anymore thanks to line 7 LINQ 
    }
}