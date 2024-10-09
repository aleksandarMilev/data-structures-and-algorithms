namespace DataStructuresAndAlgorithms.DataStructures.Tree
{ 
    public class TreeNode<T>
    {
        public TreeNode(T value) => this.Value = value;

        public T Value { get; init; }

        public TreeNode<T>? Left { get; set; }

        public TreeNode<T>? Right { get; set; }
    }
}
