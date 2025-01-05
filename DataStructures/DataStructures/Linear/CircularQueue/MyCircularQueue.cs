namespace DataStructuresAndAlgorithms.DataStructures.Linear.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyCircularQueue<T> : IMyCircularQueue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] elements;
        private int startIndex;
        private int endIndex;

        public MyCircularQueue(int capacity = DefaultCapacity) => this.elements = new T[capacity];

        public int Count { get; private set; } = 0;

        public void Enqueue(T element)
        {
            if (this.elements.Length == this.Count)
            {
                this.Grow();
            }

            this.elements[endIndex] = element;
            this.endIndex = (endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var dequeuedElementValue = this.elements[this.startIndex];
            this.elements[this.startIndex] = default!;
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return dequeuedElementValue;

        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            return this.elements[this.startIndex];
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                var currentIndex = (this.startIndex + i) % this.elements.Length;
                result[i] = this.elements[currentIndex];
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var currentIndex = (this.startIndex + i) % this.elements.Length;
                yield return this.elements[currentIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Grow()
        {
            var newArr = new T[this.Count * 2];

            for (int i = 0; i < this.Count; i++)
            {
                var currentIndex = (this.startIndex + i) % this.elements.Length;
                newArr[i] = this.elements[currentIndex];
            }

            this.elements = newArr;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }
    }
}