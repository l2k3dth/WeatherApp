using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using FluentAssertions;

namespace WeatherApp.Tests.E2E
{
    public class WeatherAppUiTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Submit_Location_And_Display_Location_Data()
        {
            using var driver = new ChromeDriver(".");

            driver.Navigate().GoToUrl("http://localhost:3000");
            var input = driver.FindElement(By.Id("location-input"));
            var searchButton = driver.FindElement(By.Id("search-button"));

            input.Click();
            input.SendKeys("london");
            searchButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            var title = wait.Until(d => d.FindElement(By.Id("location-title")));

            title.Text.Should().Be("London");
        }

        [Test]
        public void Should_Submit_non_Location_And_Get_Error_back()
        {
            using var driver = new ChromeDriver(".");

            driver.Navigate().GoToUrl("https://localhost:5001");
            var input = driver.FindElement(By.Id("location-input"));
            var searchButton = driver.FindElement(By.Id("search-button"));

            input.Click();
            input.SendKeys("asdfasfdsad");
            searchButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            var title = wait.Until(d => d.FindElement(By.Id("error")));
            title.Text.Should().Be("city not found");
        }

        [Test]
        public void Should_Submit_Empty_And_Get_Error_back()
        {
            using var driver = new ChromeDriver(".");

            driver.Navigate().GoToUrl("https://localhost:5001");
            var input = driver.FindElement(By.Id("location-input"));
            var searchButton = driver.FindElement(By.Id("search-button"));

            searchButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            var title = wait.Until(d => d.FindElement(By.Id("error")));

            title.Text.Should().Be("Please enter a location");
        }
    }
}