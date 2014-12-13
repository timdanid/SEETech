using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.DataLayer.Repositories
{
    public interface IRepository<T, TKey> : IQueryable<T>
        where T : IEntity<TKey>
    {
        MongoCollection<T> Collection { get; }

        T GetById(TKey id);

        T Add(T entity);

        void Add(IEnumerable<T> entities);

        T Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(TKey id);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> predicate);

        void DeleteAll();

        long Count();

        bool Exists(Expression<Func<T, bool>> predicate);

        IDisposable RequestStart();

        void RequestDone();
    }

    public interface IRepository<T> : IQueryable<T>, IRepository<T, string>
        where T : IEntity<string> { }
}
