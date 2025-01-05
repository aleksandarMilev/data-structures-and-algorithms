namespace DataStructuresAndAlgorithms.DataStructures.HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using KeyValue;

    public class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>
        where TKey : IComparable
        where TValue : IComparable
    {
        private const int DefaultCapacity = 4;
        private const double LoadFactor = 0.75;

        private LinkedList<KeyValue<TKey, TValue>>[] elements;

        public MyDictionary(int capacity = DefaultCapacity) => this.elements = new LinkedList<KeyValue<TKey, TValue>>[capacity];

        public TValue this[TKey key]
        {
            get => this.GetByKey(key);
            set => this.AddOrReplace(key, value);
        }

        public int Count { get; private set; }

        public void Add(TKey key, TValue value) => this.Add(key, value, replace: false);

        public void AddOrReplace(TKey key, TValue value) => this.Add(key, value, replace: true);

        public TValue GetByKey(TKey key)
        {
            ArgumentNullException.ThrowIfNull(key);

            var index = this.GetIndexByKey(key);
            var currentArrayCell = this.elements[index];

            if (currentArrayCell != null)
            {
                var currentNode = currentArrayCell.First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        return currentNode.Value.Value;
                    }

                    currentNode = currentNode.Next;
                }
            }

            throw new KeyNotFoundException($"The Key '{key}' was not found in the hash table!");
        }

        public bool TryGetValue(TKey key, out TValue value) 
        {
            ArgumentNullException.ThrowIfNull(key);

            try
            {
                value = this.GetByKey(key);
                return true;
            }
            catch (KeyNotFoundException)
            {
                value = default!;
                return false;
            }
        }

        public bool RemoveByKey(TKey key)
        {
            ArgumentNullException.ThrowIfNull(key);

            var index = this.GetIndexByKey(key);
            var currentArrayCell = this.elements[index];

            if  (currentArrayCell != null)
            {
                var currentNode = currentArrayCell.First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        currentArrayCell.Remove(currentNode);  
                        this.Count--;  
                        return true;
                    }

                    currentNode = currentNode.Next;
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            ArgumentNullException.ThrowIfNull(key);

            try
            {
                _ = this.GetByKey(key);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> GetAllKeys() => this.GetAll(kvp => kvp.Key);

        public IEnumerable<TValue> GetAllValues() => this.GetAll(kvp => kvp.Value);

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                if (element != null)
                {
                    foreach (var kvp in element)
                    {
                        yield return kvp;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Add(TKey key, TValue value, bool replace = false)
        {
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(value);

            if ((double)(this.Count + 1) / this.elements.Length >= LoadFactor)
            {
                this.Grow();
            }

            var index = this.GetIndexByKey(key);
            this.elements[index] ??= new LinkedList<KeyValue<TKey, TValue>>();
            foreach (var element in this.elements[index])
            {
                if (element.Key.Equals(key))
                {
                    if (replace)
                    {
                        element.Value = value;
                        return;
                    }

                    throw new ArgumentException("Element with such key is already added!");
                }
            }

            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.elements[index].AddLast(newElement);
            this.Count++;
        }

        private void Grow()
        {
            var newHashTable = new MyDictionary<TKey, TValue>(this.Count * 2);
            foreach (var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }

            this.elements = newHashTable.elements;
        }

        private IEnumerable<TResult> GetAll<TResult>(Func<KeyValue<TKey, TValue>, TResult> selector)
        {
            var result = new List<TResult>();

            foreach (var element in this.elements)
            {
                if (element != null)
                {
                    foreach (var kvp in element)
                    {
                        result.Add(selector(kvp));
                    }
                }
            }

            return result;
        }

        private int GetIndexByKey(TKey key) => Math.Abs(key.GetHashCode()) % this.elements.Length;
    }
}
