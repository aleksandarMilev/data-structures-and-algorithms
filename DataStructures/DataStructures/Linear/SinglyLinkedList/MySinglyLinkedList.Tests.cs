namespace DataStructuresAndAlgorithms.DataStructures.Linear.SinglyLinkedList
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MySinglyLinkedListTests
    {
        private readonly MySinglyLinkedList<int> list = [];

        [Fact]
        public void AddFirstShouldAddElementAtTheBeginningOfTheList()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.GetFirst().Should().Be(3); 
        }

        [Fact]
        public void AddLastShouldAddElementAtTheEndOfTheList()
        {
            this.list.AddLast(1);
            this.list.AddLast(2);
            this.list.AddLast(3);

            this.list.GetLast().Should().Be(3);
        }

        [Fact]
        public void RemoveFirstShouldRemoveElementFromTheBeginningOfTheList()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.RemoveFirst();

            this.list.GetFirst().Should().Be(2);
        }

        [Fact]
        public void RemoveFirstShouldThrowInvalidOperationExceptionWhenListIsEmpty()
            => this.list
                .Invoking(l => l.RemoveFirst())
                .Should()
                .Throw<InvalidOperationException>();

        [Fact]
        public void RemoveFirstShouldReturnTheRemovedElement()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.RemoveFirst().Should().Be(3);
        }

        [Fact]
        public void GetFirstShouldReturnTheFirstElement()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.GetFirst().Should().Be(3);
        }

        [Fact]
        public void GetLastShouldReturnTheLastElement()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.GetLast().Should().Be(1);
        }

        [Fact]
        public void GetFirstShouldThrowInvalidOperationExceptionWhenListIsEmpty()
            => this.list
                .Invoking(l => l.GetFirst())
                .Should()
                .Throw<InvalidOperationException>();

        [Fact]
        public void GetLastShouldThrowInvalidOperationExceptionWhenListIsEmpty()
            => this.list
                .Invoking(l => l.GetLast())
                .Should()
                .Throw<InvalidOperationException>();

        [Fact]
        public void CountShouldReturnTheNumberOfElementsInTheList()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.Count.Should().Be(3);
        }

        [Fact]
        public void CountShouldReturnZeroWhenListIsEmpty() 
            => this.list.Count.Should().Be(0);

        [Fact]
        public void ClearShouldRemoveAllElementsFromTheList()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.Clear();

            this.list.Count.Should().Be(0);
        }

        [Fact]
        public void ToArrayShouldReturnAnArrayWithAllElementsInTheList()
        {
            this.list.AddFirst(1);
            this.list.AddFirst(2);
            this.list.AddFirst(3);

            this.list.ToArray().Should().BeEquivalentTo([ 3, 2, 1 ]);
        }

        [Fact]
        public void ToArrayShouldReturnAnEmptyArrayWhenListIsEmpty() 
            => this.list.ToArray().Should().BeEmpty();
    }
}
