namespace DataStructuresAndAlgorithms.DataStructures.Linear.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<T> : IMyStack<T>
    {
        private class Node
        {
            public Node(T value) => this.Value = value;

            public Node? Next { get; set; }

            public T Value { get; set; }
        }

        private Node? top;

        public int Count { get; private set; } = 0;

        public void Push(T element)
        {
            ArgumentNullException.ThrowIfNull(element);

            if (this.top == null)
            {
                this.top = new Node(element);
            }
            else
            {
                var previousTop = this.top;
                this.top = new Node(element);
                this.top.Next = previousTop;
            }

            Count++;
        }

        public T Peek()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.top.Value;
        }

        public T Pop()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var returnValue = this.top.Value;
            this.Count--;

            if (this.Count == 0)
            {
                this.top = null;
            }
            else
            {
                this.top = this.top.Next;
            }

            return returnValue;
        }

        public bool Contains(T element)
        {
            ArgumentNullException.ThrowIfNull(element);

            var current = this.top;

            while (current != null)
            {
                if (current.Value!.Equals(element))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.top;

            while (current != null)
            {
                yield return current.Value!;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}