using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System;
using System.IO;
using System.Threading;

namespace BPCalculator.E2E
{
    public class BpUiTests
    {
        private readonly string baseUrl;

        public BpUiTests()
        {
            baseUrl = Environment.GetEnvironmentVariable("BASE_URL")
                ?? throw new InvalidOperationException(
                    "BASE_URL environment variable must be set for E2E tests");
        }

        [Fact]
        public void UserCanCalculateBloodPressureCategory()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            using var driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl(baseUrl);
            Thread.Sleep(2000);

            driver.FindElement(By.Id("BP_Systolic")).Clear();
            driver.FindElement(By.Id("BP_Systolic")).SendKeys("150");

            driver.FindElement(By.Id("BP_Diastolic")).Clear();
            driver.FindElement(By.Id("BP_Diastolic")).SendKeys("95");

            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            Thread.Sleep(2000);

            var categoryText = driver
                .FindElement(By.XPath("//div[contains(text(),'High Blood Pressure')]"))
                .Text.Trim();

            var pulseValue = driver
                .FindElement(By.XPath("//label[text()='Pulse Pressure:']/following-sibling::input"))
                .GetAttribute("value");

            File.WriteAllText("selenium_debug.html", driver.PageSource);

            Assert.Equal("High Blood Pressure", categoryText);
            Assert.Equal("55", pulseValue);
        }
    }
}
