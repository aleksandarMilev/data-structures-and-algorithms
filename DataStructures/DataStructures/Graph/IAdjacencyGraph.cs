namespace DataStructuresAndAlgorithms.DataStructures.Graph
{
    public interface IAdjacencyGraph<T>
    {
        void Add(T edge, List<T> adjacenciesToAdd);

        bool Remove(T edge);

        void GetAdjacencies(T edge, Action<T> action);

        void Bfs(T start, Action<T> action);

        void DfsIterative(T start, Action<T> action);

        void DfsRecursive(T start, Action<T> action);
    }
}
