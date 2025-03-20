namespace DataStructuresAndAlgorithms.DataStructures.Linear.Stack
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a stack data structure that follows the Last-In-First-Out (LIFO) principle.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public interface IMyStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the number of elements in the stack.
        /// </summary>
        /// <value>The count of elements in the stack.</value>
        int Count { get; }

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="element">The element to push onto the stack.</param>
        void Push(T element);

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        T Pop();

        /// <summary>
        /// Returns the top element of the stack without removing it.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        T Peek();

        /// <summary>
        /// Checks whether the stack contains the specified element.
        /// </summary>
        /// <param name="element">The element to locate in the stack.</param>
        /// <returns><c>true</c> if the stack contains the element; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the element is null.</exception>
        bool Contains(T element);

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
        void Clear();

        /// <summary>
        /// Copies the elements of the stack to a new array.
        /// </summary>
        /// <returns>An array containing all the elements of the stack.</returns>
        T[] ToArray();
    }
}
