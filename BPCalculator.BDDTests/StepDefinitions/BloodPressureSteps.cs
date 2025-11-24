using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace BPCalculator.BDDTests.StepDefinitions
{
    [Binding]
    public class BloodPressureSteps
    {
        private BloodPressure _bp;
        private BPCategory _result;

        [Given(@"the systolic value is (.*)")]
        public void GivenTheSystolicValueIs(int systolic)
        {
            _bp ??= new BloodPressure();
            _bp.Systolic = systolic;
        }

        [Given(@"the diastolic value is (.*)")]
        public void GivenTheDiastolicValueIs(int diastolic)
        {
            _bp ??= new BloodPressure();
            _bp.Diastolic = diastolic;
        }

        [When(@"I calculate the blood pressure category")]
        public void WhenICalculateTheBloodPressureCategory()
        {
            _result = _bp.Category;
        }

        [Then(@"the category should be ""(.*)""")]
        public void ThenTheCategoryShouldBe(string expectedCategory)
        {
            Assert.AreEqual(expectedCategory, _result.ToString());
        }
    }
}
