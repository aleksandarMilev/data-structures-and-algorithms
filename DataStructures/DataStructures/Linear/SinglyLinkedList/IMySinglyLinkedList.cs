namespace DataStructuresAndAlgorithms.DataStructures.Linear.SinglyLinkedList
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public interface IMySinglyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the number of elements contained in the list.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds an element at the beginning of the list.
        /// </summary>
        /// <param name="element">The element to add.</param>
        void AddFirst(T element);

        /// <summary>
        /// Adds an element at the end of the list.
        /// </summary>
        /// <param name="element">The element to add.</param>
        void AddLast(T element);

        /// <summary>
        /// Removes and returns the first element of the list.
        /// </summary>
        /// <returns>The first element of the list.</returns>
        T RemoveFirst();

        /// <summary>
        /// Removes and returns the last element of the list.
        /// </summary>
        /// <returns>The last element of the list.</returns>
        T RemoveLast();

        /// <summary>
        /// Gets the first element of the list without removing it.
        /// </summary>
        /// <returns>The first element of the list.</returns>
        T GetFirst();

        /// <summary>
        /// Gets the last element of the list without removing it.
        /// </summary>
        /// <returns>The last element of the list.</returns>
        T GetLast();

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        void Clear();

        /// <summary>
        /// Copies the elements of the list to a new array.
        /// </summary>
        /// <returns>An array containing all elements of the list in order.</returns>
        T[] ToArray();
    }
}
