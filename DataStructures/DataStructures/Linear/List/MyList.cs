namespace DataStructuresAndAlgorithms.DataStructures.Linear.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a dynamically resizable list of elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class MyList<T> : IMyList<T>
    {
        private const int DefaultLength = 4;
        private T[] items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyList{T}"/> class with an optional initial capacity.
        /// </summary>
        /// <param name="length">The initial capacity of the list.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="length"/> is less than or equal to zero.</exception>
        public MyList(int length = DefaultLength)
        {
            if (length <= 0)
            {
                throw new ArgumentException($"{nameof(length)} should be greater than 0!");
            }

            this.items = new T[length];
        }

        /// <inheritdoc/>
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);

                this.items[index] = value;
            }
        }

        /// <inheritdoc/>
        public int Count { get; private set; }

        /// <inheritdoc/>
        public int Capacity => this.items.Length;

        /// <inheritdoc/>
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Grow();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public int IndexOf(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <inheritdoc/>
        public void Insert(int index, T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Index is not valid");
            }

            if (this.Count == this.items.Length)
            {
                this.Grow();
            }

            this.ShiftRight(index);

            this.items[index] = item;
            this.Count++;
        }

        /// <inheritdoc/>
        public bool Remove(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i]!.Equals(item))
                {
                    this.ShiftLeft(i);
                    this.Count--;

                    if (this.ShouldShrink())
                    {
                        this.Shrink();
                    }

                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            this.ShiftLeft(index);
            this.Count--;

            if (this.ShouldShrink())
            {
                this.Shrink();
            }
        }

        /// <inheritdoc/>
        public T[] ToArray()
        {
            var result = new T[this.Count];

            Array.Copy(this.items, result, this.Count);

            return result;
        }

        /// <inheritdoc/>
        public void Clear()
        {
            this.items = new T[DefaultLength];
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is not valid");
            }
        }

        private void Grow()
        {
            var newArrLength = this.Count > 0 ? this.Count * 2 : DefaultLength;
            var newArr = new T[newArrLength];

            Array.Copy(this.items, newArr, this.Count);

            this.items = newArr;
        }

        private void Shrink()
        {
            var newArrLength = Math.Max(DefaultLength, this.Count);
            var newArr = new T[newArrLength];

            Array.Copy(this.items, newArr, this.Count);

            this.items = newArr;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default!;
        }

        private bool ShouldShrink() 
            => this.Count < this.items.Length / 4 && this.items.Length > DefaultLength;
    }
}
