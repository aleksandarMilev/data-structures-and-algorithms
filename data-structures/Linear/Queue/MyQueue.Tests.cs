namespace DataStructuresAndAlgorithms.DataStructures.Linear.Queue
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MyQueueTests
    {
        private readonly MyQueue<int> queue = [];

        [Fact]
        public void EnqueueShouldIncreaseCount()
        {
            var initialCount = this.queue.Count;

            this.queue.Enqueue(1);

            this.queue.Count.Should().Be(initialCount + 1);
        }

        [Fact]
        public void DequeueShouldReturnCorrectElement()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);

            var dequeuedElement = this.queue.Dequeue();

            dequeuedElement.Should().Be(1);
            this.queue.Count.Should().Be(1);
        }

        [Fact]
        public void DequeueShouldThrowExceptionWhenQueueIsEmpty()
        {
            var dequeue = this.queue.Dequeue;

            dequeue
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("The queue is empty!");
        }

        [Fact]
        public void PeekShouldReturnCorrectElement()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);

            var peekedElement = this.queue.Peek();

            peekedElement.Should().Be(1);
        }

        [Fact]
        public void PeekShouldThrowExceptionWhenQueueIsEmpty()
        {
            var peek = this.queue.Peek;
            peek
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("The queue is empty!");
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsInQueue()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);

            var containsElement = this.queue.Contains(2);

            containsElement.Should().BeTrue();
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotInQueue()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);

            var containsElement = this.queue.Contains(3);

            containsElement.Should().BeFalse();
        }

        [Fact]
        public void ClearShouldRemoveAllElements()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);

            this.queue.Clear();

            this.queue.Count.Should().Be(0);
            this.queue.Should().NotContain(1);
            this.queue.Should().NotContain(2);
        }

        [Fact]
        public void ToArrayShouldReturnElementsInCorrectOrder()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);
            this.queue.Enqueue(3);

            var array = this.queue.ToArray();

            array.Should().Equal(1, 2, 3);
        }

        [Fact]
        public void EnumeratorShouldIterateOverQueueElements()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);
            this.queue.Enqueue(3);

            var elements = new int[] { 1, 2, 3 };
            this.queue.Should().BeEquivalentTo(elements);
        }
    }
}
