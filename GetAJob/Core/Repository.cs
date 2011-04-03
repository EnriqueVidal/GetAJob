using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Criterion;

namespace GetAJob.Core
{
    public class Repository<T> : IRepository<T>
    {
        private ISessionFactory SessionFactory = Initializer.Session;
        private ISession Session
        {
            get
            {
                return SessionFactory.OpenSession();
            }
        }
      
        public void Add(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (session.BeginTransaction())
            {
                session.Save(entity);
                session.Transaction.Commit();
            }
        }

 
        public void Update(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                session.Transaction.Commit();
            }
        }

        public void Remove(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (session.BeginTransaction())
            {
                session.Delete(entity);
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Deletes every entity that matches the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        public void Remove(DetachedCriteria criteria)
        {
            foreach (T entity in FindAll(criteria))
                Remove(entity);
        }


        public ICollection<T> FindAll(DetachedCriteria criteria)
        {
            return criteria.GetExecutableCriteria(Session).List<T>();
        }

        /// <summary>
        /// Returns each entity that maches the given criteria, and orders the results
        /// according to the given Orders
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public ICollection<T> FindAll(DetachedCriteria criteria, params Order[] orders)
        {
            if (orders != null)
                foreach (Order order in orders)
                    criteria.AddOrder(order);

            return FindAll(criteria);
        }

        /// <summary>
        /// Returns each entity that matches the given criteria, with support for paging,
        /// and orders the results according to the given Orders
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="firstResult"></param>
        /// <param name="numberOfResults"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public ICollection<T> FindAll(DetachedCriteria criteria, int firstResult, int numberOfResults, params Order[] orders)
        {
            criteria.SetFirstResult(firstResult).SetMaxResults(numberOfResults);
            return FindAll(criteria, orders);
        }


		/// <summary>
		/// Returns the one entity that matches the given criteria. Throws an exception if
		/// more than one entity matches the criteria
		/// </summary>
		/// <param name="criteria"></param>
		/// <returns></returns>
        public T FindOne(DetachedCriteria criteria)
        {
            return criteria.GetExecutableCriteria(Session).UniqueResult<T>();
        }

		/// <summary>
		/// Returns a record found by Id
		/// </summary>
		/// <param name="id">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="T"/>
		/// </returns>
		public T Find(int id)
		{
			return FindBy("Id", id);
		}

		/// <summary>
		/// Returns a Record found by a field name and value
		/// </summary>
		/// <param name="key">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="value">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="T"/>
		/// </returns>
		public T FindBy(string key, object value)
		{
			DetachedCriteria criteria = DetachedCriteria.For<T>().Add(NHibernate.Criterion.Expression.Eq(key, value));
			return FindFirst(criteria);
		}

        /// <summary>
        /// Returns the first entity to match the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public T FindFirst(DetachedCriteria criteria)
        {
            IList<T> results = criteria.SetFirstResult(0)
                .SetMaxResults(1)
                .GetExecutableCriteria(Session).List<T>();

            if (results.Count > 0)
                return results[0];

            return default(T);
        }

        /// <summary>
        /// Returns the first entity to match the given criteria, ordered by the given order
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public T FindFirst(DetachedCriteria criteria, Order order)
        {
            return FindFirst(criteria.AddOrder(order));
        }

        /// <summary>
        /// Returns the total number of entities that match the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public long Count(DetachedCriteria criteria)
        {
            return Convert.ToInt64(criteria
                .GetExecutableCriteria(Session)
                .SetProjection(Projections.RowCountInt64()).UniqueResult());
        }

        /// <summary>
        /// Returns true if at least one entity exists that matches the given criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public bool Exists(DetachedCriteria criteria)
        {
            return Count(criteria) > 0;
        }
    }
}
