namespace DataStructuresAndAlgorithms.DataStructures.Linear.List.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class MyListTests
    {
        private readonly MyList<int> list = [ 1, 2, 3 ];

        [Fact]
        public void ConstructorShouldInitializeWithDefaultLengthIfParameterIsNotPassed()
        {
            var emptyList = new MyList<int>();

            emptyList.Count.Should().Be(0);
            emptyList.Capacity.Should().Be(4);
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
            => this.list[1].Should().Be(2);

        [Fact]
        public void IndexerSetterShouldUpdateElement()
        {
            this.list[1] = 5;

            this.list[1].Should().Be(5);
        }

        [Fact]
        public void AddShouldIncreaseCount()
        {
            this.list.Add(4);
            this.list.Count.Should().Be(4);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ContainsShouldReturnTrueIfItemExists(int element) 
            => this.list.Contains(element).Should().BeTrue();

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(42142421)]
        public void ContainsShouldReturnFalseIfItemDoesNotExist(int element) 
            => this.list.Contains(element).Should().BeFalse();

        [Fact]
        public void IndexOfShouldReturnCorrectIndex() 
            => this.list.IndexOf(2).Should().Be(1);

        [Fact]
        public void IndexOfShouldReturnMinusOneIfItemDoesNotExist() 
            => this.list.IndexOf(4).Should().Be(-1);

        [Fact]
        public void InsertShouldAddElementAtCorrectPosition()
        {
            this.list.Insert(1, 2);

            this.list[1].Should().Be(2);
        }

        [Fact]
        public void RemoveShouldReturnTrueIfItemExists()
        {
            this.list.Remove(2).Should().BeTrue();

            this.list.Contains(2).Should().BeFalse();
        }

        [Fact]
        public void RemoveShouldReturnFalseIfItemDoesNotExist() 
            => this.list.Remove(4).Should().BeFalse();

        [Fact]
        public void RemoveAtShouldRemoveElementAtCorrectPosition()
        {
            this.list.RemoveAt(1);

            this.list.Contains(2).Should().BeFalse();
        }

        [Fact]
        public void ToArrayShouldReturnArrayWithCorrectElements()
        {
            var array = this.list.ToArray();

            array.Should().Equal([ 1, 2, 3 ]);
        }

        [Fact]
        public void ClearShouldResetList()
        {
            this.list.Clear();

            this.list.Count.Should().Be(0);
            this.list.Capacity.Should().Be(4);
        }
    }
}
