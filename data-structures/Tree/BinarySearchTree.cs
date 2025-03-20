namespace DataStructuresAndAlgorithms.DataStructures.Tree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> 
        where T : IComparable<T>
    {
        private TreeNode<T>? root;

        public void Insert(T value) => this.root = Insert(this.root, value);

        public void InOrderDFS(Action<T> action) => InOrderDFS(this.root, action);

        public void PreOrderDFS(Action<T> action) => PreOrderDFS(this.root, action);

        public void PostOrderDFS(Action<T> action) => PostOrderDFS(this.root, action);

        public void BFS(Action<T> action) => BFS(this.root, action);

        private static TreeNode<T>? Insert(TreeNode<T>? node, T value)
        {
            if (node is null)
            {
                node = new TreeNode<T>(value);

                return node;
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        private static void InOrderDFS(TreeNode<T>? node, Action<T> action)
        {
            if (node is not null)
            {
                InOrderDFS(node.Left, action);
                action(node.Value);
                InOrderDFS(node.Right, action);
            }
        }

        private static void PreOrderDFS(TreeNode<T>? node, Action<T> action)
        {
            if (node is not null)
            {
                action(node.Value);
                PreOrderDFS(node.Left, action);
                PreOrderDFS(node.Right, action);
            }
        }

        private static void PostOrderDFS(TreeNode<T>? node, Action<T> action)
        {
            if (node is not null)
            {
                PostOrderDFS(node.Left, action);
                PostOrderDFS(node.Right, action);
                action(node.Value);
            }
        }

        private static void BFS(TreeNode<T>? node, Action<T> action)
        {
            if (node is null)
            {
                return;
            }

            var nodes = new Queue<TreeNode<T>>();
            nodes.Enqueue(node);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();
                action(current.Value);

                if (current.Left is not null)
                {
                    nodes.Enqueue(current.Left);
                }

                if (current.Right is not null)
                {
                    nodes.Enqueue(current.Right);
                }
            }
        }
    }
}
