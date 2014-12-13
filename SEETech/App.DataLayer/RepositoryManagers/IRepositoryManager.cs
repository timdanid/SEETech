using System.Collections.Generic;
using MongoDB.Driver;
using System;

namespace App.DataLayer.RepositoryManagers
{
    public interface IRepositoryManager<T, TKey>
        where T : IEntity<TKey>
    {
        bool Exists { get; }

        string Name { get; }

        void Drop();

        bool IsCapped();

        void DropIndex(string keyname);

        void DropIndexes(IEnumerable<string> keynames);

        void DropAllIndexes();

        void EnsureIndex(string keyname);

        void EnsureIndex(string keyname, bool descending, bool unique, bool sparse);

        void EnsureIndexes(IEnumerable<string> keynames);

        void EnsureIndexes(IEnumerable<string> keynames, bool descending, bool unique, bool sparse);

        void EnsureIndexes(IMongoIndexKeys keys, IMongoIndexOptions options);

        bool IndexExists(string keyname);

        bool IndexesExists(IEnumerable<string> keynames);

        void ReIndex();

        long GetTotalDataSize();

        long GetTotalStorageSize();

        ValidateCollectionResult Validate();

        CollectionStatsResult GetStats();

        GetIndexesResult GetIndexes();
    }

    public interface IRepositoryManager<T> : IRepositoryManager<T, string>
        where T : IEntity<string> { }
}
