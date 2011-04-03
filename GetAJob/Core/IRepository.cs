using System;
using System.Collections.Generic;
using System.Text;

using NHibernate.Criterion;

namespace GetAJob.Core
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);

        void Remove(T entity);
        void Remove(DetachedCriteria criteria);

        long Count(DetachedCriteria criteria);

        bool Exists(DetachedCriteria criteria);
       
        ICollection<T> FindAll(DetachedCriteria criteria);
        ICollection<T> FindAll(DetachedCriteria criteria, params Order[] orders);
        ICollection<T> FindAll(DetachedCriteria criteria, int firstResult, int numberOfResults, params Order[] orders);

        T FindFirst(DetachedCriteria criteria, Order order);
        T FindFirst(DetachedCriteria criteria);
        T FindOne(DetachedCriteria criteria);
		T FindBy(string key, object value);
		T Find(int id);
    }
}
