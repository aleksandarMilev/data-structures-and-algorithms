namespace DataStructuresAndAlgorithms.DataStructures.Linear.SinglyLinkedList
{
    using System.Collections;

    public class MySinglyLinkedList<T> : IMySinglyLinkedList<T>
    {
        public class Node
        {
            public Node(T element) => this.Element = element;

            public T Element { get; set; }
            public Node? Next { get; set; }
        }

        private Node? head;
        private Node? tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var newNode = new Node(element);
            this.Count++;

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
                return;
            }

            newNode.Next = this.head;
            this.head = newNode;
        }

        public void AddLast(T element)
        {
            var newNode = new Node(element);
            this.Count++;

            if (this.tail == null)
            {
                this.head = newNode;
                this.tail = newNode;
                return;
            }

            this.tail.Next = newNode;
            this.tail = newNode;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            var returnValue = this.head.Element;
            this.head = this.head.Next;

            if (this.head == null)
            {
                this.tail = null;
            }

            this.Count--;
            return returnValue;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            this.Count--;
            T returnValue = default!;

            if (this.head == this.tail)
            {
                returnValue = this.head.Element;
                this.head = null;
                this.tail = null;

                return returnValue;
            }

            var current = this.head;

            while (current!.Next != this.tail)
            {
                current = current.Next;
            }

            returnValue = this.tail!.Element;
            this.tail = current;
            this.tail.Next = null;

            return returnValue;
        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            return this.head.Element;
        }

        public T GetLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            return this.tail.Element;
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