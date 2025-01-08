namespace DataStructuresAndAlgorithms.DataStructures.Linear.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class MyDoublyLinkedList<T> : IMyDoublyLinkedList<T>
    {
        private class Node
        {
            public Node(T element) => this.Element = element;

            public Node? Next { get; internal set; }

            public Node? Previous { get; internal set; }

            public T Element { get; init; }
        }

        private Node? head;
        private Node? tail;

        /// <inheritdoc/>
        public int Count { get; private set; }

        /// <inheritdoc/>
        public void AddFirst(T element)
        {
            var node = new Node(element);

            if (this.head is null)
            {
                this.SetHeadAndTail(node);
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }

            this.Count++;
        }

        /// <inheritdoc/>
        public void AddLast(T element)
        {
            var node = new Node(element);

            if (this.head is null)
            {
                this.SetHeadAndTail(node);
            }
            else
            {
                node.Previous = this.tail;
                this.tail!.Next = node;
                this.tail = node;
            }

            Count++;
        }

        /// <inheritdoc/>
        public T GetFirst()
        {
            if (this.head is null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            return this.head.Element;
        }

        /// <inheritdoc/>
        public T GetLast()
        {
            if (this.tail is null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            return this.tail.Element;
        }

        /// <inheritdoc/>
        public T RemoveFirst()
        {
            if (this.head is null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            this.Count--;
            var returnValue = this.head.Element;

            if (this.head.Next is null)
            {
                this.SetHeadAndTail(null);
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            return returnValue;
        }

        /// <inheritdoc/>
        public T RemoveLast()
        {
            if (this.tail is null)
            {
                throw new InvalidOperationException("List is empty!");
            }

            this.Count--;
            var returnValue = this.tail.Element;

            if (this.head == tail)
            {
                this.SetHeadAndTail(null);
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail!.Next = null;
            }

            return returnValue;
        }

        /// <inheritdoc/>
        public void Clear()
        {
            this.SetHeadAndTail(null);
            this.Count = 0;
        }

        /// <inheritdoc/>
        public T[] ToArray()
        {
            var result = new T[this.Count];
            var current = this.head;
            var index = 0;

            while (current is not null)
            {
                result[index] = current.Element;
                current = current.Next;
                index++;
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current is not null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void SetHeadAndTail(Node? node = null)
        {
            this.head = node;
            this.tail = node;
        }
    }
}
