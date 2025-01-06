namespace DataStructuresAndAlgorithms.DataStructures.Linear.SinglyLinkedList
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MySinglyLinkedListTests
    {
        [Fact]
        public void AddFirstShouldAddElementAtTheBeginningOfTheList()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.GetFirst().Should().Be(3); 
        }

        [Fact]
        public void AddLastShouldAddElementAtTheEndOfTheList()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.GetLast().Should().Be(3);
        }

        [Fact]
        public void RemoveFirstShouldRemoveElementFromTheBeginningOfTheList()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.RemoveFirst();

            list.GetFirst().Should().Be(2);
        }

        [Fact]
        public void RemoveFirstShouldThrowInvalidOperationExceptionWhenListIsEmpty()
        {
            var list = new MySinglyLinkedList<int>();

            list
                .Invoking(l => l.RemoveFirst())
                .Should()
                .Throw<InvalidOperationException>();
        }

        [Fact]
        public void RemoveFirstShouldReturnTheRemovedElement()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.RemoveFirst().Should().Be(3);
        }

        [Fact]
        public void GetFirstShouldReturnTheFirstElement()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.GetFirst().Should().Be(3);
        }

        [Fact]
        public void GetLastShouldReturnTheLastElement()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.GetLast().Should().Be(1);
        }

        [Fact]
        public void GetFirstShouldThrowInvalidOperationExceptionWhenListIsEmpty()
        {
            var list = new MySinglyLinkedList<int>();

            list
                .Invoking(l => l.GetFirst())
                .Should()
                .Throw<InvalidOperationException>();
        }

        [Fact]
        public void GetLastShouldThrowInvalidOperationExceptionWhenListIsEmpty()
        {
            var list = new MySinglyLinkedList<int>();

            list
                .Invoking(l => l.GetLast())
                .Should()
                .Throw<InvalidOperationException>();
        }

        [Fact]
        public void CountShouldReturnTheNumberOfElementsInTheList()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.Count.Should().Be(3);
        }

        [Fact]
        public void CountShouldReturnZeroWhenListIsEmpty()
        {
            var list = new MySinglyLinkedList<int>();

            list.Count.Should().Be(0);
        }

        [Fact]
        public void ClearShouldRemoveAllElementsFromTheList()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.Clear();

            list.Count.Should().Be(0);
        }

        [Fact]
        public void ToArrayShouldReturnAnArrayWithAllElementsInTheList()
        {
            var list = new MySinglyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.ToArray().Should().BeEquivalentTo([ 3, 2, 1 ]);
        }

        [Fact]
        public void ToArrayShouldReturnAnEmptyArrayWhenListIsEmpty()
        {
            var list = new MySinglyLinkedList<int>();

            list.ToArray().Should().BeEmpty();
        }
    }
}
