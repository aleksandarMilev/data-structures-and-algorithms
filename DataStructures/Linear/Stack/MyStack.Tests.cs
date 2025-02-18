namespace DataStructuresAndAlgorithms.DataStructures.Linear.Stack
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MyStackTests
    {
        private readonly MyStack<int> stack = [];

        [Fact]
        public void PushShouldAddElementToStack()
        {
            this.stack.Push(1);
            this.stack.Push(2);

            this.stack.Count.Should().Be(2);
            this.stack.Peek().Should().Be(2);
        }

        [Fact]
        public void PopShouldRemoveAndReturnTopElement()
        {
            this.stack.Push(1);
            this.stack.Push(2);

            var popped = this.stack.Pop();

            popped.Should().Be(2);
            this.stack.Count.Should().Be(1);
            this.stack.Peek().Should().Be(1);
        }

        [Fact]
        public void PeekShouldReturnTopElementWithoutRemovingIt()
        {
            this.stack.Push(1);
            this.stack.Push(2);

            var peeked = this.stack.Peek();

            peeked.Should().Be(2);
            this.stack.Count.Should().Be(2);
        }

        [Fact]
        public void PopOnEmptyStackShouldThrowInvalidOperationException()
        {
            var pop = this.stack.Pop;

            pop
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Stack is empty!");
        }

        [Fact]
        public void PeekOnEmptyStackShouldThrowInvalidOperationException()
        {
            var peek = this.stack.Peek;

            peek
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Stack is empty!");
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsInStack()
        {
            this.stack.Push(1);
            this.stack.Push(2);
            this.stack.Push(3);

            this.stack.Contains(2).Should().BeTrue();
            this.stack.Contains(4).Should().BeFalse();
        }

        [Fact]
        public void ClearShouldRemoveAllElementsFromStack()
        {
            this.stack.Push(1);
            this.stack.Push(2);

            this.stack.Clear();

            this.stack.Count.Should().Be(0);

            var peek = this.stack.Peek;

            peek
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Stack is empty!");
        }

        [Fact]
        public void ToArrayShouldReturnArrayInStackOrder()
        {
            this.stack.Push(1);
            this.stack.Push(2);
            this.stack.Push(3);

            var array = this.stack.ToArray();

            array.Should().BeEquivalentTo([ 3, 2, 1 ]);
        }

        [Fact]
        public void EnumeratorShouldIterateOverStackElements()
        {
            this.stack.Push(1);
            this.stack.Push(2);
            this.stack.Push(3);

            var elements = new int[] { 3, 2, 1 };
            this.stack.Should().BeEquivalentTo(elements);
        }
    }
}
