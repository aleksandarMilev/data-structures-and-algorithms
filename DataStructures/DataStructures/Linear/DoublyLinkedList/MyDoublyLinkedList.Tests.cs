namespace DataStructuresAndAlgorithms.DataStructures.Linear.DoublyLinkedList
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MyDoublyLinkedListTests
    {
        private readonly MyDoublyLinkedList<int> list = [];

        [Fact]
        public void AddFirstShouldAddElementToBeginning()
        {
            this.list.AddFirst(10);
            this.list.AddFirst(20);

            this.list.Count.Should().Be(2);
            this.list.GetFirst().Should().Be(20);
            this.list.GetLast().Should().Be(10);
        }

        [Fact]
        public void AddLastShouldAddElementToEnd()
        {
            this.list.AddLast(10);
            this.list.AddLast(20);

            this.list.Count.Should().Be(2);
            this.list.GetFirst().Should().Be(10);
            this.list.GetLast().Should().Be(20);
        }

        [Fact]
        public void GetFirstShouldReturnFirstElement()
        {
            this.list.AddFirst(10);
            this.list.AddLast(20);

            this.list.GetFirst().Should().Be(10);
        }

        [Fact]
        public void GetLastShouldReturnLastElement()
        {
            this.list.AddFirst(10);
            this.list.AddLast(20);

            this.list.GetLast().Should().Be(20);
        }

        [Fact]
        public void RemoveFirstShouldRemoveAndReturnFirstElement()
        {
            this.list.AddFirst(10);
            this.list.AddLast(20);

            var removed = this.list.RemoveFirst();

            removed.Should().Be(10);
            this.list.Count.Should().Be(1);
            this.list.GetFirst().Should().Be(20);
        }

        [Fact]
        public void RemoveLastShouldRemoveAndReturnLastElement()
        {
            this.list.AddFirst(10);
            this.list.AddLast(20);

            var removed = this.list.RemoveLast();

            removed.Should().Be(20);
            this.list.Count.Should().Be(1);
            this.list.GetLast().Should().Be(10);
        }

        [Fact]
        public void ClearShouldRemoveAllElements()
        {
            this.list.AddFirst(10);
            this.list.AddLast(20);

            this.list.Clear();

            this.list.Count.Should().Be(0);
            var getFirst = () => this.list.GetFirst();
            var getLast = () => this.list.GetLast();

            getFirst.Should().Throw<InvalidOperationException>().WithMessage("List is empty!");
            getLast.Should().Throw<InvalidOperationException>().WithMessage("List is empty!");
        }

        [Fact]
        public void ToArrayShouldReturnArrayOfAllElements()
        {
            this.list.AddFirst(10);
            this.list.AddLast(20);

            var array = this.list.ToArray();

            array.Should().BeEquivalentTo([ 10, 20 ], options => options.WithStrictOrdering());
        }

        [Fact]
        public void EnumeratorShouldIterateOverAllElements()
        {
            this.list.AddLast(10);
            this.list.AddLast(20);
            this.list.AddLast(30);

            this.list.Should().BeEquivalentTo([10, 20, 30], options => options.WithStrictOrdering());
        }

        [Fact]
        public void RemoveFirstOnEmptyListShouldThrowException()
        {
            var removeFirst = () => this.list.RemoveFirst();

            removeFirst.Should().Throw<InvalidOperationException>().WithMessage("List is empty!");
        }

        [Fact]
        public void RemoveLastOnEmptyListShouldThrowException()
        {
            var removeLast = () => this.list.RemoveLast();

            removeLast.Should().Throw<InvalidOperationException>().WithMessage("List is empty!");
        }

        [Fact]
        public void GetFirstOnEmptyListShouldThrowException()
        {
            var getFirst = () => this.list.GetFirst();

            getFirst.Should().Throw<InvalidOperationException>().WithMessage("List is empty!");
        }

        [Fact]
        public void GetLastOnEmptyListShouldThrowException()
        {
            var getLast = () => this.list.GetLast();

            getLast.Should().Throw<InvalidOperationException>().WithMessage("List is empty!");
        }
    }
}
