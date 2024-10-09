namespace DataStructuresAndAlgorithms.DataStructures.Linear.SinglyLinkedList
{
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