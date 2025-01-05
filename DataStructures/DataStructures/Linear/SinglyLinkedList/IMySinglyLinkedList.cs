namespace DataStructuresAndAlgorithms.DataStructures.Linear.SinglyLinkedList
{
    using System.Collections.Generic;
    public interface IMySinglyLinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        void AddFirst(T element);

        void AddLast(T element);

        T RemoveFirst();

        T RemoveLast();

        T GetFirst();

        T GetLast();
    }
}