namespace DataStructuresAndAlgorithms.DataStructures.Linear.DoublyLinkedList
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a doubly linked list data structure, where each element points to both its next and previous elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the doubly linked list.</typeparam>
    public interface IMyDoublyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the number of elements in the doubly linked list.
        /// </summary>
        /// <value>The count of elements in the list.</value>
        int Count { get; }

        /// <summary>
        /// Adds an element to the beginning of the list.
        /// </summary>
        /// <param name="element">The element to add to the list.</param>
        void AddFirst(T element);

        /// <summary>
        /// Adds an element to the end of the list.
        /// </summary>
        /// <param name="element">The element to add to the list.</param>
        void AddLast(T element);

        /// <summary>
        /// Returns the first element in the list without removing it.
        /// </summary>
        /// <returns>The first element in the list.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T GetFirst();

        /// <summary>
        /// Returns the last element in the list without removing it.
        /// </summary>
        /// <returns>The last element in the list.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T GetLast();

        /// <summary>
        /// Removes and returns the first element of the list.
        /// </summary>
        /// <returns>The first element of the list.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T RemoveFirst();

        /// <summary>
        /// Removes and returns the last element of the list.
        /// </summary>
        /// <returns>The last element of the list.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        T RemoveLast();

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        void Clear();

        /// <summary>
        /// Copies the elements of the list to a new array.
        /// </summary>
        /// <returns>An array containing all the elements of the list.</returns>
        T[] ToArray();
    }
}
