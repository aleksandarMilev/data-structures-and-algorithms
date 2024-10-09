namespace DataStructuresAndAlgorithms.DataStructures.Linear.Queue
{
    using System.Collections;

    public class MyQueue<T> : IMyQueue<T>
    {
        class Node
        {
            public Node(T element) => this.Element = element;

            public T Element { get; init; }
            public Node? Next { get; set; }
        }

        private Node? head;
        private Node? tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var node = new Node(element);

            if (this.head == null)
            {
                this.head = node;
                this.tail = head;
            }
            else
            {
                var previousTail = this.tail;
                this.tail = node;
                previousTail!.Next = this.tail;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            var returnValue = this.head!.Element;
            this.head = this.head.Next;
            this.Count--;

            if (this.Count == 0)
            {
                this.tail = null;
            }

            return returnValue;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            return this.head!.Element;
        }

        public bool Contains(T element)
        {
            var current = this.head;

            while (current != null)
            {
                if (current.Element!.Equals(element))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
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