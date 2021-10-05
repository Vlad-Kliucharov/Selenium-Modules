﻿using LaunchBrowser.PageMapping;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace LaunchBrowser
{
    public abstract class SetupConfigurations : BasePage
    {
        public SetupConfigurations() : base(new ChromeDriver()) { }

        [SetUp]
        public virtual void TestSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        public MainPage OpenHomePage()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["MainPage"]);
            return new MainPage(driver);
        }

        [TearDown]
        public virtual void ShutDown()
        {
            driver.Quit();
        }
    }
}
