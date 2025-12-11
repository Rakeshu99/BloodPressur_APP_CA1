using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.IO;
using System.Threading;

namespace BPCalculator.E2E
{
    public class BpUiTests
    {
        private readonly string baseUrl = "http://localhost:5000";

        [Fact]
        public void UserCanCalculateBloodPressureCategory()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            using var driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl(baseUrl);
            Thread.Sleep(1000);

            driver.FindElement(By.Id("BP_Systolic")).Clear();
            driver.FindElement(By.Id("BP_Systolic")).SendKeys("150");

            driver.FindElement(By.Id("BP_Diastolic")).Clear();
            driver.FindElement(By.Id("BP_Diastolic")).SendKeys("95");

            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            Thread.Sleep(1500);

            // 🔍 Category div detection
            var categoryDiv = driver.FindElement(By.XPath("//div[contains(text(),'High Blood Pressure')]"));
            var categoryText = categoryDiv.Text.Trim();

            // 🔍 Pulse pressure input (correct selector)
            var pulseInput = driver.FindElement(By.XPath("//label[text()='Pulse Pressure:']/following-sibling::input"));
            var pulseValue = pulseInput.GetAttribute("value");

            // For debugging: save HTML
            File.WriteAllText("selenium_debug_after_submit.html", driver.PageSource);

            Assert.Equal("High Blood Pressure", categoryText);
            Assert.Equal("55", pulseValue);
        }
    }
}
