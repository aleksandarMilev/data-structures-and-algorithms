namespace DataStructuresAndAlgorithms.DataStructures.Linear.Queue
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a generic queue interface with common queue operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public interface IMyQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the number of elements in the queue.
        /// </summary>
        /// <value>
        /// The number of elements in the queue.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Adds an element to the end of the queue.
        /// </summary>
        /// <param name="element">The element to add to the queue.</param>
        void Enqueue(T element);

        /// <summary>
        /// Returns the element at the front of the queue without removing it.
        /// </summary>
        /// <returns>
        /// The element at the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
        T Peek();

        /// <summary>
        /// Removes and returns the element at the front of the queue.
        /// </summary>
        /// <returns>
        /// The element at the front of the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
        T Dequeue();

        /// <summary>
        /// Checks if the queue contains a specific element.
        /// </summary>
        /// <param name="element">The element to search for in the queue.</param>
        /// <returns>
        /// <c>true</c> if the element is found in the queue; otherwise, <c>false</c>.
        /// </returns>
        bool Contains(T element);

        /// <summary>
        /// Removes all elements from the queue.
        /// </summary>
        void Clear();

        /// <summary>
        /// Copies the elements of the queue to a new array.
        /// </summary>
        /// <returns>
        /// An array containing all elements of the queue.
        /// </returns>
        T[] ToArray();
    }
}
