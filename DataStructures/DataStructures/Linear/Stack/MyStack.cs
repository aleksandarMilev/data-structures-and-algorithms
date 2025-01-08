namespace DataStructuresAndAlgorithms.DataStructures.Linear.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a generic stack that follows the LIFO (Last-In-First-Out) principle.
    /// Implements the <see cref="IMyStack{T}"/> interface with common stack operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public class MyStack<T> : IMyStack<T>
    {
        private class Node
        {
            public Node(T value) => this.Value = value;

            public Node(T value, Node? next)
                : this(value)
                    => this.Next = next;

            public Node? Next { get; }

            public T Value { get; }
        }

        private Node? top;

        /// <inheritdoc/>
        public int Count { get; private set; }

        /// <inheritdoc/>
        public void Push(T element)
        {
            if (this.top is null)
            {
                this.top = new Node(element);
            }
            else
            {
                var previousTop = this.top;
                var newTop = new Node(element, previousTop);
                this.top = newTop;
            }

            this.Count++;
        }

        /// <inheritdoc/>
        public T Peek()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.top.Value;
        }

        /// <inheritdoc/>
        public T Pop()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var returnValue = this.top.Value;
            this.top = this.top.Next;
            this.Count--;

            return returnValue;
        }

        /// <inheritdoc/>
        public bool Contains(T element)
        {
            var current = this.top;

            while (current is not null)
            {
                if (current.Value!.Equals(element))
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
            this.top = null;
            this.Count = 0;
        }

        /// <inheritdoc/>
        public T[] ToArray()
        {
            var result = new T[this.Count];
            var current = this.top;
            var index = this.Count - 1;

            while (current is not null)
            {
                result[index] = current.Value;
                current = current.Next;
                index--;
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.top;

            while (current is not null)
            {
                yield return current.Value!;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
