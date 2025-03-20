namespace DataStructuresAndAlgorithms.DataStructures.Linear.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a generic queue that follows the FIFO (First-In-First-Out) principle.
    /// Implements the <see cref="IMyQueue{T}"/> interface with common queue operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public class MyQueue<T> : IMyQueue<T>
    {
        class Node
        {
            public Node(T element) => this.Element = element;

            public T Element { get; }

            public Node? Next { get; internal set; }
        }

        private Node? head;
        private Node? tail;

        /// <inheritdoc/>
        public int Count { get; private set; }

        /// <inheritdoc/>
        public void Enqueue(T element)
        {
            var node = new Node(element);

            if (this.head is null)
            {
                this.head = node;
                this.tail = this.head;
            }
            else
            {
                var previousTail = this.tail;
                this.tail = node;
                previousTail!.Next = this.tail;
            }

            this.Count++;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            return this.head!.Element;
        }

        /// <inheritdoc/>
        public bool Contains(T element)
        {
            var current = this.head;

            while (current is not null)
            {
                if (current.Element!.Equals(element))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <inheritdoc/>
        public void Clear()
        {
            this.head = null;
            this.tail = null;
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
    }
}