using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System.Linq;

namespace App.DataLayer.RepositoryManagers
{

    public class RepositoryManager<T, TKey> : IRepositoryManager<T, TKey>
        where T : IEntity<TKey>
    {
        private readonly MongoCollection<T> _collection;

        public RepositoryManager()
            : this(Util<TKey>.GetDefaultConnectionString())
        {
        }

        public RepositoryManager(string connectionString)
        {
            this._collection = Util<TKey>.GetCollectionFromConnectionString<T>(connectionString);
        }

        public RepositoryManager(string connectionString, string collectionName)
        {
            this._collection = Util<TKey>.GetCollectionFromConnectionString<T>(connectionString, collectionName);
        }

        public virtual bool Exists
        {
            get { return this._collection.Exists(); }
        }

        public virtual string Name
        {
            get { return this._collection.Name; }
        }

        public virtual void Drop()
        {
            this._collection.Drop();
        }

        public virtual bool IsCapped()
        {
            return this._collection.IsCapped();
        }

        public virtual void DropIndex(string keyname)
        {
            this.DropIndexes(new string[] { keyname });
        }

        public virtual void DropIndexes(IEnumerable<string> keynames)
        {
            this._collection.DropIndex(keynames.ToArray());
        }

        public virtual void DropAllIndexes()
        {
            this._collection.DropAllIndexes();
        }

        public virtual void EnsureIndex(string keyname)
        {
            this.EnsureIndexes(new string[] { keyname });
        }

        public virtual void EnsureIndex(string keyname, bool descending, bool unique, bool sparse)
        {
            this.EnsureIndexes(new string[] { keyname }, descending, unique, sparse);
        }

        public virtual void EnsureIndexes(IEnumerable<string> keynames)
        {
            this.EnsureIndexes(keynames, false, false, false);
        }

        public virtual void EnsureIndexes(IEnumerable<string> keynames, bool descending, bool unique, bool sparse)
        {
            var ixk = new IndexKeysBuilder();
            if (descending)
            {
                ixk.Descending(keynames.ToArray());
            }
            else
            {
                ixk.Ascending(keynames.ToArray());
            }

            this.EnsureIndexes(
                ixk,
                new IndexOptionsBuilder().SetUnique(unique).SetSparse(sparse));
        }

        public virtual void EnsureIndexes(IMongoIndexKeys keys, IMongoIndexOptions options)
        {
            this._collection.CreateIndex(keys, options);
        }

        public virtual bool IndexExists(string keyname)
        {
            return this.IndexesExists(new string[] { keyname });
        }

        public virtual bool IndexesExists(IEnumerable<string> keynames)
        {
            return this._collection.IndexExists(keynames.ToArray());
        }

        public virtual void ReIndex()
        {
            this._collection.ReIndex();
        }

        public virtual long GetTotalDataSize()
        {
            return this._collection.GetTotalDataSize();
        }

        public virtual long GetTotalStorageSize()
        {
            return this._collection.GetTotalStorageSize();
        }

        public virtual ValidateCollectionResult Validate()
        {
            return this._collection.Validate();
        }

        public virtual CollectionStatsResult GetStats()
        {
            return this._collection.GetStats();
        }

        public virtual GetIndexesResult GetIndexes()
        {
            return this._collection.GetIndexes();
        }
    }

    public class RepositoryManager<T> : RepositoryManager<T, string>, IRepositoryManager<T>
        where T : IEntity<string>
    {
        public RepositoryManager()
            : base() { }

        public RepositoryManager(string connectionString)
            : base(connectionString) { }

        public RepositoryManager(string connectionString, string collectionName)
            : base(connectionString, collectionName) { }
    }
}
