using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestExample.Tests
{
    [TestFixture]
    public class AddRemoveElementsTests
    {
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void AddNElementsAndAssert()
        {
            driver.Url = "https://the-internet.herokuapp.com/add_remove_elements/";
            Thread.Sleep(1000);
            int numberOfElementsToAdd = 5;
            for (int i = 0; i < numberOfElementsToAdd; i++)
            {
                driver.FindElement(By.XPath("//button[@onclick='addElement()']")).Click();
            }
            int numberOfElements = driver.FindElements(By.ClassName("added-manually")).Count;
            string message = $"Expected {numberOfElementsToAdd} elements, but found {numberOfElements} elements.";
            Assert.That(numberOfElements, Is.EqualTo(numberOfElementsToAdd), message);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}