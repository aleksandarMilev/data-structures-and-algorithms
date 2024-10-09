namespace DataStructuresAndAlgorithms.DataStructures.Linear.List
{
    public interface IMyList<T> : IEnumerable<T>
    {
        T this[int index] { get; set; }
        int Count { get; }
        bool Contains(T item);
        int IndexOf(T item);
        void Add(T item);
        void Insert(int index, T item);
        bool Remove(T item);
        void RemoveAt(int index);
        void Clear();
    }
}
