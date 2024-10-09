namespace DataStructuresAndAlgorithms.DataStructures.Linear.Stack
{
    public interface IMyStack<T> : IEnumerable<T>
    {
        void Push(T element);
        T Pop();
        T Peek();
        int Count { get; }
        bool Contains(T element);
    }
}