namespace DataStructuresAndAlgorithms.DataStructures.Graph
{
    using System;
    using System.Collections.Generic;

    class AdjacencyGraph<T> : IAdjacencyGraph<T>
         where T : notnull, IComparable
    {
        private readonly Dictionary<T, ICollection<T>> elements = [];

        public void Add(T edge, List<T> adjacenciesToAdd)
        {
            if (this.elements.TryGetValue(edge, out var existingAdjacencies))
            {
                foreach (var adjacency in adjacenciesToAdd)
                {
                    if (!existingAdjacencies.Contains(adjacency))
                    {
                        existingAdjacencies.Add(adjacency);
                    }
                }
            }
            else
            {
                this.elements[edge] = new List<T>(adjacenciesToAdd);
            }
        }

        public bool Remove(T edge) => this.elements.Remove(edge);

        public void GetAdjacencies(T edge, Action<T> action)
        {
            if (this.elements.TryGetValue(edge, out var adjacencies))
            {
                foreach (var adjacency in adjacencies)
                {
                    action(adjacency);
                }
            }
            else
            {
                throw new ArgumentException("The node does not exist!");
            }
        }

        public void Bfs(T start, Action<T> action)
        {
            var visited = new HashSet<T>() { start };

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                action(current);

                if (this.elements.TryGetValue(current, out var adjacencies))
                {
                    foreach (var adjacency in adjacencies)
                    {
                        if (visited.Add(adjacency))
                        {
                            queue.Enqueue(adjacency);
                        }
                    }
                }
            }
        }

        public void DfsIterative(T start, Action<T> action)
        {
            var visited = new HashSet<T>() { start };

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                action(current);

                if (this.elements.TryGetValue(current, out var adjacencies))
                {
                    foreach (var adjacency in adjacencies)
                    {
                        if (visited.Add(adjacency))
                        {
                            stack.Push(adjacency);
                        }
                    }
                }
            }
        }

        public void DfsRecursive(T start, Action<T> action) => this.DfsRecursive(start, [], action);

        private void DfsRecursive(T start, HashSet<T> visited, Action<T> action)
        {
            visited.Add(start);
            action(start);

            if (this.elements.TryGetValue(start, out var adjacencies))
            {
                foreach (var adjacency in adjacencies)
                {
                    if (!visited.Contains(adjacency))
                    {
                        this.DfsRecursive(adjacency, visited, action);
                    }
                }
            }
        }
    }
}
