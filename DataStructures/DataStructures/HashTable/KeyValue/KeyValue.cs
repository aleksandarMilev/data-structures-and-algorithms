namespace DataStructuresAndAlgorithms.DataStructures.HashTable.KeyValue
{
    using System;

    public class KeyValue<TKey, TValue>
        where TKey : IComparable
        where TValue : IComparable
    {
        public KeyValue(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is KeyValue<TKey, TValue> that)
            {
                return
                    this.Key.CompareTo(that.Key) == 0 &&
                    this.Value.CompareTo(that.Value) == 0;
                  
            }

            return false;
        }

        public override int GetHashCode() => HashCode.Combine(this.Key.GetHashCode(), this.Value.GetHashCode());

        public override string ToString() => $"[{this.Key} -> {this.Value}]";
    }
}
