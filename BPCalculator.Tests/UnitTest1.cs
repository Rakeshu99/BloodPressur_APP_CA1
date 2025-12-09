using System;
using Xunit;
using BPCalculator;

namespace BPCalculator.Tests
{
    public class BloodPressureTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var bp = new BloodPressure(120, 80);
            Assert.Equal(120, bp.Systolic);
            Assert.Equal(80, bp.Diastolic);
        }

        [Theory]
        [InlineData(69, 60)]
        [InlineData(191, 60)]
        public void Validate_SystolicOutOfRange_Throws(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Throws<ArgumentOutOfRangeException>(() => bp.Validate());
        }

        [Theory]
        [InlineData(70, 60)]
        [InlineData(190, 60)]
        public void Validate_SystolicWithinRange_DoesNotThrow(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Null(Record.Exception(() => bp.Validate()));
        }

        [Theory]
        [InlineData(120, 39)]
        [InlineData(120, 101)]
        public void Validate_DiastolicOutOfRange_Throws(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Throws<ArgumentOutOfRangeException>(() => bp.Validate());
        }

        [Theory]
        [InlineData(120, 40)]
        [InlineData(120, 100)]
        public void Validate_DiastolicWithinRange_DoesNotThrow(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Null(Record.Exception(() => bp.Validate()));
        }

        [Theory]
        [InlineData(100, 100)]
        [InlineData(90, 95)]
        public void Validate_InvalidRelation_Throws(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Throws<InvalidOperationException>(() => bp.Validate());
        }

        [Theory]
        [InlineData(100, 90)]
        [InlineData(150, 70)]
        [InlineData(120, 60)]
        public void Validate_ValidRelation_DoesNotThrow(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Null(Record.Exception(() => bp.Validate()));
        }

        [Theory]
        [InlineData(140, 60)]
        [InlineData(150, 50)]
        [InlineData(120, 95)]
        [InlineData(100, 90)]
        public void Category_ReturnsHigh(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Equal(BPCategory.High, bp.Category);
        }

        [Theory]
        [InlineData(120, 60)]
        [InlineData(130, 70)]
        [InlineData(100, 80)]
        [InlineData(119, 85)]
        public void Category_ReturnsPreHigh(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Equal(BPCategory.PreHigh, bp.Category);
        }

        [Theory]
        [InlineData(90, 60)]
        [InlineData(100, 70)]
        [InlineData(119, 79)]
        public void Category_ReturnsIdeal(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Equal(BPCategory.Ideal, bp.Category);
        }

        [Theory]
        [InlineData(89, 60)]
        [InlineData(90, 59)]
        [InlineData(70, 50)]
        public void Category_ReturnsLow(int sys, int dia)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Equal(BPCategory.Low, bp.Category);
        }

        [Theory]
        [InlineData(89, 59, BPCategory.Low)]
        [InlineData(90, 60, BPCategory.Ideal)]
        [InlineData(119, 79, BPCategory.Ideal)]
        [InlineData(120, 79, BPCategory.PreHigh)]
        [InlineData(119, 80, BPCategory.PreHigh)]
        [InlineData(139, 89, BPCategory.PreHigh)]
        [InlineData(140, 89, BPCategory.High)]
        [InlineData(139, 90, BPCategory.High)]
        public void Category_BoundaryMatrix(int sys, int dia, BPCategory expected)
        {
            var bp = new BloodPressure(sys, dia);
            Assert.Equal(expected, bp.Category);
        }
    }
}