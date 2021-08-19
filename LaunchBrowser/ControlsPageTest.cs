﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace LaunchBrowser
{
    [TestFixture]

    class ControlsPageTest : SetupConfigTest
    {
        [TestCase(TestName = "Check 'ImplicitWait' on 'Control Page' for percentage")]
        [Category(Regression)]
        [Obsolete]
        public void GoToPageControlsPage()
        {
            Actions hoverQAAUtomation = new Actions(driver);
            Actions rightClick = new Actions(driver);

            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

            IWebElement searchElements = driver.FindElement(By.XPath("//*[contains(text(),'Поиск элементов на странице')]"));
            searchElements.Click();

            hoverQAAUtomation.MoveToElement(driver.FindElement(By.ClassName("qaautomation"))).Build().Perform();

            IWebElement controlsPage = driver.FindElement(By.XPath("//a[contains(text(),'CONTROLS PAGE')]"));
            controlsPage.Click();

            //var elementPesantage = driver.FindElement(By.ClassName("elementor-counter-number"));
            //WebDriverWait waitLoadPersantage = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //waitLoadPersantage.Until(ExpectedConditions.TextToBePresentInElement(elementPesantage, ConfigurationManager.AppSettings["ImplicitWait"]));

            var tableRows = driver.FindElement(By.XPath("*//table[1]/tbody/tr[1]"));

            List<itProjectTableRows> itProjectTable = new List<itProjectTableRows>();

        }

        [TestCase(TestName = "Check-Box and Radio button validations on 'Control Page'")]
        [Category(Validation)]
        public void ContorPageValidation()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

            IWebElement clickSearchElements = driver.FindElement(By.XPath("//*[contains(text(),'Поиск элементов на странице')]"));
            clickSearchElements.Click();

            IWebElement clickControlsPage = driver.FindElement(By.XPath("//a[contains(text(),'CONTROLS PAGE')]"));
            clickControlsPage.Click();

            IWebElement selectButtonQA = driver.FindElement(By.Name("qa"));
            Assert.AreEqual(false, selectButtonQA.Selected, "Check box 'QA Engineer' is selected – Assert Failed");
            selectButtonQA.Click();
            Assert.AreEqual(true, selectButtonQA.Selected, "Check box 'QA Engineer' is not selected – Assert Failed");

            IWebElement unCheckBoxNet = driver.FindElement(By.Name("dev"));
            Assert.AreEqual(false, unCheckBoxNet.Selected, "Check box  '.NET Developer' is selected – Assert Failed");

            IWebElement selectButtonBA = driver.FindElement(By.Name("ba"));
            Assert.AreEqual(false, selectButtonBA.Selected, "Check box 'Business analyst' is selected – Assert Failed");
            selectButtonBA.Click();
            Assert.AreEqual(true, selectButtonBA.Selected, "Check box 'Business analyst' is not selected – Assert Failed");

            IWebElement unCheckBoxPM = driver.FindElement(By.Name("pm"));
            Assert.AreEqual(false, unCheckBoxPM.Selected, "Check box 'Project Manager' is selected – Assert Failed");

            IWebElement selectRadioLess1 = driver.FindElement(By.Id("lessone"));
            Assert.AreEqual(false, selectRadioLess1.Selected, "Radio button 'Less than 1' is selected – Assert Failed");
            selectRadioLess1.Click();
            Assert.AreEqual(true, selectRadioLess1.Selected, "Radio button 'Less than 1' is not selected – Assert Failed");

            IWebElement selectMore5 = driver.FindElement(By.Id("morefive"));
            Assert.AreEqual(false, selectMore5.Selected, "Radio button 'More than 5' is selected – Assert Failed");
            selectMore5.Click();
            Assert.AreEqual(true, selectMore5.Selected, "Radio button 'More than 5' is not selected – Assert Failed");
        }
    }

    public class itProjectTableRows
    {
        public IWebElement Name { get; set; }
        public IWebElement budget { get; set; }
    }
}