namespace DataStructuresAndAlgorithms.DataStructures.Linear.DoublyLinkedList
{
    using System.Collections;

    public class MyDoublyLInkedList<T> : IMyDoublyLinkedList<T>
    {
        class Node
        {
            public Node(T element) => this.Element = element;

            public Node? Next { get; set; }
            public Node? Previous { get; set; }
            public T Element { get; set; }
        }

        private Node? head;
        private Node? tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var node = new Node(element);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var node = new Node(element);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                node.Previous = this.tail;
                this.tail!.Next = node;
                this.tail = node;
            }

            Count++;
        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.Element;
        }

        public T GetLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException();
            }

            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            this.Count--;
            var returnValue = this.head.Element;

            if (this.head.Next == null)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            return returnValue;
        }

        public T RemoveLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException();
            }

            this.Count--;
            var returnValue = this.tail.Element;

            if (this.head == tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail!.Next = null;
            }

            return returnValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}