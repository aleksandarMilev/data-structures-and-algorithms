namespace DataStructuresAndAlgorithms.DataStructures.Linear.List
{
    using System.Collections;

    public class MyList<T> : IMyList<T>
    {
        private const int DefaultLength = 4;
        private T[] items;

        public MyList(int length = DefaultLength)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length argument should be greater than 0!");
            }

            this.items = new T[length];
        }

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

        public int Count { get; private set; } = 0;

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Grow();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }

            return false;
        }

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

        public bool Remove(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i]!.Equals(item))
                {
                    this.ShiftLeft(i);
                    this.Count--;

                    if (this.Count < this.items.Length / 4 && this.items.Length > DefaultLength)
                    {
                        this.Shrink();
                    }

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            this.ShiftLeft(index);
            this.Count--;

            if (this.Count < this.items.Length / 4 && this.items.Length > DefaultLength)
            {
                this.Shrink();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Clear() => this.items = new T[DefaultLength];

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
    }
}