namespace DataStructuresAndAlgorithms.DataStructures.Linear.CircularQueue
{
    using System.Collections.Generic;

    public interface IMyCircularQueue<T> : IEnumerable<T>
    {
        int Count { get; }

        void Enqueue(T element);

        T Dequeue();

        T Peek();

        T[] ToArray();

        void Clear();
    }
}
