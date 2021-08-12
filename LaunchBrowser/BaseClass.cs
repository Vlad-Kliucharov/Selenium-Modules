﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LaunchBrowser
{
    public abstract class BaseClass
    {
        protected IWebDriver driver;

        [SetUp]

        public virtual void TestSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        //[TearDown]
        //public virtual void ShutDown()
        //{
        //    driver.Quit();
        //}
    }
}