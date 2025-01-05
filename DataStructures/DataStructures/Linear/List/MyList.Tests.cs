namespace DataStructuresAndAlgorithms.DataStructures.Linear.List.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MyListTest
    {
        [Fact]
        public void ConstructorShouldInitializeWithDefaultLengthIfParameterIsNotPassed()
        {
            var list = new MyList<int>();
            list.Count.Should().Be(0);
            list.Capacity.Should().Be(4);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-421421142)]
        public void Constructor_ShouldThrowArgumentException_WhenLengthIsZeroOrNegative(int length)
        {
            var constructor = () => new MyList<int>(length);
            constructor.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void IndexerGetterShouldReturnCorrectElement()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list[1].Should().Be(2);
        }

        [Fact]
        public void IndexerSetterShouldUpdateElement()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list[1] = 5;
            list[1].Should().Be(5);
        }

        [Fact]
        public void AddShouldIncreaseCount()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Count.Should().Be(1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ContainsShouldReturnTrueIfItemExists(int element)
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.Contains(element).Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(42142421)]
        public void ContainsShouldReturnFalseIfItemDoesNotExist(int element)
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.Contains(element).Should().BeFalse();
        }

        [Fact]
        public void IndexOfShouldReturnCorrectIndex()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.IndexOf(2).Should().Be(1);
        }

        [Fact]
        public void IndexOfShouldReturnMinusOneIfItemDoesNotExist()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.IndexOf(4).Should().Be(-1);
        }

        [Fact]
        public void InsertShouldAddElementAtCorrectPosition()
        {
            var list = new MyList<int> { 1, 3 };
            list.Insert(1, 2);
            list[1].Should().Be(2);
        }

        [Fact]
        public void RemoveShouldReturnTrueIfItemExists()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.Remove(2).Should().BeTrue();
            list.Contains(2).Should().BeFalse();
        }

        [Fact]
        public void RemoveShouldReturnFalseIfItemDoesNotExist()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.Remove(4).Should().BeFalse();
        }

        [Fact]
        public void RemoveAtShouldRemoveElementAtCorrectPosition()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.RemoveAt(1);
            list.Contains(2).Should().BeFalse();
        }

        [Fact]
        public void ToArrayShouldReturnArrayWithCorrectElements()
        {
            var list = new MyList<int> { 1, 2, 3 };
            var array = list.ToArray();
            array.Should().Equal([ 1, 2, 3 ]);
        }

        [Fact]
        public void ClearShouldResetList()
        {
            var list = new MyList<int> { 1, 2, 3 };
            list.Clear();
            list.Count.Should().Be(0);
            list.Capacity.Should().Be(4);
        }
    }
}
