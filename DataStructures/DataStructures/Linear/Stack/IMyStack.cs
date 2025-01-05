namespace DataStructuresAndAlgorithms.DataStructures.Linear.Stack
{
    using System.Collections.Generic;

    public interface IMyStack<T> : IEnumerable<T>
    {
        int Count { get; }

        void Push(T element);

        T Pop();

        T Peek();

        bool Contains(T element);
    }
}