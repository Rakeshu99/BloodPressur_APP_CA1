using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BPCalculator;  // Ensure this matches the namespace of your BloodPressure class

namespace TestProject1.Unit.tests
{
    [TestClass]
    public class BloodPressureTests
    {
        // ========== HIGH BLOOD PRESSURE TESTS ==========
        [TestMethod]
        public void HighBP_Systolic140_Diastolic70_ReturnsHigh()
        {
            var bp = new BloodPressure { Systolic = 140, Diastolic = 70 };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        [TestMethod]
        public void HighBP_Systolic190_Diastolic70_ReturnsHigh()
        {
            var bp = new BloodPressure { Systolic = 190, Diastolic = 70 };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        [TestMethod]
        public void HighBP_Systolic110_Diastolic90_ReturnsHigh()
        {
            var bp = new BloodPressure { Systolic = 110, Diastolic = 90 };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        [TestMethod]
        public void HighBP_Systolic110_Diastolic100_ReturnsHigh()
        {
            var bp = new BloodPressure { Systolic = 110, Diastolic = 100 };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        [TestMethod]
        public void HighBP_Systolic160_Diastolic95_ReturnsHigh()
        {
            var bp = new BloodPressure { Systolic = 160, Diastolic = 95 };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        // ========== PRE-HIGH BLOOD PRESSURE TESTS ==========
        [TestMethod]
        public void PreHighBP_Systolic120_Diastolic70_ReturnsPreHigh()
        {
            var bp = new BloodPressure { Systolic = 120, Diastolic = 70 };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        [TestMethod]
        public void PreHighBP_Systolic139_Diastolic70_ReturnsPreHigh()
        {
            var bp = new BloodPressure { Systolic = 139, Diastolic = 70 };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        [TestMethod]
        public void PreHighBP_Systolic100_Diastolic80_ReturnsPreHigh()
        {
            var bp = new BloodPressure { Systolic = 100, Diastolic = 80 };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        [TestMethod]
        public void PreHighBP_Systolic100_Diastolic89_ReturnsPreHigh()
        {
            var bp = new BloodPressure { Systolic = 100, Diastolic = 89 };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        [TestMethod]
        public void PreHighBP_Systolic130_Diastolic85_ReturnsPreHigh()
        {
            var bp = new BloodPressure { Systolic = 130, Diastolic = 85 };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        // ========== IDEAL BLOOD PRESSURE TESTS ==========
        [TestMethod]
        public void IdealBP_Systolic90_Diastolic60_ReturnsIdeal()
        {
            var bp = new BloodPressure { Systolic = 90, Diastolic = 60 };
            Assert.AreEqual(BPCategory.Ideal, bp.Category);
        }

        [TestMethod]
        public void IdealBP_Systolic119_Diastolic79_ReturnsIdeal()
        {
            var bp = new BloodPressure { Systolic = 119, Diastolic = 79 };
            Assert.AreEqual(BPCategory.Ideal, bp.Category);
        }

        [TestMethod]
        public void IdealBP_Systolic100_Diastolic70_ReturnsIdeal()
        {
            var bp = new BloodPressure { Systolic = 100, Diastolic = 70 };
            Assert.AreEqual(BPCategory.Ideal, bp.Category);
        }

        [TestMethod]
        public void IdealBP_Systolic110_Diastolic75_ReturnsIdeal()
        {
            var bp = new BloodPressure { Systolic = 110, Diastolic = 75 };
            Assert.AreEqual(BPCategory.Ideal, bp.Category);
        }

        // ========== LOW BLOOD PRESSURE TESTS ==========
        [TestMethod]
        public void LowBP_Systolic70_Diastolic40_ReturnsLow()
        {
            var bp = new BloodPressure { Systolic = 70, Diastolic = 40 };
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }

        [TestMethod]
        public void LowBP_Systolic89_Diastolic70_ReturnsLow()
        {
            var bp = new BloodPressure { Systolic = 89, Diastolic = 70 };
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }

        [TestMethod]
        public void LowBP_Systolic100_Diastolic59_ReturnsLow()
        {
            var bp = new BloodPressure { Systolic = 100, Diastolic = 59 };
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }

        [TestMethod]
        public void LowBP_Systolic80_Diastolic50_ReturnsLow()
        {
            var bp = new BloodPressure { Systolic = 80, Diastolic = 50 };
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }

        [TestMethod]
        public void LowBP_Systolic85_Diastolic55_ReturnsLow()
        {
            var bp = new BloodPressure { Systolic = 85, Diastolic = 55 };
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }

        // ========== INVALID BLOOD PRESSURE TESTS ==========
        [TestMethod]
        public void InvalidBP_SystolicGreaterThanMax_ThrowsException()
        {
            // Ensure that the exception is triggered on this line:
            var bp = new BloodPressure { Systolic = 200, Diastolic = 80 };
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var c = bp.Category; });
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void InvalidBP_SystolicNegative_ThrowsException()
        {
            // Ensure that the exception is triggered on this line:
            var bp = new BloodPressure { Systolic = -10, Diastolic = 80 };
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var c = bp.Category; });
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void InvalidBP_DiastolicNegative_ThrowsException()
        {
            // Ensure that the exception is triggered on this line:
            var bp = new BloodPressure { Systolic = 100, Diastolic = -5 };
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var c = bp.Category; });
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void InvalidBP_SystolicBelowMin_ThrowsException()
        {
            // Ensure that the exception is triggered on this line:
            var bp = new BloodPressure { Systolic = 69, Diastolic = 70 };
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var c = bp.Category; });
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void InvalidBP_DiastolicBelowMin_ThrowsException()
        {
            // Ensure that the exception is triggered on this line:
            var bp = new BloodPressure { Systolic = 100, Diastolic = 30 };
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var c = bp.Category; });
            Assert.IsNotNull(exception);
        }

        // Add this missing test for Diastolic > max (100)
        [TestMethod]
        public void InvalidBP_DiastolicAboveMax_ThrowsException()
        {
            // Ensure that the exception is triggered on this line:
            var bp = new BloodPressure { Systolic = 120, Diastolic = 101 };  // Diastolic exceeds the max
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var c = bp.Category; });
            Assert.IsNotNull(exception);
        }
    }
}