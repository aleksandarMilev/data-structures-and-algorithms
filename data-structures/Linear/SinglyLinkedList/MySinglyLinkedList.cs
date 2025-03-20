namespace DataStructuresAndAlgorithms.DataStructures.Linear.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class MySinglyLinkedList<T> : IMySinglyLinkedList<T>
    {
        private class Node
        {
            public Node(T element) => this.Element = element;

            public T Element { get; init; }

            public Node? Next { get; internal set; }
        }

        private Node? head;
        private Node? tail;

        /// <inheritdoc/>
        public int Count { get; private set; }

        /// <inheritdoc/>
        public void AddFirst(T element)
        {
            var newNode = new Node(element);
            this.Count++;

            if (this.head is null)
            {
                this.SetHeadAndTail(newNode);
                return;
            }

            newNode.Next = this.head;
            this.head = newNode;
        }

        /// <inheritdoc/>
        public void AddLast(T element)
        {
            var newNode = new Node(element);
            this.Count++;

            if (this.tail is null)
            {
                this.SetHeadAndTail(newNode);
                return;
            }

            this.tail.Next = newNode;
            this.tail = newNode;
        }

        /// <inheritdoc/>
        public T RemoveFirst()
        {
            if (this.head is null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            var returnValue = this.head.Element;
            this.head = this.head.Next;

            if (this.head is null)
            {
                this.tail = null;
            }

            this.Count--;
            return returnValue;
        }

        /// <inheritdoc/>
        public T RemoveLast()
        {
            if (this.head is null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            this.Count--;
            T returnValue;

            if (this.head == this.tail)
            {
                returnValue = this.head.Element;
                this.SetHeadAndTail(null);

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

        /// <inheritdoc/>
        public T GetFirst()
        {
            if (this.head is null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            return this.head.Element;
        }

        /// <inheritdoc/>
        public T GetLast()
        {
            if (this.tail is null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            return this.tail.Element;
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