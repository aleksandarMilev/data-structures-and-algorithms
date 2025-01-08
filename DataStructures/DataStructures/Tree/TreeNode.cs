namespace DataStructuresAndAlgorithms.DataStructures.Tree
{ 
    public class TreeNode<T>
    {
        public TreeNode(T value) => this.Value = value;

        public T Value { get; }

        public TreeNode<T>? Left { get; internal set; }

        public TreeNode<T>? Right { get; internal set; }
    }
}
