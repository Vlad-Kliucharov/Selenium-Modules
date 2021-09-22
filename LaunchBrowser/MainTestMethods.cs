﻿using LaunchBrowser.PageElements;
using LaunchBrowser.PageMapping;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace LaunchBrowser
{
    [TestFixture]
    class MainTestMethods : SetupConfigurations
    {
        [TestCase(TestName = "Check 'ImplicitWait' on 'Control Page' for percentage")]
        [Category(Categories.Regression)]
        public void GoToPageControlsPage()
        {

            var NavToMain = new MainPage(driver);
            NavToMain.NavigateMainPage();

            Actions hoverQAAUtomation = new Actions(driver);

            var PageСourseWebDriver = new PageСourseWebDriver(driver);
            var NextControlPage = PageСourseWebDriver.clickSearchElements();

            hoverQAAUtomation.MoveToElement(driver.FindElement(By.ClassName("qaautomation"))).Build().Perform();
            NextControlPage.clickControlsPage();

            var elementPesantage = driver.FindElement(By.ClassName("elementor-counter-number"));
            WebDriverWait waitLoadPersantage = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitLoadPersantage.Until(ExpectedConditions.TextToBePresentInElement(elementPesantage, "100"));

            var itTableResult = new TableITprojects(driver);
            itTableResult.GetRows();
        }

        [TestCase(TestName = "Check-Box and Radio button validations on 'Control Page'")]
        [Category(Categories.Validation)]
        public void ContorPageValidation()
        {

            var NavToMain = new MainPage(driver);
            NavToMain.NavigateMainPage();

            var PageСourseWebDriver = new PageСourseWebDriver(driver);
            var NextControlPage = PageСourseWebDriver.clickSearchElements();
            NextControlPage.clickControlsPage();

            var selectButtonQA = driver.FindElement(By.Name("qa"));
            Assert.AreEqual(false, selectButtonQA.Selected, "Check box 'QA Engineer' is selected – Assert Failed");
            selectButtonQA.Click();
            Assert.AreEqual(true, selectButtonQA.Selected, "Check box 'QA Engineer' is not selected – Assert Failed");

            var unCheckBoxNet = driver.FindElement(By.Name("dev"));
            Assert.AreEqual(false, unCheckBoxNet.Selected, "Check box  '.NET Developer' is selected – Assert Failed");

            var selectButtonBA = driver.FindElement(By.Name("ba"));
            Assert.AreEqual(false, selectButtonBA.Selected, "Check box 'Business analyst' is selected – Assert Failed");
            selectButtonBA.Click();
            Assert.AreEqual(true, selectButtonBA.Selected, "Check box 'Business analyst' is not selected – Assert Failed");

            var unCheckBoxPM = driver.FindElement(By.Name("pm"));
            Assert.AreEqual(false, unCheckBoxPM.Selected, "Check box 'Project Manager' is selected – Assert Failed");

            var selectRadioLess1 = driver.FindElement(By.Id("lessone"));
            Assert.AreEqual(false, selectRadioLess1.Selected, "Radio button 'Less than 1' is selected – Assert Failed");
            selectRadioLess1.Click();
            Assert.AreEqual(true, selectRadioLess1.Selected, "Radio button 'Less than 1' is not selected – Assert Failed");

            var selectMore5 = driver.FindElement(By.Id("morefive"));
            Assert.AreEqual(false, selectMore5.Selected, "Radio button 'More than 5' is selected – Assert Failed");
            selectMore5.Click();
            Assert.AreEqual(true, selectMore5.Selected, "Radio button 'More than 5' is not selected – Assert Failed");
        }
    }
}