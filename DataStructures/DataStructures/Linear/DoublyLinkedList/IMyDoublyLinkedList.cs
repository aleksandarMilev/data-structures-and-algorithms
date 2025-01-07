namespace DataStructuresAndAlgorithms.DataStructures.Linear.DoublyLinkedList
{
    using System.Collections.Generic;

    public interface IMyDoublyLinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        void AddFirst(T element);

        void AddLast(T element);

        T GetFirst();

        T GetLast();

        T RemoveFirst();

        T RemoveLast();

        void Clear();

        T[] ToArray();
    }
}
