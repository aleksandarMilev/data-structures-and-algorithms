namespace DataStructuresAndAlgorithms.DataStructures.HashTable
{
    using System;
    using System.Collections.Generic;
    using KeyValue;

    public interface IMyDictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
        where TKey : IComparable
        where TValue : IComparable
    {
        int Count { get; }

        TValue this[TKey key] { get; set; }

        void Add(TKey key, TValue value);

        void AddOrReplace(TKey key, TValue value);

        TValue GetByKey(TKey key);

        bool TryGetValue(TKey key, out TValue value);

        bool ContainsKey(TKey key);

        bool RemoveByKey(TKey key);

        void Clear();

        IEnumerable<TKey> GetAllKeys();

        IEnumerable<TValue> GetAllValues();
    }
}
