namespace DataStructuresAndAlgorithms.DataStructures.Tree
{
    public class BinarySearchTree<T> 
        where T : IComparable<T>
    {
        private TreeNode<T>? root;

        public void Insert(T value) => this.root = this.InsertRec(this.root, value);

        private TreeNode<T>? InsertRec(TreeNode<T>? node, T value)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                return node;
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = this.InsertRec(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = this.InsertRec(node.Right, value);
            }

            return node;
        }

        public void InOrderDFS(Action<T> action) => this.InOrderDFS(this.root, action);

        private void InOrderDFS(TreeNode<T>? node, Action<T> act)
        {
            if (node != null)
            {
                this.InOrderDFS(node.Left, act);
                act(node.Value);
                this.InOrderDFS(node.Right, act);
            }
        }

        public void PreOrderDFS(Action<T> action) => this.PreOrderDFS(this.root, action);

        private void PreOrderDFS(TreeNode<T>? node, Action<T> act)
        {
            if (node != null)
            {
                act(node.Value);
                this.PreOrderDFS(node.Left, act);
                this.PreOrderDFS(node.Right, act);
            }
        }

        public void PostOrderDFS(Action<T> action) => this.PostOrderDFS(this.root, action);

        private void PostOrderDFS(TreeNode<T>? node, Action<T> act)
        {
            if (node != null)
            {
                this.PostOrderDFS(node.Left, act);
                this.PostOrderDFS(node.Right, act);
                act(node.Value);
            }
        }

        public void BFS(Action<T> action) => this.BFS(this.root, action);

        private void BFS(TreeNode<T>? node, Action<T> act)
        {
            if (node == null)
            {
                return;
            }

            var nodes = new Queue<TreeNode<T>>();
            nodes.Enqueue(node);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();
                act(current.Value);

                if (current.Left != null)
                {
                    nodes.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    nodes.Enqueue(current.Right);
                }
            }
        }
    }
}
