namespace DataStructuresAndAlgorithms.DataStructures.Linear.List
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a generic list that provides methods to manipulate a collection of elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public interface IMyList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        T this[int index] { get; set; }

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the current capacity of the list.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Determines whether the list contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the list.</param>
        /// <returns><c>true</c> if the item is found; otherwise, <c>false</c>.</returns>
        bool Contains(T item);

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a specific item.
        /// </summary>
        /// <param name="item">The object to locate in the list.</param>
        /// <returns>
        /// The zero-based index of the first occurrence, or -1 if the item is not found.
        /// </returns>
        int IndexOf(T item);

        /// <summary>
        /// Adds an item to the end of the list.
        /// </summary>
        /// <param name="item">The object to add to the list.</param>
        void Add(T item);

        /// <summary>
        /// Inserts an item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        void Insert(int index, T item);

        /// <summary>
        /// Removes the first occurrence of a specific object from the list.
        /// </summary>
        /// <param name="item">The object to remove.</param>
        /// <returns><c>true</c> if the item was successfully removed; otherwise, <c>false</c>.</returns>
        bool Remove(T item);

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        void RemoveAt(int index);

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        void Clear();

        /// <summary>
        /// Copies the elements of the list to a new array.
        /// </summary>
        /// <returns>An array containing the elements of the list.</returns>
        T[] ToArray();
    }
}
